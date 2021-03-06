using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DataProc
{
    public class ExceptionTableValuesGet : Exception
    {
        public ExceptionTableValuesGet()
            : base()
        {
        }
        public ExceptionTableValuesGet(string message)
            : base(message)
        {
        }
        public ExceptionTableValuesGet(string message, Exception innerE)
            : base(message, innerE)
        {
        }
        public ExceptionTableValuesGet(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }

    public class StatisticsProcessor
    {
        #region tables

        readonly public static float[] χSqr_a0_010 = new float[] { 6.60000f, 9.200f, 11.30f, 13.30f, 15.10f, 16.80f, 18.5f, 20.1f, 21.7f, 23.2f, 24.7f, 26.2f, 27.7f, 29.1f, 30.6f, 32.0f, 33.4f, 34.8f, 36.2f };
        readonly public static float[] χSqr_a0_025 = new float[] { 5.00000f, 7.400f, 9.400f, 11.10f, 12.80f, 14.40f, 16.0f, 17.5f, 19.0f, 20.5f, 21.9f, 23.3f, 24.7f, 26.1f, 27.5f, 28.8f, 30.2f, 31.5f, 32.9f };
        readonly public static float[] χSqr_a0_050 = new float[] { 3.80000f, 6.000f, 7.800f, 9.500f, 11.10f, 12.60f, 14.1f, 15.5f, 16.9f, 18.3f, 19.7f, 21.0f, 22.4f, 23.7f, 25.0f, 26.3f, 27.6f, 28.9f, 30.1f };
        readonly public static float[] χSqr_a0_950 = new float[] { 0.00390f, 0.103f, 0.352f, 0.711f, 1.150f, 1.640f, 2.17f, 2.73f, 3.33f, 3.94f, 4.57f, 5.23f, 5.89f, 6.57f, 7.26f, 7.96f, 8.67f, 9.39f, 10.1f };
        readonly public static float[] χSqr_a0_975 = new float[] { 0.00098f, 0.051f, 0.216f, 0.484f, 0.831f, 1.240f, 1.69f, 2.18f, 2.70f, 3.25f, 3.82f, 4.40f, 5.01f, 5.63f, 6.26f, 6.91f, 7.56f, 8.23f, 8.91f };
        readonly public static float[] χSqr_a0_990 = new float[] { 0.00016f, 0.020f, 0.115f, 0.297f, 0.554f, 0.872f, 1.24f, 1.65f, 2.09f, 2.56f, 3.05f, 3.57f, 4.11f, 4.66f, 5.23f, 5.81f, 6.41f, 7.01f, 7.63f };

        readonly public static float[] Student_a0_10 = new float[] { 12.7f, 4.30f, 3.18f, 2.78f, 2.57f, 2.45f, 2.36f, 2.31f, 2.26f, 2.23f, 2.20f, 2.18f, 2.16f, 2.14f, 2.13f, 2.12f, 2.11f, 2.10f, 2.09f, 2.09f, 2.08f, 2.07f, 2.07f, 2.06f, 2.06f, 2.06f, 2.05f, 2.05f, 2.05f, 2.04f, 2.02f, 2.00f, 1.98f, 1.96f };
        readonly public static float[] Student_a0_05 = new float[] { 6.31f, 2.92f, 2.35f, 2.13f, 2.01f, 1.94f, 1.89f, 1.86f, 1.83f, 1.81f, 1.80f, 1.78f, 1.77f, 1.76f, 1.75f, 1.75f, 1.74f, 1.73f, 1.73f, 1.73f, 1.72f, 1.72f, 1.71f, 1.71f, 1.71f, 1.71f, 1.71f, 1.70f, 1.70f, 1.70f, 1.68f, 1.67f, 1.66f, 1.64f };

        #endregion

        #region MyRandom-supporting constants
        const UInt32 _rndA = 1664525;
        const UInt32 _rndC = 1013904223;
        const UInt64 _rndMax = (UInt64)(UInt32.MaxValue) + 1;
        //  const int _rndMax = int.MaxValue;
        static UInt32 _rndSeed = 0;
        // static Random rnd;

        #endregion

        // фу кака
        private static double min, max;

        public static double[] RangesOf(double[] data)
        {
            double[] ranges = new double[data.Length];

            int[] indices = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
                indices[i] = i;

            Array.Sort(data, indices);

            double curr, prev;

            int seriaLen = 0, sumPos = 0;

            int pos = 0;
            while (pos < data.Length)
            {
                curr = data[pos];

                do
                {
                    seriaLen++;
                    sumPos += pos + seriaLen;
                    prev = curr;
                    if (pos + 1 + seriaLen > data.Length)
                        break;
                    curr = data[pos + seriaLen];
                }
                while ((prev == curr) && (pos < data.Length));

                for (int i = 0; i < seriaLen; i++)
                {
                    ranges[pos + i] = (double)sumPos / (double)seriaLen;
                }

                pos += seriaLen;
                seriaLen = 0;
                sumPos = 0;
            }

            double[] result = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
                result[indices[i]] = ranges[i];
            return result;
        }
        public static double[][] RangesOf(double[][] data)
        {
            // linearize, then call RangesOf, then make table up back
            double[] rawdata = RangesOf(Linearize(data));

            double[][] result = new double[data.GetLength(0)][];

            int t = 0;

            for (int i = 0; i < data.GetLength(0); i++)
            {
                result[i] = new double[data[i].GetLength(0)];
                for (int j = 0; j < data[i].GetLength(0); j++)
                    result[i][j] = rawdata[t++];
            }
            return result;
        }
        public static void Groups(double[] data, out int[] counts, out double[] values)
        {
            int totalGroups = 0;
            counts = new int[data.Length];
            values = new double[data.Length];
            Array.Sort<double>(data);

            double curr, prev;

            int seriaLen = 0;

            int pos = 0;
            while (pos < data.Length)
            {
                curr = data[pos];

                do
                {
                    seriaLen++;
                    prev = curr;
                    if (pos + 1 + seriaLen > data.Length)
                        break;
                    curr = data[pos + seriaLen];
                }
                while ((prev == curr) && (pos < data.Length));

                totalGroups++;

                counts[totalGroups - 1] = seriaLen;
                values[totalGroups - 1] = data[pos];

                pos += seriaLen;
                seriaLen = 0;
            }

            Array.Resize<int>(ref counts, totalGroups);
            Array.Resize<double>(ref values, totalGroups);
        }
        public static int ToIntervals(double[] data,
            out double[] rangesLeft, out double[] rangesRight, out int[] Counts)
        {
            int k = 1 + (int)(Math.Ceiling(10f / 3f * Math.Log10(data.Length)));

            rangesLeft = new double[k];
            rangesRight = new double[k];
            Counts = new int[k];

            min = max = data[0];
            Array.ForEach<double>(data, FindMin);
            Array.ForEach<double>(data, FindMax);

            double step = (max - min) / k;

            double x = min;//x <= max
            for (int i = 0; i < k; i++, x += step)
            {
                rangesLeft[i] = x;
                rangesRight[i] = x + step;
            }

            foreach (double val in data)
            {
                int pos = (int)(Math.Floor((val - min) / step));
                if (pos == k)
                    pos--;
                Counts[pos]++;
            }

            return k;
        }

        protected static double[] Linearize(double[][] data)
        {
            //int N = 0;
            List<double> rawdata = new List<double>();
            //IEnumerator enumer = data.GetEnumerator();
            foreach (double[] row in data)
                foreach (double number in row)
                    rawdata.Add(number);
            //for (int i = 0; i < data.GetLength(0); i++)
            //    for (int j = 0; j < data.GetLength(1); j++, N++)
            //        rawdata[i * data.GetLength(1) + j] = data[i][j];

            //Array.Resize<double>(ref rawdata, N);
            return rawdata.ToArray();
        }
        private static void FindMin(double value)
        {
            if (value < min)
                min = value;
        }
        private static void FindMax(double value)
        {
            if (value > max)
                max = value;
        }

        public static double FindMin(double[] data)
        {
            min = data[0];
            Array.ForEach<double>(data, FindMin);
            return min;
        }
        public static double FindMax(double[] data)
        {
            max = data[0];
            Array.ForEach<double>(data, FindMax);
            return max;
        }
        public static double Srednee(double[] data)
        {
            double sum = 0;
            foreach (double val in data)
                sum += val;

            return sum / data.Length;
        }
        public static double Dispersion(double[] data)
        {
            double sumSqr = 0;
            double x0 = Srednee(data);

            foreach (double val in data)
            {
                sumSqr += (val - x0) * (val - x0);
            }

            return sumSqr / (data.Length - 1);
        }
        public static double Excess(double[] data)
        {
            double x0 = Srednee(data);
            double sumNumerator = 0, sumDenominator = 0;
            foreach (double val in data)
            {
                double diff2 = (x0 - val) * (x0 - val);
                sumNumerator += diff2 * diff2;
                sumDenominator += diff2;
            }

            double Numerator = sumNumerator / (data.Length);
            double Denominator = sumDenominator / (data.Length)
                * sumDenominator / (data.Length);

            return Numerator / Denominator - 3;
        }
        public static double Asymetry(double[] data)
        {
            double x0 = Srednee(data);
            double sumNumerator = 0, sumDenominator = 0;
            foreach (double val in data)
            {
                double diff = x0 - val;
                sumNumerator += diff * diff * diff;
                sumDenominator += diff * diff;
            }

            double Numerator = sumNumerator / (data.Length);
            double Denominator = sumDenominator / (data.Length - 1);
            Denominator = Math.Pow(Denominator, 1.5);

            return Numerator / Denominator;
        }
        public static double Correlation(double[] dataX, double[] dataY)
        {
            if (dataX.Length != dataY.Length)
                throw new ArithmeticException("Размеры выборок не совпадают");

            double x0 = Srednee(dataX);
            double y0 = Srednee(dataY);

            double numSum = 0, denomSum = 0;

            for (int i = 0; i < dataX.Length; i++)
            {
                double diff = (dataX[i] - x0) * (dataY[i] - y0);
                numSum += diff;
                denomSum += diff * diff;
            }

            return numSum / Math.Sqrt(denomSum);
        }

        public static double[] EmpVals(double[] data)
        {
            double[] lX, rX;
            int[] nX;
            StatisticsProcessor.ToIntervals(data, out lX, out rX, out nX);

            double[] res = new double[nX.Length];

            double sum = 0;

            for (int i = 0; i < nX.Length; i++)
            {
                sum += nX[i];
                res[i] = sum / data.Length;
            }

            return res;
        }

        public static UInt32 GetMyRand()
        {
            return GetMyRand(_rndSeed);
        }
        public static UInt32 GetMyRand(UInt32 seed)
        {
            //if (rnd == null)
            //{
            //    unchecked
            //    {
            //        rnd = new Random((int)seed);
            //    }
            //}

            //return (uint) rnd.Next(0,_rndMax);

            return _rndSeed = (UInt32)((seed * _rndA + _rndC) % _rndMax);
        }

        public static double[] GenerateRavnom(double a, double b, int n)
        {
            double[] data = new double[n];
            if (_rndSeed == 0)
                GetMyRand((UInt32)(DateTime.Now.Ticks % Int32.MaxValue));

            for (int i = 0; i < n; i++)
            {
                double ξ = (double)GetMyRand() / _rndMax;
                data[i] = a + (b - a) * ξ;
            }
            return data;
        }
        public static double[] GenerateExponential(double λ, int n)
        {
            double[] data = new double[n];
            if (_rndSeed == 0)
                GetMyRand((UInt32)(DateTime.Now.Ticks % Int32.MaxValue));

            for (int i = 0; i < n; i++)
            {
                double ξ = (double)GetMyRand() / _rndMax;
                data[i] = Math.Log(1 - ξ) / λ;
            }
            return data;
        }
        public static double[] GenerateNormal(double a, double σ, int n)
        {
            double[] data = new double[n];
            if (_rndSeed == 0)
                GetMyRand((UInt32)(DateTime.Now.Ticks % Int32.MaxValue));

            for (int i = 1; i <= n; i++)
            {
                double sumKsiMinusHalf = 0;
                for (int j = 0; j < i; j++)
                    sumKsiMinusHalf += (double)GetMyRand() / _rndMax - 0.5;

                data[i - 1] = Math.Sqrt(12.0 / i) * sumKsiMinusHalf * σ + a;
            }
            return data;
        }
        public static double[] GenerateNormal1(double a, double σ, int n)
        {
            double[] data = new double[n];
            if (_rndSeed == 0)
                GetMyRand((UInt32)(DateTime.Now.Ticks % Int32.MaxValue));

            for (int i = 0; i < n; i++)
            {
                double ξ1 = (double)GetMyRand() / _rndMax;
                double ξ2 = (double)GetMyRand() / _rndMax;
                data[i] = Math.Sqrt(-2.0 * Math.Log(ξ1)) * Math.Sin(2.0 * Math.PI * ξ2) * σ + a;
            }
            return data;
        }
        public static double[] GenerateNormal2(double a, double σ, int n)
        {
            double[] data = new double[n];
            if (_rndSeed == 0)
                GetMyRand((UInt32)(DateTime.Now.Ticks % Int32.MaxValue));

            for (int i = 0; i < n; i++)
            {
                double ξ1 = (double)GetMyRand() / _rndMax;
                double ξ2 = (double)GetMyRand() / _rndMax;
                data[i] = Math.Sqrt(-2.0 * Math.Log(ξ1)) * Math.Cos(2.0 * Math.PI * ξ2) * σ + a;
            }
            return data;
        }

        public static double GetMediana(double[] data)
        {
            double[] sorted = (double[])(data.Clone());
            Array.Sort<double>(sorted);

            if (sorted.Length % 2 == 1)
                return sorted[(int)(sorted.Length) / 2];
            else
                return (sorted[sorted.Length / 2 - 1] +
                    sorted[sorted.Length / 2]) / 2.0;
        }

        private static char _test1(double a, double b)
        {
            return a < b ? '-' : (a > b ? '+' : '=');
        }
        public static bool CheckRndSeries(double[] data, out char[] signs, out double med, out int v, out int t)
        {
            signs = new char[data.Length];

            med = GetMediana(data);

            t = 1;
            v = 0;
            int len = 1;

            char sign = 'z';
            for (int i = 0; i < data.Length; i++)
            {
                char test = _test1(data[i], med);

                if (sign == test)
                    len++;

                else
                {
                    if (test == '=')
                    {
                        signs[i] = test;
                        continue;
                    }

                    v++;
                    if (t < len)
                        t = len;
                    len = 1;
                }
                signs[i] = sign = test;
            }

            int n = data.Length;
            return
                v > 0.5f * (n + 1 - 1.96f * Math.Sqrt(n - 1)) &&
                t < Math.Log(n + 1);
        }
        public static bool CheckRndUpDownSeries(double[] data, out char[] signs, out int v, out int t)
        {
            signs = new char[data.Length];

            t = 1;
            v = 0;
            int len = 1;

            char sign = 'z';
            signs[0] = ' ';

            for (int i = 1; i < data.Length; i++)
            {
                char test = _test1(data[i], data[i - 1]);

                if (sign == test)
                    len++;

                else
                {
                    if (test == '=')
                    {
                        signs[i] = test;
                        continue;
                    }

                    v++;
                    if (t < len)
                        t = len;
                    len = 1;
                }
                signs[i] = sign = test;
            }

            int n = data.Length;
            bool t_res;

            if (n <= 26)
                t_res = t <= 5;
            if (n <= 153)
                t_res = t <= 6;
            else
                t_res = t <= 7;

            return v > 1f / 3 * (2 * n + 1) - 1.96f * Math.Sqrt((16 * n - 20) / 90f) && t_res;
        }
        public static double[] CheckOutstanding(double[] data, out double[] clearData, float alpha)
        {
            List<double> dataList = new List<double>(data);
            List<double> trashList = new List<double>();
            bool changes;
            do
            {
                changes = false;
                data = dataList.ToArray();
                double mean = StatisticsProcessor.Srednee(data);
                double S = Math.Sqrt(StatisticsProcessor.Dispersion(data));

                double Xmax = StatisticsProcessor.FindMax(data);
                double TnMax = (Xmax - mean) / S;
                if (TnMax > TTable(alpha, (uint)(data.Length)))
                {
                    changes = true;
                    dataList.Remove(Xmax);
                    trashList.Add(Xmax);
                }

                double Xmin = StatisticsProcessor.FindMin(data);
                double TnMin = (mean - Xmin) / S;
                if (TnMin > TTable(alpha, (uint)(data.Length)))
                {
                    changes = true;
                    dataList.Remove(Xmin);
                    trashList.Add(Xmin);
                }
            }
            while (changes);

            clearData = dataList.ToArray();
            return trashList.Count > 0 ? trashList.ToArray() : null;
        }

        public enum Zakon
        {
            Ravnom,
            Exponential,
            Normal
        }

        public static bool CheckZn(double[] data, Zakon zn, float alpha)
        {
            double[] ΔLeft, ΔRight;
            int[] v;
            int k = StatisticsProcessor.ToIntervals(data, out ΔLeft, out ΔRight, out v);

            double σв = Math.Sqrt(StatisticsProcessor.Dispersion(data));
            double mean = StatisticsProcessor.Srednee(data);

            double[] p = new double[k];

            for (int i = 0; i < k; i++)
            {
                double x1 = ΔLeft[i];
                double x2 = ΔRight[i];

                switch (zn)
                {
                    case Zakon.Ravnom:
                        p[i] = FxRavnom(x2, mean - 1.732 * σв, mean + 1.732 * σв) -
                            FxRavnom(x1, mean - 1.732 * σв, mean + 1.732 * σв);
                        break;
                    case Zakon.Exponential:
                        p[i] = FxExponential(x2, 1f / mean) - FxExponential(x1, 1f / mean);
                        break;
                    case Zakon.Normal:
                        p[i] = FxNormal((x2 - mean) / σв) - FxNormal((x1 - mean) / σв);
                        break;
                }
            }

            double χSqr = 0;
            for (int i = 0; i < k; i++)
            {
                χSqr += (v[i] - data.Length * p[i]) * (v[i] - data.Length * p[i]) / data.Length / p[i];
            }

            int s = 0;
            switch (zn)
            {
                case Zakon.Ravnom:
                    s = 2;
                    break;
                case Zakon.Exponential:
                    s = 1;
                    break;
                case Zakon.Normal:
                    s = 2;
                    break;
            }

            return χSqr < χSqrTable(alpha, (uint)(k - s - 1));
        }

        protected static double TTable(float α, uint k)
        {
            if (k == 0)
                throw new ArgumentOutOfRangeException("k==0, it's wrong.");

            if (α == 0.05f)
            {
                if (k > 120)
                    return Student_a0_05[34 - 1];
                if (k > 60)
                    return Student_a0_05[33 - 1];
                if (k > 40)
                    return Student_a0_05[32 - 1];
                if (k > 30)
                    return Student_a0_05[31 - 1];

                return Student_a0_05[k - 1];
            }

            //FormAskTableValue form = new FormAskTableValue(string.Format("Введите значение критической точки распределения Стьюдента (T) для α={0}, k={1}", α, k));

            //if (form.ShowDialog() == DialogResult.OK)
            //    return form.Value;

            throw new ExceptionTableValuesGet("Error occured while retrieving table-values (Student distr.)");
        }
        protected static double χSqrTable(float α, uint k)
        {
            if (k > 0 && k < 20)
            {
                if (α == 0.01f)
                    return χSqr_a0_010[k - 1];
                if (α == 0.025f)
                    return χSqr_a0_025[k - 1];
                if (α == 0.05f)
                    return χSqr_a0_050[k - 1];
                if (α == 0.95f)
                    return χSqr_a0_950[k - 1];
                if (α == 0.975f)
                    return χSqr_a0_975[k - 1];
                if (α == 0.99f)
                    return χSqr_a0_990[k - 1];
            }
            //string prompt = string.Format("Введите значение критической точки распределения χ² для α={0}, k={1}.", α, k);
            //FormAskTableValue form = new FormAskTableValue(prompt);
            //if (form.ShowDialog() != DialogResult.OK)
            //{
                throw new ExceptionTableValuesGet("Error occured while retrieving table-values (χ² distr.)");
            //}
            //return form.Value;
        }

        public static double FxRavnom(double x, double a, double b)
        {
            if (a > b)
                throw new ArgumentException("Argument 'a' has to be less than 'b'");
            if (x < a)
                return 0;
            if (x <= b)
                return (x - a) / (b - a);
            return 1;
        }
        public static double FxExponential(double x, double λ)
        {
            return 1 - System.Math.Exp(-λ * x);
        }
        protected static double fxNormalMultipledByσAndSqrt2Pi(double x/*, double a, double σ*/)
        {
            //return Math.Exp(-(x - a) * (x - a) / 2 / σ / σ);
            return Math.Exp(-x * x / 2);
        }
        public static double FxNormal(double x/*, double a, double σ*/)
        {
            double sign = 1;

            if (x < 0)
            {
                x = -x;
                sign = -1;
            }
            if (x > 5f)
                return 0.5f;
            // Simpson-integration from 0 to x
            int n = 1000;

            n = n + n % 2;
            double h = x / n;
            n /= 2;

            double Sum = fxNormalMultipledByσAndSqrt2Pi(0/*, a, σ*/) +
                fxNormalMultipledByσAndSqrt2Pi(x/*, a, σ*/) +
                4 * fxNormalMultipledByσAndSqrt2Pi(x - h/*, a, σ*/);

            for (int i = 2; i < 2 * n; i += 2)
            {
                // even
                Sum += 2.0 * fxNormalMultipledByσAndSqrt2Pi(i * h/*, a, σ*/);
                // odd
                Sum += 4.0 * fxNormalMultipledByσAndSqrt2Pi(i * h - h/*, a, σ*/);
            }

            return sign * Sum * h / 3.0 /*/ σ*/ / Math.Sqrt(2 * Math.PI);
        }

        protected static double Statisitc_KraskalaWales(double[][] data)
        {
            double[][] r = RangesOf(data);
            double[] Rj = new double[data.GetLength(0)];
            double[] rj = new double[data.GetLength(0)];
            int N = 0;

            for (int i = 0; i < data.GetLength(0); i++)
            {
                double s_ranges = 0;
                for (int j = 0; j < data[i].Length; j++, N++)
                    s_ranges += r[i][j];
                Rj[i] = s_ranges;
                rj[i] = Rj[i] / data[i].Length;
            }

            double H = 0;
            for (int i = 0; i < data.GetLength(0); i++)
                H += data[i].Length * (rj[i] - (N + 1) / 2f) * (rj[i] - (N + 1) / 2f);
            H *= 12f / N / (N + 1);

            return H;
        }

        /// <summary>
        /// Uses statictic by Krasksla - Wales to analyse data set.
        /// H0: factor does not affect response
        /// </summary>
        /// <param name="data">Experiments are in rows</param>
        public static bool Analysis_Range_OneFactor(double[][] data, float alpha)
        {
            return Statisitc_KraskalaWales(data) < χSqrTable(alpha, (uint)(data.GetLength(0) - 1));
        }
        public static bool Analysis_Range_OneFactor_Modifed(double[][] data, float alpha)
        {
            int tj = 1;
            double sum = 0;

            double[] raw = Linearize(data);
            int N = raw.Length;

            for (int i = 1; i < N; i++)
                if (raw[i] == raw[i - 1])
                {
                    tj++;
                }
                else
                {
                    sum += tj * tj * (tj - 1);
                    tj = 1;
                }

            double H = Statisitc_KraskalaWales(data) / (1f - sum / (N * N * (N - 1)));

            return H < χSqrTable(alpha, (uint)(data.GetLength(0)));
        }
    }
}
