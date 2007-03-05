using System;
using System.Collections.Generic;
using System.Text;
using Fractions;

namespace SimplexMethod
{
    public delegate void DebugSimplexTableHandler(int[] basis, Fraction[] c, Fraction[,] table);

    public class SimplexSolver
    {
        int n = 0;

        public static Fraction M = new Fraction(0, 1000000, 1);

        List<Fraction[]> la;
        Fraction[] m_c;

        public event DebugSimplexTableHandler DebugNewSimplexTable;

        protected void OnNewSimplexTable(int[] basis, Fraction[] c, Fraction[,] table)
        {
            if (DebugNewSimplexTable != null)
                DebugNewSimplexTable(basis, c, table);
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
                n++;
                tmp = new Fraction[n + 1];
                for (int k = a.Length - 1; k < n; k++)
                    tmp[k] = 0;
                tmp[n] = -sign;
            }
            else
            {
                tmp = new Fraction[n + 1];
            }

            tmp[0] = b;
            a.CopyTo(tmp, 1);
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
            int m = la.Count;
            int k = 0;
            // looking for basis vectors in out limitations
            int[] basisIndices = FindBasis(la);

            int oldMcLen = m_c.Length;
            Array.Resize<Fraction>(ref m_c, n);
            for (int j = oldMcLen; j < n; m_c[j++] = 0)
                ;

            if (basisIndices.Length < m)
            {
                // add art-bases
                int b = basisIndices.Length;
                k = m - b;
                Array.Resize<Fraction>(ref m_c, n + k);
                Array.Resize<int>(ref basisIndices, b + k);
                for (int j = n; j < n + k; m_c[j++] = -M)
                    basisIndices[b + j - n] = j + 1;

                n += k;
            }

            // create new simplex-table
            Fraction[,] simplexTab = new Fraction[m + 1, n + 1];

            ////// fill table with the coefficients m_c …
            //// for (int j = 0; j < m_c.Length; j++)
            ////    simplexTab[0, j + 1] = m_c[j];

            // …and limitations in List<Fraction[]> la
            List<Fraction[]>.Enumerator enumer = la.GetEnumerator();
            for (int i = 0; enumer.MoveNext(); i++)
            {
                int j = 0;
                for (; j < enumer.Current.Length; j++)
                    simplexTab[i, j] = enumer.Current[j];
                for (; j <= n; j++)
                    simplexTab[i, j] = 0;
            }

            // restore art. 1s in s-table
            for (int i = 0; i <k; i++)
                simplexTab[i, basisIndices[basisIndices.Length - k + i]] = 1;

            // fill m+1st row with deltas
            for (int j = 1; j <= n; j++)
            {
                Fraction delta = 0;
                for (int t = 0; t < m; t++)
                    delta += m_c[basisIndices[t]-1] * simplexTab[t, j];
                simplexTab[m, j] = delta - m_c[j - 1];
            }

            OnNewSimplexTable(basisIndices, m_c, simplexTab);

            Fraction[] solution = new Fraction[n];
            for (int i = 0; i < n; solution[i++] = 0)
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

                return count0 == (conds.Count - 1);
            });

            List<int> li = new List<int>();

            List<Fraction[]>.Enumerator enumerA = conds.GetEnumerator();
            for (int i = 1; enumerA.MoveNext(); i++)
                for (int j = 0; j < enumerA.Current.Length; j++)
                    if (enumerA.Current[j] == new Fraction(1, 1))
                        if (del1(i, j))
                        {
                            li.Add(j);
                            break;
                        }
            return li.ToArray();
        }
    }
}
