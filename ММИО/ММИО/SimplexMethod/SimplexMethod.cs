using System;
using System.Collections.Generic;
using System.Text;
using Fractions;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimplexMethod
{
    public abstract class Solver
    {
        public bool Nonnegative = true;

        protected int n = 0, originalN = 0;
        public static Fraction M = new Fraction(1000000, 1);
        protected List<Fraction[]> la;
        protected Fraction[] m_c;


        public abstract void AddLimtation(Fraction[] a, short sign, Fraction b);
        public abstract void RemoveLimitation(uint index);
        public void SetTargetFunctionCoefficients(Fraction[] c)
        {
            if (c.Length > n)
                throw new ArgumentException("Array 'c' is too long");
            originalN = c.Length;
            m_c = c;
        }

        public abstract Fraction[] Solve();
        /// <exception cref="InvalidOperationException"></exception>
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
        public delegate void DebugSimplexTableHandler(int[] basis, Fraction[] c, Fraction[,] table);
        public delegate bool DelegateBoolIntInt(int i, int j);
        public event DebugSimplexTableHandler DebugNewSimplexTable;

        protected void OnNewSimplexTable(int[] basis, Fraction[] c, Fraction[,] table)
        {
            if (DebugNewSimplexTable != null)
                DebugNewSimplexTable(basis, c, table);
        }

        public override void AddLimtation(Fraction[] a, short sign, Fraction b)
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
        public override void RemoveLimitation(uint index)
        {
            la.RemoveAt((int)index);
            n = 0;
            foreach (Fraction[] cond in la)
            {
                if (n < cond.Length)
                    n = cond.Length;
            }
        }
        public override Fraction[] Solve()
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

            // copy limitations in List<Fraction[]> la
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
                simplexTab[m, 0] += m_c[basisIndicesJ[t] - 1] * simplexTab[basisIndicesI[t] - 1, 0];

            for (int j = 1; j <= n; j++)
            {
                Fraction delta = 0;
                for (int t = 0; t < m; t++)
                    delta += m_c[basisIndicesJ[t] - 1] * simplexTab[basisIndicesI[t] - 1, j];
                simplexTab[m, j] = delta - m_c[j - 1];
            }

            //
            // пока есть отрицательные оценки, вводить в базис новый вектор.
            //
            int iterationsCount = 0;
            bool haveANegativeDelta = true;
            while (iterationsCount < m + 20)
            {
                OnNewSimplexTable(basisIndicesJ, m_c, simplexTab);

                iterationsCount++;

                List<int> negativeColumns = new List<int>(CheckMPlusOneRow(simplexTab));

                if (negativeColumns != null)
                    haveANegativeDelta = negativeColumns.Count > 0;
                else
                    haveANegativeDelta = false;

                if (!haveANegativeDelta)
                    break;

                int i, j;
                if (FindBestNewVector(simplexTab, negativeColumns.ToArray(), out i, out j))
                {
                    Solver.GGaussProcess(ref simplexTab, (uint)i, (uint)j);

                    // fix basis changes
                    basisIndicesI[i] = i + 1;
                    basisIndicesJ[i] = j;
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
                    if (index < originalN)
                        solution[index] = simplexTab[j, 0];
                }

            }

            Array.Resize<Fraction>(ref m_c, oldMcLen);
            n -= k;
            return solution;
        }

        protected int[] FindBasis(List<Fraction[]> conds, out int[] ii)
        {
            DelegateBoolIntInt IsE_Vector = new DelegateBoolIntInt(delegate(int i, int j)
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

    public class GraphicSolver : Solver
    {
        public delegate void DebugPolygonEventHandler(FractionPoint[] polygon);
        public event DebugPolygonEventHandler DebugPolygon;

        public delegate void DebugMaxMinEventHandler(FractionPoint max, FractionPoint min, Fraction f_tan);
        public event DebugMaxMinEventHandler DebugMaxMin;

        protected short[] signs;
        Fraction[,] a;


        public override void AddLimtation(Fraction[] a, short sign, Fraction b)
        {
            if (Math.Abs(sign) > 1)
                throw new ArgumentOutOfRangeException("sign", "Sign has to be -1 or 0 or 1.");

            if (la == null)
                la = new List<Fraction[]>();
            if (signs == null)
                signs = new short[0];

            n = (a.Length > n ? a.Length : n);

            Fraction[] row = new Fraction[n + 1];
            for (int i = 0; i < row.Length; row[i++] = 0)
                ;

            row[0] = b;
            a.CopyTo(row, 1);
            la.Add(row);

            Array.Resize<short>(ref signs, signs.Length + 1);
            signs[signs.Length - 1] = sign;
        }
        public override void RemoveLimitation(uint index)
        {
            la.RemoveAt((int)index);
            n = 0;
            foreach (Fraction[] cond in la)
            {
                if (n < cond.Length)
                    n = cond.Length;
            }

            for (uint i = index; i < signs.Length - 1; i++)
                signs[i] = signs[i + 1];
            Array.Resize<short>(ref signs, signs.Length - 1);
        }
        public override Fraction[] Solve()
        {
            int m = this.la.Count;

            List<Fraction[]>.Enumerator e;

            if (n != 2)
            {
                #region Canonize

                List<Fraction[]> la2 = new List<Fraction[]>();
                e = la.GetEnumerator();
                for (int i = 0; e.MoveNext(); i++)
                {
                    Fraction[] tmp;

                    if (signs[i] != 0)
                    {
                        n++;
                        tmp = new Fraction[n + 1];
                        for (int k = e.Current.Length - 1; k < n; k++)
                            tmp[k] = 0;
                        tmp[n] = -signs[i];
                    }
                    else
                    {
                        tmp = new Fraction[n + 1];
                        for (int t = 0; t < tmp.Length; tmp[t++] = 0)
                            ;
                    }

                    tmp[0] = e.Current[0];
                    e.Current.CopyTo(tmp, 0);
                    la2.Add(tmp);
                }

                la = la2;
                la2 = null;

                #endregion

                if (n - m != 2)
                    throw new InvalidOperationException("Graphical method applicable only when n minus m equals 2");

                #region la to matrix a
                a = new Fraction[m, n + 1];

                e = la.GetEnumerator();
                for (int i = 0; e.MoveNext(); i++)
                {
                    int j = 0;
                    for (; j < e.Current.Length; j++)
                        a[i, j] = e.Current[j];
                    for (; j <= n; j++)
                        a[i, j] = 0;
                }
                #endregion

                #region make some basis

                for (uint k = 0; k < m; k++)
                {
                    // look for non-zero main element at position [k, n-k]
                    int k_nz = -1;
                    for (uint i = k; i < m; i++)
                        if (a[i, n - k] != 0)
                            k_nz = (int)i;

                    if (k_nz == -1)
                        continue;

                    // ok, swap row #k with row #k_nz
                    for (uint j = 0; j < n + 1; j++)
                    {
                        Fraction t = a[k, j];
                        a[k, j] = a[k_nz, j];
                        a[k_nz, j] = t;
                    }

                    GGaussProcess(ref a, k, (uint)n - k);
                }

                #endregion

                for (int t = 0; t < m; t++)
                    signs[t] = -1;
            }
            else
            {
                //solve immediately;
                #region la to matrix a
                a = new Fraction[m, n + 1];

                e = la.GetEnumerator();
                for (int i = 0; e.MoveNext(); i++)
                {
                    int j = 0;
                    for (; j < e.Current.Length; j++)
                        a[i, j] = e.Current[j];
                    for (; j <= n; j++)
                        a[i, j] = 0;
                }
                #endregion
            }

            FractionPoint[] cornerPoints;
            cornerPoints = GetCornerPoints();// only valid ones are returned

            if (cornerPoints == null)
                return null;
            else if (cornerPoints.Length == 0)
                return null;

            OnPolygon(cornerPoints);

            Fraction c1 = m_c[0], c2 = m_c[1];
            if (n > 2)
            //{
                for (int i = 0; i < m; i++)
                {
                    c1 += m_c[i + 2] * a[i, 1];
                    c2 += m_c[i + 2] * a[i, 2];
                    //d += m_c[i + 2] * a[i, 0];
                }
            //    c1 /= d;
            //    c2 /= d;
            //}

            int i_max, i_min;
            GetMinMax(cornerPoints, c1, c2, out i_max, out i_min);
            OnMaxMin(cornerPoints[i_max], cornerPoints[i_min], c2 / c1);

            // for maximum
            Fraction[] solution = new Fraction[n];
            solution[0] = cornerPoints[i_max].X;
            solution[1] = cornerPoints[i_max].Y;
            if (n > 2)
                for (int j = 2; j < n; j++)
                    for (int i = 0; i < m; i++)
                        if (a[i, j+1] == 1)
                            solution[j] = a[i, 0] - a[i, 1] * solution[0] - a[i, 2] * solution[1];

            return solution;
        }

        protected FractionPoint[] GetCornerPoints()
        {
            int m = a.GetLength(0);

            List<FractionPoint> la = new List<FractionPoint>();

            for (int i = 0; i < m; i++)
                for (int j = i + 1; j < m; j++)
                {
                    Fraction det = a[i, 1] * a[j, 2] - a[i, 2] * a[j, 1];

                    if (det == 0)
                        continue;
                    Fraction x, y;
                    x = (a[i, 0] * a[j, 2] - a[i, 2] * a[j, 0]) / det;
                    y = (a[i, 1] * a[j, 0] - a[i, 0] * a[j, 1]) / det;

                    la.Add(new FractionPoint(x, y));
                }

            for (int i = 0; i < m; i++)
            {
                if (a[i, 2] != 0)
                {
                    la.Add(new FractionPoint(0, a[i, 0] / a[i, 2]));
                    la.Add(new FractionPoint(M, (a[i, 0] - a[i, 1] * M) / a[i, 2]));
                }
                if (a[i, 1] != 0)
                {
                    la.Add(new FractionPoint(a[i, 0] / a[i, 1], 0));
                    la.Add(new FractionPoint((a[i, 0] - a[i, 2] * M) / a[i, 1], M));
                }
            }
            la.Add(new FractionPoint(0, 0));
            la.Add(new FractionPoint(M, M));

            // check up validity for all points
            List<FractionPoint> corners = new List<FractionPoint>();
            List<FractionPoint>.Enumerator eptsList = la.GetEnumerator();
            while (eptsList.MoveNext())
            {
                bool ptIsValid = true;

                for (int i = 0; i < m && ptIsValid; i++)
                {
                    Decimal t = (
                        a[i, 1] * eptsList.Current.X +
                        a[i, 2] * eptsList.Current.Y -
                        a[i, 0]).Value;

                    if (!(
                        ((short)Math.Sign(t) == signs[i]) ||
                        ((short)Math.Sign(t) == 0)))
                    {
                        ptIsValid = false;
                        break;
                    }
                }

                if (Nonnegative && ptIsValid)
                {
                    if ((eptsList.Current.X < 0) || (eptsList.Current.Y < 0))
                        ptIsValid = false;
                }

                if (ptIsValid)
                    corners.Add(eptsList.Current);
            }
            return corners.ToArray();
        }
        protected void GetMinMax(FractionPoint[] A, Fraction Xf, Fraction Yf, out int maxIndex, out int minIndex)
        {
            maxIndex = 0;
            minIndex = 0;

            Matrix normalize = new Matrix();
            normalize.Rotate((float)Math.Atan2(Xf, Yf));

            PointF[] pt = new PointF[A.Length];
            for (int t = 0; t < A.Length; t++)
                pt[t] = new PointF(A[t].X, A[t].Y);

            normalize.TransformVectors(pt);

            for (int t = 0; t < A.Length; t++)
            {
                if (pt[t].X > pt[maxIndex].X)
                    maxIndex = t;
                if (pt[t].X < pt[minIndex].X)
                    minIndex = t;
            }
        }
        public static FractionPoint[] GetEmbracingPolygon(FractionPoint[] pts)
        {
            double[] keys = new double[pts.Length];

            FractionPoint center = new FractionPoint(1, 1);
            for (int i = 0; i < pts.Length; i++)
            {
                center.X *= pts[i].X;
                center.Y *= pts[i].Y;
            }
            center.X = new Fraction((decimal)Math.Pow((double)center.X, 1d / pts.Length));
            center.Y = new Fraction(Math.Sign(center.Y) * (decimal)Math.Pow(Math.Abs(center.Y), 1d / pts.Length));

            for (int i = 0; i < keys.Length; i++)
                // fill keys with angles relative to center-point
                keys[i] = Math.Atan2(pts[i].Y - center.Y, pts[i].X - center.X);

            Array.Sort<double, FractionPoint>(keys, pts);

            return pts;
        }

        protected void OnPolygon(FractionPoint[] pts)
        {
            if (DebugPolygon != null)
                DebugPolygon(GetEmbracingPolygon(pts));
        }
        protected void OnMaxMin(FractionPoint max, FractionPoint min, Fraction f_tangence)
        {
            if (DebugMaxMin != null)
                DebugMaxMin(max, min, f_tangence);
        }
    }
}
