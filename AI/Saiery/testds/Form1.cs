using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.DirectX.DirectSound;
using System.IO;


namespace testds
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);            
        }

        const int samplerate = 22050;
        const int bitspersample = 16;

        //MemoryStream pcm;
        Int16[] pcm;
        Device dev;
        SecondaryBuffer buffer;

        private void button1_Click(object sender, EventArgs e)
        {
            pcm = new Int16[samplerate * 60 * 1]; // Int16[]
            //pcm = new MemoryStream(samplerate * 60 * 3 * 16 / 8);

            for (int i = 0; i < pcm.Length / 2; i++)
            {
                //Int16 sample =(Int16)f(i);
                //pcm.WriteByte((byte)(sample >> 8));
                //pcm.WriteByte((byte)(sample & 255));

                pcm[i] = (Int16)f(i);
            }

            Stop();

            //WriteToFile("my.wav", pcm);

            //MessageBox.Show("Done!");

            Play(pcm);
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
            WaveFormat format = new WaveFormat();
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
    }
}
