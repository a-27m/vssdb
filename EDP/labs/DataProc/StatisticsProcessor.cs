using System;
using System.Collections.Generic;
using System.Text;

namespace DataProc
{
    public class StatisticsProcessor
    {
        const UInt32 _rndA = 1664525;
        const UInt32 _rndC = 1013904223;
        const UInt64 _rndMax = (UInt64)(UInt32.MaxValue) + 1;
        static UInt32 _rndSeed = 0;

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

        public static void Groups(double[] data,
             out int[] counts,
             out double[] values)
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

        public static void ToIntervals(double[] data,
           out double[] rangesLeft,
           out double[] rangesRight,
           out int[] Counts)
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
    }
}
