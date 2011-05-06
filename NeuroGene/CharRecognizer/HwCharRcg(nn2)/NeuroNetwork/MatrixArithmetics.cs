using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroNetwork
{
    public class MatrixArithmetics
    {
        static public double[] Add(double[] a, double[] b)
        {
            if (a == null || b == null) throw new ArgumentNullException();
            int n = a.Length;
            if (b.Length != n) throw new ArgumentException("Sizes do not match");
            double[] c = new double[n];
            for (int i = 0; i < n; i++) c[i] = a[i] + b[i];
            return c;
        }

        /// <summary>
        /// Calculates A - B
        /// </summary>
        static public double[] Minus(double[] a, double[] b)
        {
            if (a == null || b == null) throw new ArgumentNullException();
            int n = a.Length;
            if (b.Length != n) throw new ArgumentException("Sizes do not match");
            double[] c = new double[n];
            for (int i = 0; i < n; i++) c[i] = a[i] - b[i];
            return c;
        }

        static public double[] PairMult(double[] a, double[] b)
        {
            if (a == null || b == null) throw new ArgumentNullException();
            int n = a.Length;
            if (b.Length != n) throw new ArgumentException("Sizes do not match");
            double[] c = new double[n];
            for (int i = 0; i < n; i++) c[i] = a[i] * b[i];
            return c;
        }

        static public double Sum(double[] a)
        {
            double s = 0;
            foreach (double z in a) s += z;
            return s;
        }
    }
}