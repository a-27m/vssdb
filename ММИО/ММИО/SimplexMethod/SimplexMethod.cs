using System;
using System.Collections.Generic;
using System.Text;
using Fractions;

namespace SimplexMethod
{
    public delegate void DebugSimplexTableHandler(int[] basis, Fraction[] c, Fraction[,] table);
    public delegate bool MyDelegate(int i, int j);

    public abstract class Solver
    {
        protected int n = 0, originalN = 0;
        public static Fraction M = new Fraction(0, 1000000, 1);
        protected List<Fraction[]> la;
        protected Fraction[] m_c;


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
                for (int i = 0; i < tmp.Length; tmp[i++] = 0)
                    ;
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
        public void SetTargetFunctionCoefficients(Fraction[] c)
        {
            if (c.Length > n)
                throw new ArgumentException("Array 'c' is too long");
            originalN = c.Length;
            m_c = c;
        }

        public abstract Fraction[] Solve();
        public static void GGaussProcess(ref Fraction[,] a, uint Row, uint Col)
        {
            int m = a.GetLength(0);
            int n = a.GetLength(1);

            Fraction x = a[Row, Col];
            if (x == 0)
                throw new InvalidOperationException("Specifed element is zero!");

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
    }

    public class SimplexSolver : Solver
    {
        public event DebugSimplexTableHandler DebugNewSimplexTable;

        protected void OnNewSimplexTable(int[] basis, Fraction[] c, Fraction[,] table)
        {
            if (DebugNewSimplexTable != null)
                DebugNewSimplexTable(basis, c, table);
        }

        public override Fraction[]  Solve()
{
            int m = la.Count;
            int k = 0;

            // looking for basis vectors in out limitations
            int[] basisIndicesI;
            int[] basisIndicesJ = FindBasis(la, out basisIndicesI);

            int oldMcLen = m_c.Length;
            Array.Resize<Fraction>(ref m_c, n);
            for (int j = oldMcLen; j < n; j++)
                m_c[j] = 0;

            int b = basisIndicesJ.Length;

            // add art-bases
            if (basisIndicesJ.Length < m)
            {
                k = m - b;

                Array.Resize<Fraction>(ref m_c, n + k);

                Array.Resize<int>(ref basisIndicesI, m);
                Array.Resize<int>(ref basisIndicesJ, m);

                for (int j = n; j < n + k; m_c[j++] = -M)
                    basisIndicesJ[b + j - n] = j + 1;

                int t = 0;
                for (int i = 0; i < m; i++)
                {
                    bool rowHasBasis = false;
                    for (int I = 0; I < b; I++)
                        if (basisIndicesI[I] == i + 1)
                        // there is some basis, no art.needed
                        {
                            rowHasBasis = true;
                            break;
                        }
                    if (!rowHasBasis)
                        basisIndicesI[b + t++] = i + 1;
                }
                n += k;
            }

            // create new simplex-table
            Fraction[,] simplexTab = new Fraction[m + 1, n + 1];

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

            // restore art. 1s in the s-table
            for (int i = b; i < m; i++)
                simplexTab[basisIndicesI[i] - 1, basisIndicesJ[i]] = 1;

            // fill m+1st row with deltas
            simplexTab[m, 0] = 0;
            for (int t = 0; t < m; t++)
                simplexTab[m, 0] += m_c[basisIndicesJ[t] - 1] * simplexTab[t, 0];

            for (int j = 1; j <= n; j++)
            {
                Fraction delta = 0;
                for (int t = 0; t < m; t++)
                    delta += m_c[basisIndicesJ[t] - 1] * simplexTab[t, j];
                simplexTab[m, j] = delta - m_c[j - 1];
            }

            //OnNewSimplexTable(basisIndicesJ, m_c, simplexTab);

            // пока есть отрицательные оценки, вводить в базис новый вектор.
            int iterationsCount = 0;
            bool haveANegativeDelta = true;
            while (iterationsCount < m + 2)
            {
                OnNewSimplexTable(basisIndicesJ, m_c, simplexTab);

                iterationsCount++;

                List<int> negativeColumns = new List<int>(CheckMPlusOneRow(simplexTab));

                if (negativeColumns != null)
                    haveANegativeDelta = negativeColumns.Count > 0;
                else
                    haveANegativeDelta = false;

                // its awefull, i know
                if (!haveANegativeDelta)
                    break;

                int i, j;
                if (FindBestNewVector(simplexTab, negativeColumns.ToArray(), out i, out j))
                {
                    Solver.GGaussProcess(ref simplexTab, (uint)i, (uint)j);

                    // fix basis changes
                    basisIndicesI[i] = i + 1;
                    basisIndicesJ[i] = j;


                    // fill m+1st row with deltas
                    simplexTab[m, 0] = 0;
                    for (int t = 0; t < m; t++)
                        simplexTab[m, 0] += m_c[basisIndicesJ[t] - 1] * simplexTab[t, 0];

                    for (j = 1; j <= n; j++)
                    {
                        Fraction delta = 0;
                        for (int t = 0; t < m; t++)
                            delta += m_c[basisIndicesJ[t] - 1] * simplexTab[t, j];
                        simplexTab[m, j] = delta - m_c[j - 1];
                    }
                }
                else
                    break;
            }

            Fraction[] solution;
            if (haveANegativeDelta)
            {
                solution = new Fraction[originalN];
                for (int i = 0; i < originalN; solution[i++] = -M)
                    ;
                return solution;
            }
            else
            {
                solution = new Fraction[originalN];
                for (int i = 0; i < originalN; solution[i++] = 0)
                    ;
                for (int j = 0; j < basisIndicesJ.Length; j++)
                {
                    int index = basisIndicesJ[j] - 1;
                    if (index <= originalN)
                        solution[index] = simplexTab[j, 0];
                }
                
            }
            return solution;

        }

        protected int[] FindBasis(List<Fraction[]> conds, out int[] ii)
        {
            MyDelegate IsE_Vector = new MyDelegate(delegate(int i, int j)
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
            List<int> lj = new List<int>();

            List<Fraction[]>.Enumerator enumerA = conds.GetEnumerator();
            for (int i = 1; enumerA.MoveNext(); i++)
                for (int j = 0; j < enumerA.Current.Length; j++)
                    if (enumerA.Current[j] == new Fraction(1, 1))
                        if (IsE_Vector(i, j))
                        {
                            li.Add(i);
                            lj.Add(j);
                            break;
                        }
            ii = li.ToArray();
            return lj.ToArray();
        }

        private IEnumerable<int> CheckMPlusOneRow(Fraction[,] simplexTab)
        {
            int m1 = simplexTab.GetLength(0) - 1;
            for (int j = 1; j < simplexTab.GetLength(1); j++)
                if (simplexTab[m1, j] < 0)
                    yield return j;
            yield break;
        }

        private bool FindBestNewVector(Fraction[,] simplexTab, int[] negInds, out int row, out int col)
        {
            // teta = min(xi/xij)
            // delta-F = -delta*teta;

            row = -1;
            col = -1;
            int m = simplexTab.GetLength(0);
            decimal[] θ = new decimal[negInds.Length];
            int[] iθ = new int[negInds.Length];
            decimal deltaFmax = -1;

            // enumerate columns
            for (int k = 0; k < negInds.GetLength(0); k++)
            {
                θ[k] = decimal.MaxValue;
                for (int i = 0; i < m - 1; i++)
                {
                    if (simplexTab[i, negInds[k]] <= 0)
                        continue;
                    Fraction div =
                        simplexTab[i, 0] / simplexTab[i, negInds[k]];
                    if (div.Value < θ[k])
                    {
                        θ[k] = div.Value;
                        iθ[k] = i;
                    }
                }

                if (θ[k] == decimal.MaxValue)
                {
                    // no new `good` vector, panic!
                    return false;
                }

                decimal deltaF = -simplexTab[m - 1, negInds[k]].Value * θ[k];

                if ((deltaF > deltaFmax) ||
                    ((deltaF == deltaFmax) && (m_c[negInds[k] - 1] > m_c[col - 1])))
                {
                    deltaFmax = deltaF;
                    col = negInds[k];
                }
            }

            if (col == -1)
                return false;
            row = iθ[Array.IndexOf<int>(negInds, col)];
            return true;
        }
    }
}
