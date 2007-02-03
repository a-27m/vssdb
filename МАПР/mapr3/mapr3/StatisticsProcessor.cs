using System;
using System.Collections.Generic;
using System.Text;

namespace DataProc
{
    public class StatisticsProcessor
    {
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
            Array.Sort<double>(data);

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

            return ranges;
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

        //private static int FindCountBetween(double[] data, double x1, double x1)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        if ((data[i] > x1) && (data[i] < x2))
        //            sum++;
        //    }
        //}

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
            double x0 = Srednee(dataX);
            double y0 = Srednee(dataY);

            double numSum = 0, denomSum = 0;

            if (dataX.Length != dataY.Length)
                return Double.NaN;

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
        public static double[] CheckOutstanding(double[] data, out double[] clearData)
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
                if (TnMax > TTable(0.05))
                {
                    changes = true;
                    dataList.Remove(Xmax);
                    trashList.Add(Xmax);
                }

                double Xmin = StatisticsProcessor.FindMin(data);
                double TnMin = (mean - Xmin) / S;
                if (TnMin > TTable(0.05))
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

        public static bool CheckZn(double[] data, Zakon zn)
        {
            double[] ΔLeft, ΔRight;
            int[] v;
            int k = StatisticsProcessor.ToIntervals(data, out ΔLeft, out ΔRight, out v);

            double S = StatisticsProcessor.Dispersion(data);
            double mean = StatisticsProcessor.Srednee(data);

            double[] p = new double[k];

            for (int i = 0; i < k; i++)
            {
                double x;
                switch (zn)
                {
                    case Zakon.Ravnom:
                        break;
                    case Zakon.Exponential:
                        break;
                    case Zakon.Normal:
                        x = (ΔRight[i] - mean) / S;
                        p[i] = FxNormal(x);
                        x = (ΔLeft[i] - mean) / S;
                        p[i] -= FxNormal(x);
                        break;
                }
            }

            double χSqr = 0;
            for (int i = 0; i < k; i++)
            {
                χSqr += (v[i] - data.Length * p[i]) * (v[i] - data.Length * p[i]) / data.Length / p[i];
            }

            int s;
            switch (zn)
            {
                case Zakon.Ravnom:
                    break;
                case Zakon.Exponential:
                    break;
                case Zakon.Normal:
                    s = 2;
                    break;
                default:
                    break;
            }


            return false;
        }

        protected static double TTable(double α)
        {
            if (α == 0.05)
                return 1.96;
            else
                throw new NotImplementedException("Tables are not included yet. Only α=0.05 please.");
        }
        protected static double χSqrTable(double α, int k)
        {
            System.IO.StreamWriter f = new System.IO.StreamWriter("c:\\Хи-квадрат.txt", false);
            for (int x0 = 0; x0 < 100f; x0 += 1e-3f)
            {
                f.WriteLine(string.Format("{0};{1};", a, x));
            }

            //if (α == 0.05)
            //    return 1.96;
            //else
            //    throw new NotImplementedException("Tables are not included yet. Only α=0.05 please.");
        }

        private delegate double DoubleVectorFunction(double[] X);
        /// <param name="args">[0] - x, [1] - k</param>
        private static double χ2(double[] args)
        {
            double x = args[0];
            double k = (int)args[1];

            if (x <= 0)
                return 0;

            return Math.Exp(-x / 2.0) * Math.Exp(k / 2.0 - 1) /
                Math.Pow(2, k / 2.0) / Г(k / 2);
        }
        private static double Г(double k)
        {
            double fac = 1;

            if (k - (int)k == 0)
            {
                for (int i = 2; i <= k - 1; fac *= i++)
                    return fac;
            }
            else if (k - (int)k == 0.5)
            {
                fac = Math.Sqrt(Math.PI);
                for (int i = 0.5; i <= k - 1; fac *= i++)
                    return fac;
            }
            else
                throw new ArgumentException("Кушаю только целые или полуцелые k! Из принципов. Да.");
        }

        private double Simpson(double a, double b, int n, DoubleVectorFunction f, double[] args)
        {
            n = n + n % 2;
            double h = (b - a) / n;
            n /= 2;

            if (args == null)
                args = new double[] { 0 };

            args[0] = a;
            double Sum = f(args);
            args[0] = b;
            Sum += f(args);
            args[0] = 4 * f(b - h);
            Sum += f(args);

            for (int i = 2; i < 2 * n; i += 2)
            {
                // even
                args[0] = a + i * h;
                Sum += 2.0 * f(args);
                // odd
                args[0] = a + i * h - h;
                Sum += 4.0 * f(args);
            }

            return Sum * h / 3.0;
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

            return Sum * h / 3.0 /*/ σ*/ / Math.Sqrt(2 * Math.PI);
        }


    }
}
