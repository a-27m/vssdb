using System;
using System.Collections.Generic;
using System.Text;

namespace SimplexMethod
{
    public class SimplexSolver
    {
        int n = 0;

        List<double[]> la;
        double[] m_c;

        public static void GGaussProcess(ref double[,] a, uint Row, uint Col)
        {
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            double x = a[Row, Col];
            for (int j = 0; j < n; j++)
                a[Row, j] /= x;

            for (int i = 0; i < m; i++)
            {
                if (i == Row)
                    continue;
                x = a[i, Col];
                for (int j = 0; j < n; j++)
                    a[i, j] += -a[Row, j] * x;
            }
        }

        public void AddLimtation(double[] a, short sign, double b)
        {
            if (sign != 1 && sign != 0 && sign != -1)
                throw new ArgumentOutOfRangeException("sign", "Sign has to be -1 or 0 or 1.");

            if (la == null)
                la = new List<double[]>();

            double[] tmp;

            if (sign != 0)
            {
                tmp = new double[n + 2];
                a[n] = sign;
                n++;
            }
            else
            {
                tmp = new double[n + 1];
                n = (a.Length > n ? a.Length : n);
            }

            a.CopyTo(tmp, 1);
            tmp[0] = b;
            la.Add(a);
    }

        public void RemoveLimitation(uint index)
        {
            la.RemoveAt((int)index);
        }

        //void SetLimtations(double[,] a, double b)
        //{
        //    throw new Exception("This method is not implemented yet");
        //}

        void SetTargetFunctionCoefficients(double[] c)
        {
            if (c.Length > n)
                throw new ArgumentException("Array 'c' is too long");
            m_c = c;
        }

        double[] Solve()
        {
            double[,] simplexTab = new double[la.Count, n];
            int[] basisIndices = FindBasis(simplexTab);
            throw new Exception();
        }

        protected int[] FindBasis(double[,] tab)
        {
            int  n= tab.GetLength(0);
            int m =tab.GetLength(1);
            List<int> li = new List<int>();
            
            for (int j = 0; j < m; j++)
            {
                int count1 = 0;
                int count0 = 0;
                for (int i = 0; i < n; i++)
                {
                    if (tab[i, j] == (double)1)
                        count1++;
                    if (tab[i, j] == (double)0)
                        count0++;
                }

                if ((count0 == (n - 1)) && count1 == 1)
                    li.Add(j);
            }
            return li.ToArray();
        }
    }
}
