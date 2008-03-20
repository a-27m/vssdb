using System;
using System.Collections.Generic;
using System.Text;
using Fractions;
using System.Drawing;

namespace Lab3_Transport
{
    public class Solver
    {
        public Fraction[,] c, x;
        public Fraction[] a;
        public Fraction[] b;
        public Fraction[] u;
        public Fraction[] v;
        int m, n;

        List<Point> cycle;

        public Solver()
        {
        }
        public Solver(Fraction[,] C, Fraction[] A, Fraction[] B)
        {
            this.c = C;
            this.a = A;
            this.b = B;
        }

        public Fraction[,] NWCorner()
        {
            m = c.GetLength(0);
            n = c.GetLength(1);
            int i, j;

            i = 0;
            j = 0;

            Fraction[] ta, tb;
            ta = (Fraction[])a.Clone();
            tb = (Fraction[])b.Clone();

            Fraction[,] x = new Fraction[m, n];
            do
            {
                if (ta[i] < tb[j])
                {
                    x[i, j] = ta[i];
                    tb[j] -= ta[i];
                    i++;
                }
                else
                {
                    x[i, j] = tb[j];
                    ta[i] -= tb[j];
                    j++;
                }
            } while (i < m && j < n);
            return x;
        }

        public void MkPotentials(out Fraction[] pu, out Fraction[] pv)
        {
            u = new Fraction[m];
            v = new Fraction[n];
            u[0] = 0;

            Fraction[,] backupX = (Fraction[,])x.Clone();            
            Fraction[,] t = x;
            x = backupX;

            f1(0);

            pu = u;
            pv = v;
            x = t;
        }

        private void f1(int i)
        {
            for (int j = 0; j < n; j++)
            {
                if (x[i, j] != null)
                {
                    x[i, j] = null;
                    v[j] = c[i, j] - u[i];
                    f2(j);
                }
            }
        }
        private void f2(int j)
        {
            for (int i = 0; i < m; i++)
            {
                if (x[i, j] != null)
                {
                    x[i, j] = null;
                    u[i] = c[i, j] - v[j];
                    f1(i);
                }
            }
        }

        public bool FindDelta(out int maxI, out int maxJ)
        {
            m = c.GetLength(0);
            n = c.GetLength(1);

            Fraction delta, maxDelta = 0;
            maxI = maxJ = -1;

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (x[i, j] != null)
                    {
                        delta = u[i] + v[j] - c[i, j];
                        if (delta > maxDelta)
                        {
                            maxDelta = delta;
                            maxI = i;
                            maxJ = j;
                        }
                    }

            return maxDelta != 0;
        }

        int i0, j0, contmp;
        public void MkCycle(int i, int j)
        {
            if (cycle == null)
                cycle = new List<Point>();
            else
                cycle.Clear();

            //x[i, j] == null;
            i0 = i;
            j0 = j;
            contmp = 0;
            ch(i,j);
        }

        private bool ch(int i, int j, int di, int dj)
        {
            if (Math.Abs(di) == Math.Abs(dj))
                throw new ArgumentException("either di or oj has to be 0");

            for(i >= 0 && i < m && j >= 0 && j < n)
            {
                if (i == i0 && j == j0)
                    return true;
                if (x[i, j] == null)
                    continue;
                else
                {
                    x[i, j] = null;
                    if (cv(i, j))
                    {
                        cycle.Add(new Point(i, j));
                        return true;
                    }
                }

                i += di;
                j += dj;
            }
        }
        private bool cv(int j)
        {
            for (int i = 0; i < m; i++)
            {
                if (i == i0 && j == j0 && contmp++>0)
                    return true;
                else
                    if (x[i, j] != null)
                    {
                        x[i, j] = null;
                        if (cv(i,j))
                        {
                            cycle.Add(new Point(i, j));
                            return true;
                        }
                    }
            }
        }

    }
}
