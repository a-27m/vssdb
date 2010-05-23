using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.DirectX.DirectSound;


namespace testds
{
    public partial class Form1 : Form
    {
        public class Generator
        {
            public static void Tone(Int16[] data, int offset, double frequency, double volume, int samples)
            {
                if (offset + samples >= data.Length)
                {
                    samples = data.Length - offset - 1;
                    //throw new ArgumentException("Wrong offset, samples and data.Length combination");
                }

                for (int i = 0; i < samples; i++)
                {
                    data[offset + i] = (Int16)(Math.Sin(i * 6.28f / samplerate * frequency) * volume);
                }

                // antialiasing
                int len = 1000 % samples;
                for (int i = 0; i < len; i++)
                {
                    data[offset + i] = //data[offset + samples - i - 1] =
                        (Int16)((float)i / (float)len * data[offset + i]);
                    data[offset + samples - i - 1] =
                        (Int16)((float)i / (float)len * data[offset + samples - i - 1]);
                }
            }

            public static void Bass(Int16[] data, int offset, double frequency, double volume, int samples)
            {
                // v = (sin(x*2*3.14/0.22)/(x*2*3.14/0.22)-(x*2*3.14/0.22)/9+1)/2
                // f = 3.3/(0.02*(x+1))+35

                double T;
                T = (double)samples / (double)samplerate;

                // volume params
                double kv, TwoPiT;
                TwoPiT = Math.PI * 2.0 / T;
                kv = 1.0 / 9.0;

                // modulation params
                double f_max, f_min, kf, a, b;

                //f_max = 200;
                f_max = frequency;
                f_min = f_max - 150;

                a = 1;
                kf = (f_max - f_min) * a * (T + a) / T;
                b = f_max - kf / a;

                if (offset + samples >= data.Length)
                {
                    samples = data.Length - offset - 1;
                }


                double t, dt, v, f;
                t = 0; dt = T/samples;
                for (int i = 0; i < samples; i++)
                {
                    v = (Math.Sin(t * TwoPiT) / (t * TwoPiT) - kv * t * TwoPiT + 1) / 2 * volume;
                    f = kf / (t + a) + b; 
 
                    data[offset + i] = (Int16)(Math.Sin(t * f) * v);

                    t += dt;
                }
 
                // add antialiasing
                int len = 132 % samples;
                for (int i = 0; i < len; i++)
                {
                    data[offset + i] = //data[offset + samples - i - 1] =
                        (Int16)((float)i / (float)len * data[offset + i]);
                    data[offset + samples - i - 1] =
                        (Int16)((float)i / (float)len * data[offset + samples - i - 1]);
                }
            }
        }

        public class StateMachine
        {
            protected static Random rnd = new Random();
            //public readonly float SampleRate;

            public struct Note
            {
                float freq;
                float dura; // in samples
                float vol;

                /// <summary>
                /// Hz
                /// </summary>
                public float Frequency { get { return freq; } set { freq = value; } }
                /// <summary>
                /// sec
                /// </summary>
                public float DurationSeconds { get { return dura / samplerate; } set { dura = value * samplerate; } }
                public float DurationSamples { get { return dura; } set { dura = value; } }
                /// <summary>
                /// 0..32767
                /// </summary>
                public float Volume { get { return vol; } set { vol = value; } }

                public Note(float frequency, float duration, float volume)
                {
                    freq = frequency;
                    dura = duration;
                    vol = volume;
                }

            }

            Note stateCurr;

            /// <summary>
            /// Равномерно темперированный строй
            /// </summary>
            /// <param name="camerton">Частота камертона (например, Ля 440 Hz)</param>
            /// <param name="HalfTones">Количество полутонов в интервале от искомого звука к камертону</param>
            public float ShiftHalfTone(float camerton, int HalfTones)
            {
                return (float)(camerton * Math.Pow(2.0, (double)HalfTones / 12.0));
            }

            public Note Current
            {
                get { return stateCurr; }
//                set { stateCurr = value; }
            }

            //public float Frequency { get { return stateCurr.Frequency; } }
            //public float Duration { get { return stateCurr.Duration; } }
            //public float Volume { get { return stateCurr.Volume; } }

            float fMin, fMax;
            float dMin, dMax;
            float vMin, vMax;

            public StateMachine(/*int samplerate*/)
            {
                //this.SampleRate = samplerate;
                fMin = 30f; fMax = 15000f;
                dMin = 0f; dMax = 0.8f;
                vMin = 1f; vMax = 7000f;

                stateCurr = new Note();
            }

            public Note Next()
            {
                int htones;
                do { htones = rnd.Next(-12, 12); } 
                while ((htones == 2) || (htones == -2) ||
                    (htones == 7) || (htones == -7));

                float f = ShiftHalfTone(stateCurr.Frequency, htones);

                while (f > fMax) f = ShiftHalfTone(f, -5);
                while (f < fMin) f = ShiftHalfTone(f, 5);

                float v = (float)(Math.Sqrt(Math.Sqrt(rnd.NextDouble() + 1e-3)) * vMax);// +20000;
                float l = (float)(Math.Sqrt(Math.Sqrt(rnd.NextDouble() + 0.1)) * dMax); // sec


                stateCurr.Frequency = f;
                stateCurr.Volume = v;

                return new Note(f, l*samplerate, v);
            }


            public void Initialize()
            {
                stateCurr.Frequency = 440; // Ля 1й октавы
            }
        }

        public StateMachine stateMachine;

        public Form1()
        {
            InitializeComponent();

            dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);

            stateMachine = new StateMachine();
        }

        const int samplerate = 22050;
        const int bitspersample = 16;

        Device dev;
        SecondaryBuffer buffer;

        private Int16[] ComposeTone(float fmax, float len)
        {
            Int16[] pcm = new Int16[samplerate * 60 * 1]; // Int16[]
            int pos = 0;

            StateMachine.Note n;
            stateMachine.Initialize();

            while (pos < pcm.Length)
            {                
                n = stateMachine.Next();

                Generator.Tone(pcm, pos, n.Frequency, n.Volume, (int)(n.DurationSamples));

                pos += (int)(n.DurationSamples);

                progressBar1.Value = (int)((decimal)pos / (decimal)pcm.Length * (decimal)progressBar1.Maximum) % progressBar1.Maximum;
                Application.DoEvents();
            }

            return pcm;
        }

        private Int16[] ComposeBass()
        {
            Int16[] pcm = new Int16[samplerate * 60 * 1]; // Int16[]

            int pos = 0;
            Random rnd = new Random();

            double f, v, l;
            l = 0.5;
            while (pos < pcm.Length)
            {
                f = pos/(l*samplerate) % 4 * 200 + 200; // 150 .. 450

                //v = rnd.NextDouble() * 16000;// +20000;

                //l = rnd.NextDouble() * 0.4 + 0.2;// 0.18 .. 0.3; // sec
                l = 0.5;
                Generator.Bass(pcm, pos, f, 20000, (int)(l * 22050));

                pos += (int)(l * 22050);

                progressBar1.Value = (int)((decimal)pos / (decimal)pcm.Length * (decimal)progressBar1.Maximum) % progressBar1.Maximum;
                Application.DoEvents();
            }

            return pcm;
        }

        private Int16[] mix(Int16[] pcm1, Int16[] pcm2)
        {
            int maxlen = pcm1.Length > pcm2.Length ? pcm1.Length : pcm2.Length;
            int minlen = pcm1.Length > pcm2.Length ? pcm2.Length : pcm1.Length;
            
            Int16[] result = new Int16[maxlen];

            for (int i = 0; i < minlen; i++)
            {
                int sample = pcm1[i] + pcm2[i];
                if (sample > Int16.MaxValue) sample = Int16.MaxValue;
                if (sample < Int16.MinValue) sample = Int16.MinValue;
                result[i] = (Int16)sample;
            }

            Int16[] pcmLong = pcm1.Length > pcm2.Length ? pcm1 : pcm2;
            for (int i = minlen; i < maxlen; i++)
            {
                result[i] = pcmLong[i];
            }

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pcm = new Int16[samplerate * 60 * 1]; // Int16[]
            //pcm = new MemoryStream(samplerate * 60 * 3 * 16 / 8);

            //for (int i = 0; i < pcm.Length; i++)
            //{
            //    pcm[i] = (Int16)f(i);
            //}
            Int16[] final, track1, track2;

            final = ComposeBass();            

            //final = mix(ComposeTone(), ComposeTone());
            //final = mix(final, ComposeTone());

            //final = mix(final, ComposeTone(400, 1f));
            final = mix(final, ComposeTone(1000, 0.5f));
            final = mix(final, ComposeTone(2000, 0.5f));
            final = mix(final, ComposeTone(10000, 0.1f));
            final = mix(final, ComposeTone(10000, 0.01f));

            Stop();
            Play(final);

            //WriteToFile("my.wav", pcm);
            //MessageBox.Show("Done!");
        }

        private void Stop()
        {
            if (buffer != null)
                buffer.Stop();
        }

        private int f(float i)
        {
            double f = 0;

            Random rand = new Random();

            f += Math.Sin(i * (2f * Math.PI) / samplerate * 100f) * 8000f;

            f += Math.Sin(i * (2f * Math.PI) / samplerate * 50 ) * 1600f;

            f += rand.NextDouble() * 16000 - 8000;

            //f += Math.Sin(
            //    (2f * Math.PI) / samplerate * i* (
            //    Math.Sin((2f * Math.PI)/samplerate*i*2)*20+500)// frequency
            //        //(Math.Sin(i / samplerate * (2f * Math.PI) * 0.5f) * 50f + 50f)
            //   ) * 20000f;

            //f += Math.Sin(
            //    (2f * Math.PI) / samplerate * i * 1000// frequency
            //    //(Math.Sin(i / samplerate * (2f * Math.PI) * 0.5f) * 50f + 50f)
            //   ) * 2000f;

            return (int)f;

            //return (i-11025)*2*((i%2)*2-1);
        }

        private void WriteToFile(string filename, Int16[] words)
        {
            BinaryWriter f = new BinaryWriter(new FileStream(filename, FileMode.Create));

            f.Write("RIFF".ToCharArray());
            f.Write((Int32)(words.Length * 2 - 8));
            f.Write("WAVEfmt ".ToCharArray());
            f.Write((Int32)16);
            f.Write((Int16)1); // format tag
            f.Write((Int16)1); // channels
            f.Write((Int32)samplerate); // SamplesPerSec
            f.Write((Int32)samplerate * 2);// AvgBytesPerSec = samplerate*sizeof(int16)/sizeof(byte);
            f.Write((Int16)2); // BlockAlign
            f.Write((Int16)16); // BitsPerSample
            f.Write("data".ToCharArray());
            f.Write((Int32)words.Length * 2); // Length;
            
            for(int i = 0; i < words.Length; i++)
                f.Write(words[i]);

            f.Close();
        }
        private void WriteToFile(string filename, MemoryStream words)
        {
            BinaryWriter f = new BinaryWriter(new FileStream(filename, FileMode.Create));

            f.Write("RIFF".ToCharArray());
            f.Write((Int32)(words.Length * 2 - 8));
            f.Write("WAVEfmt ".ToCharArray());
            f.Write((Int32)16);
            f.Write((Int16)1); // format tag
            f.Write((Int16)1); // channels
            f.Write((Int32)samplerate); // SamplesPerSec
            f.Write((Int32)samplerate * 2);// AvgBytesPerSec = samplerate*sizeof(int16)/sizeof(byte);
            f.Write((Int16)2); // BlockAlign
            f.Write((Int16)16); // BitsPerSample
            f.Write("data".ToCharArray());
            f.Write((Int32)words.Capacity * 2); // Length;
            
            words.WriteTo(f.BaseStream);

            f.Close();
        }

        private void Play(string filename)
        {
            StreamReader reader = new StreamReader(filename);

            WaveFormat format = new WaveFormat();
            format.AverageBytesPerSecond = bitspersample / 8 * samplerate;
            format.BitsPerSample = bitspersample;
            format.BlockAlign = bitspersample / 8;
            format.Channels = 1;
            format.FormatTag = WaveFormatTag.Pcm;
            format.SamplesPerSecond = samplerate;

            BufferDescription desc = new BufferDescription(format);
            desc.BufferBytes = (int)reader.BaseStream.Length;
            desc.ControlVolume = true;
            desc.GlobalFocus = true;

            buffer = new SecondaryBuffer(desc, dev);
            //buffer = new SecondaryBuffer(filename, dev);
            buffer.Write(0, reader.BaseStream, (int)reader.BaseStream.Length, LockFlag.None);

            reader.Close();

            //m_BufferBytes = buffer.Caps.BufferBytes;


            buffer.Play(0, BufferPlayFlags.Default);
        }

        private void Play(Int16[] data)
        {
            WaveFormat format = new Microsoft.DirectX.DirectSound.WaveFormat();
            format.AverageBytesPerSecond = bitspersample / 8 * samplerate;
            format.BitsPerSample = bitspersample;
            format.BlockAlign = bitspersample / 8;
            format.Channels = 1;
            format.FormatTag = WaveFormatTag.Pcm;
            format.SamplesPerSecond = samplerate;

            BufferDescription desc = new BufferDescription(format);
            desc.BufferBytes = (int)(bitspersample/8*data.Length);
            desc.ControlVolume = true;
            desc.GlobalFocus = true;

            buffer = new SecondaryBuffer(desc, dev);
            buffer.Write(0, data, LockFlag.None);

            buffer.Play(0, BufferPlayFlags.Default);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buffer.Stop();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            WriteToFile("my.wav", (Int16[])buffer.Read(
                0,
                Int16.MaxValue.GetType(),
                LockFlag.None,
                buffer.Caps.BufferBytes / 2
                ));

            MessageBox.Show("Saved");
        }
    }
}
