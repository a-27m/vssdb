using System;
using System.Collections.Generic;

namespace ComplexNumbers
{
    public delegate Complex ComplexFunction(Complex z);

    public struct Complex
    {
        public double re;
        public double im;

        public static readonly Complex NaN = new Complex(double.NaN, double.NaN);

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

        public static double Norm(Complex z)
        {
            return Math.Sqrt(z.x2y2);
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

        public static bool IsNaN(Complex z)
        {
            return double.IsNaN(z.re) || double.IsNaN(z.im);
        }

        public override string ToString()
        {
            return string.Format("({0}; {1})", re, im);
        }

        public string ToString(string formatString)
        {
            string str = "(";
            str += re.ToString(formatString);
            str += "; ";
            str += im.ToString(formatString);
            str += ")";

            return str;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is Complex)
            {
                return ((Complex)obj).re == re &&
                   ((Complex)obj).im == im;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
            //byte[] bytes = 
            //BitConverter.GetBytes(re);
            //return BitConverter.
        }

        //public class Comparer : IEqualityComparer<Complex>
        //{
        //    public bool Equals(Complex x, Complex y)
        //    {
        //        return Complex.Equals(x, y);
        //    }

        //    public int GetHashCode(Complex obj)
        //    {
        //        return obj.GetHashCode();
        //    }
        //}
    }
}
