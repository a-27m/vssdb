using System;
using System.Collections.Generic;
using System.Text;
using Fractions;

namespace Lab3_Transport
{
    public class Solver
    {
        Fraction[,] c;
        Fraction[] a;
        Fraction[] b;

        public Solver() { }
        public Solver(Fraction[,] C, Fraction[] A, Fraction[] B)
        {
            this.c = C;
            this.a = A;
            this.b = B;
        }

        public Fraction[,] NWCorner()
        {
            int m = c.GetLength(0);
            int n = c.GetLength(1);
            int i,j;

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
    }
}
