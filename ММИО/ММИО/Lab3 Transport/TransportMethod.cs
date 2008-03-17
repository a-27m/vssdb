using System;
using System.Collections.Generic;
using System.Text;
using Fractions;

namespace Lab3_Transport
{
    class Solver
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

        public Fraction[] NWCorner()
        {
        }
    }
}
