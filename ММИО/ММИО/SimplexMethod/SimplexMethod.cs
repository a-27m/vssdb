using System;
using System.Collections.Generic;
using System.Text;
using Fractions;

namespace SimplexMethod
{
    public delegate void DebugSimplexTableHandler(Fraction[,] table);

    public class SimplexSolver
    {
        int n = 0;

        List<Fraction[]> la;
        Fraction[] m_c;

        public event DebugSimplexTableHandler DebugNewSimplexTable;

        protected void OnNewSimplexTable(Fraction[,] table)
        {
            if (DebugNewSimplexTable != null)
                DebugNewSimplexTable(table);
        }

        public static void GGaussProcess(ref Fraction[,] a, uint Row, uint Col)
        {
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            Fraction x = a[Row, Col];
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

        public void AddLimtation(Fraction[] a, short sign, Fraction b)
        {
            if (Math.Abs(sign) > 1)
                throw new ArgumentOutOfRangeException("sign", "Sign has to be -1 or 0 or 1.");

            if (la == null)
                la = new List<Fraction[]>();

            Fraction[] tmp;
            n = (a.Length > n ? a.Length : n);

            if (sign != 0)
            {
                tmp = new Fraction[n + 2];
                for (int k = a.Length - 1; k < n + 2 - 1; k++)
                    tmp[k] = 0;
                tmp[n + 2 - 1] = -sign;
                n++;
            }
            else
            {
                tmp = new Fraction[n + 1];
            }

            a.CopyTo(tmp, 1);
            tmp[0] = b;
            la.Add(tmp);
        }

        public void RemoveLimitation(uint index)
        {
            la.RemoveAt((int)index);
            n = 0;
            foreach (Fraction[] cond in la)
            {
                if (n < cond.Length)
                    n = cond.Length;
            }
        }

        //void SetLimtations(double[,] a, double b)
        //{
        //    throw new Exception("This method is not implemented yet");
        //}

        public void SetTargetFunctionCoefficients(Fraction[] c)
        {
            if (c.Length > n)
                throw new ArgumentException("Array 'c' is too long");
            m_c = c;
        }

        public Fraction[] Solve()
        {
            // looking for basis vectors in out limitations
            int[] basisIndices = FindBasis(la);
            if (basisIndices.Length < n)
                /* add artifical basis*/;


            int m = la.Count;
            // create new simplex-table
            Fraction[,] simplexTab = new Fraction[m + 1 + 1, n + 1];

            // fill table with limitations in List<Fraction[]> la
            // and the coefficients m_c
            for (int j = 0; j < m_c.Length; j++)
                simplexTab[0, j + 1] = m_c[j];
           for (int j = 0; j < m_c.Length; j++)
                simplexTab[0, j + 1] = m_c[j];

            List<Fraction[]>.Enumerator enumer = la.GetEnumerator();
            for (int i = 1; enumer.MoveNext(); i++)
            {
                int j = 0;
                for (; j < enumer.Current.Length; j++)
                    simplexTab[i, j] = enumer.Current[j];
                for (; j <= n; j++)
                    simplexTab[i, j] = new Fraction(0);
            }

            Fraction[] solution = new Fraction[n];
            for (int i = 0; i < n; solution[i++] = new Fraction())
                ;
            return solution;
        }

        private delegate bool MyDel(int i, int j);

        protected int[] FindBasis(List<Fraction[]> conds)
        {
            MyDel del1 = new MyDel(delegate(int i, int j)
            {
                int count0 = 0;
                List<Fraction[]>.Enumerator enumerB;
                enumerB = conds.GetEnumerator();
                for (int ik = 1; enumerB.MoveNext(); ik++)
                {
                    if (ik == i)
                        continue;
                    if (j < enumerB.Current.Length)
                    {
                        if (enumerB.Current[j] == (Fraction)0)
                            count0++;
                    }
                    else
                        count0++;
                }
                enumerB.Dispose();

                return count0 == (n - 1);
            });

            List<int> li = new List<int>();

            List<Fraction[]>.Enumerator enumerA = conds.GetEnumerator();
            for (int i = 1; enumerA.MoveNext(); i++)
                for (int j = 0; j < enumerA.Current.Length; j++)
                    if (enumerA.Current[j] == new Fraction(1,1))
                        if (del1(i, j))
                            li.Add(j);
            return li.ToArray();
        }
    }
}
