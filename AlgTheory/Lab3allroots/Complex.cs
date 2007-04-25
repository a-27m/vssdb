using System;

namespace Complex
{
    public struct Complex
    {
        public double re;
        public double im;

        public Complex(double real, double imagine)
        {
            re = real;
            im = imagine;
        }
        public Complex(double real)
        {
            re = real;
            im = 0;
        }

        private double x2y2
        {
            get
            {
                return this.re * this.re + this.im * this.im;
            }
        }

        public double Norm
        {
            get
            {
                return Math.Sqrt(x2y2);
            }
        }

        public Complex Add(Complex c1)
        {
            return new Complex(c1.re + this.re, c1.im + this.im);
        }
        public Complex Substract(Complex c1)
        {
            return new Complex(this.re - c1.re, this.im - c1.im);
        }
        public Complex Multiply(Complex c1)
        {
            return new Complex(this.re * c1.re - this.im * c1.im, this.re * c1.im + this.im * c1.re);
        }
        public Complex Divide(Complex c1)
        {
            double denom = c1.x2y2;
            return new Complex((this.re * c1.re + this.im * c1.im) / denom, (c1.re * this.im - c1.im * this.re) / denom);
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return c1.Add(c2);
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            return c1.Substract(c2);
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            return c1.Multiply(c2);
        }
        public static Complex operator /(Complex c1, Complex c2)
        {
            return c1.Divide(c2);
        }
    }
}
