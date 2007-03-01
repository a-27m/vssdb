using System;

namespace Fractions
{
    /*
    public interface IMy
    {
        string SomeFunction(int a);
    }

    public class MyClassI : IMy
    {
        public string SomeFunction(int a)
        {
            return "OK" + a.ToString();
        }
    }

    public class MyClassNoI
    {
        public string SomeFunction(int a)
        {
            return "OK"+a.ToString();
        }
    }

    public class TargetClass<T> where T : IMy
    {
        T t;
        public TargetClass(int p)
        {
          Console.WriteLine("Test "+t.SomeFunction(5));
        }
    }

    public class TestIt
    {
        static void Main()
        {
            MyClassNoI;
            TargetClass<MyClassI> rules;
            TargetClass<MyClassNoI> doubts;
        }
    }
    */

    public class Fraction : ICloneable, IComparable, IFormattable
    {
        long m_integer;
        long m_numerator;
        long m_denominator;

       // bool m_syraja = true;

        public Fraction(long integer, long numerator, long denominator)
        {
            if (denominator >= 0)
            {
                this.m_numerator = numerator;
                this.m_denominator = denominator;
            }
            else
            {
                this.m_numerator = -numerator;
                this.m_denominator = -denominator;
            }
            //m_syraja = true;
        }

        public Fraction(long numerator, long denominator)
        {
            if (denominator >= 0)
            {
                this.m_numerator = numerator;
                this.m_denominator = denominator;
            }
            else
            {
                this.m_numerator = -numerator;
                this.m_denominator = -denominator;
            }
            //m_syraja = true;
        }

        public Decimal Value
        {
            get
            {
                return (Decimal)m_numerator / m_denominator + m_integer;
            }
            set
            {
                int digitsCount = 0;
                Decimal decfrac = value - Math.Truncate(value);
                while (!decfrac.Equals(Math.Truncate(decfrac)))
                {
                    digitsCount++;
                    decfrac *= 10m;
                }

                m_denominator = (long)Math.Pow(10, digitsCount);
                m_numerator = (long)decfrac;
                m_integer = (long)(value - Math.Truncate(value));
                this.Simplify();
            }
        }

        public long Numerator
        {
            get
            {
                return m_numerator;
            }
            set
            {
                m_numerator = value;
            }
        }
        public long Denominator
        {
            get
            {
                return m_denominator;
            }
            set
            {
                if (m_numerator > 0)
                {
                    m_denominator = value;
                }
                else
                {
                    m_numerator = -m_numerator;
                    m_denominator = -value;
                }
            }
        }
        public long Integer
        {
            get
            {
                return m_integer;
            }
        }

        public virtual void Simplify()
        {
            Fraction f = Simplify(this);
            this.m_integer = f.m_integer;
            this.m_numerator = f.m_numerator;
            this.m_denominator = f.m_denominator;
            //this.m_syraja = false;
        }

        public static Fraction Add(Fraction a, Fraction b)
        {
            long lcm = LCM(a.m_denominator, b.m_denominator);
            long d_a = lcm / a.m_denominator;
            long d_b = lcm / b.m_denominator;
            Fraction sum = new Fraction(a.m_integer + b.m_integer, a.m_numerator * d_a + b.m_numerator * d_b, lcm);
            sum.Simplify();
            return sum;
        }
        public static Fraction Negate(Fraction a)
        {
            return new Fraction(a.m_integer, -a.m_numerator, a.m_denominator);
        }
        public static Fraction Substract(Fraction a, Fraction b)
        {
            long lcm = LCM(a.m_denominator, b.m_denominator);
            long d_a = lcm / a.m_denominator;
            long d_b = lcm / b.m_denominator;
            Fraction sum = new Fraction(a.m_integer - b.m_integer, a.m_numerator * d_a - b.m_numerator * d_b, lcm);
            sum.Simplify();
            return sum;
        }
        public static Fraction Multiply(Fraction a, Fraction b)
        {
            Fraction mul = new Fraction(
                (a.m_integer * a.m_denominator + a.m_numerator) *
                (b.m_integer * b.m_denominator + b.m_numerator),
                a.m_denominator * b.m_denominator);
            mul.Simplify();
            return mul;
        }
        public static Fraction Divide(Fraction a, Fraction b)
        {
            Fraction div = new Fraction(
                (a.m_integer * a.m_denominator + a.m_numerator) * b.m_denominator,
                (b.m_integer * b.m_denominator + b.m_numerator) * a.m_denominator);
            div.Simplify();
            return div;
        }
        public static Fraction Simplify(Fraction a)
        {
            long gcd = GCD(Math.Abs(a.m_numerator), a.m_denominator);
            a.m_numerator /= gcd;
            a.m_denominator /= gcd;

            if (a.m_denominator < a.m_numerator)
                a.m_integer = Math.DivRem(a.m_numerator, a.m_denominator, out a.m_numerator);
            //a.m_syraja = false;

            return a;
        }

        public static long GCD(long a, long b)
        {
            // Алгоритм Евклида для поиска НОД
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                    continue;
                }
                if (b > a)
                    b = b - a;
            }
            return a; // == b
        }
        public static long LCM(long a, long b)
        {
            return a * b / GCD(a, b);
        }

        public object Clone()
        {
            return new Fraction(this.m_numerator, this.m_denominator);
        }

        public int CompareTo(Object other)
        {
            if (other is Fraction)
            {
                return Value.CompareTo((other as Fraction).Value);
            }
            if (other is Decimal)
            {
                return Value.CompareTo(other);
            }

            throw new ArgumentException("Comparsion between Fractions and " + other.GetType().Name + " is not implemented yet");
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction)
            {
                Fraction _f1 = Simplify(this);
                Fraction _f2 = Simplify(obj as Fraction);
                return _f1.m_integer == _f2.m_integer &&
                    _f1.m_numerator == _f2.m_numerator &&
                    _f1.m_denominator == _f2.m_denominator;
            }
            if (obj is decimal)
            {
                return Value.Equals((obj as Fraction).Value);
            }

            throw new ArgumentException("Cannot compare arguments");
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format.StartsWith("R"))
                return string.Format("{0} {1}{2}/{3}", m_integer, m_numerator > 0 ? "-" : "", m_numerator, m_denominator);
            if (format.StartsWith("W"))
                return string.Format("{0}{1}/{2}", m_numerator > 0 ? "-" : "", m_integer * m_numerator, m_denominator);
            throw new ArgumentException("Specifed format is not valid, use 'Right' or 'Wrong'.");
        }

        public static Fraction operator -(Fraction f)
        {
            return Negate(f);
        }
        //
        // Summary:
        //     Subtracts two specified Fraction values.
        //
        // Parameters:
        //   f2:
        //     A Fraction.
        //
        //   f1:
        //     A Fraction.
        //
        // Returns:
        //     The Fraction result of subtracting f2 from f1.
        //
        // Exceptions:
        //   System.OverflowException
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return Substract(f1, f2);
        }
        //
        // Summary:
        //     Decrements the Fraction operand by one.
        //
        // Parameters:
        //   f:
        //     The Fraction operand.
        //
        // Returns:
        //     The value of f decremented by 1.
        //
        // Exceptions:
        //   System.OverflowException
        public static Fraction operator --(Fraction f)
        {
            return Substract(f, new Fraction(1, 0, 0));
        }
        //
        // Summary:
        //     Returns a value indicating whether two instances of Fraction are not
        //     equal.
        //
        // Parameters:
        //   f2:
        //     A Fraction.
        //
        //   f1:
        //     A Fraction.
        //
        // Returns:
        //     true if f1 and f2 are not equal; otherwise, false.
        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !f1.Equals(f2);
        }
        //
        // Summary:
        //     Multiplies two specified Fraction values.
        //
        // Parameters:
        //   f2:
        //     A Fraction.
        //
        //   f1:
        //     A Fraction.
        //
        // Returns:
        //     The Fraction result of multiplying f1 by f2.
        //
        // Exceptions:
        //   System.OverflowException
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return Multiply(f1, f2);
        }
        //
        // Summary:
        //     Divides two specified Fraction values.
        //
        // Parameters:
        //   f2:
        //     A Fraction (the divisor).
        //
        //   f1:
        //     A Fraction (the dividend).
        //
        // Returns:
        //     The Fraction result of f1 by f2.
        //
        // Exceptions:
        //   System.OverflowException
        //
        //   System.DivideByZeroException:
        //     f2 is zero.
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
           return  Divide(f1, f2);
        }
        //
        // Summary:
        //     Returns the value of the Fraction operand (the sign of the operand
        //     is unchanged).
        //
        // Parameters:
        //   f:
        //     The Fraction operand.
        //
        // Returns:
        //     The value of the operand, f.
        public static Fraction operator +(Fraction f)
        {
            return f;
        }
        //
        // Summary:
        //     Adds two specified Fraction values.
        //
        // Parameters:
        //   f2:
        //     A Fraction.
        //
        //   f1:
        //     A Fraction.
        //
        // Returns:
        //     The Fraction result of adding f1 and f2.
        //
        // Exceptions:
        //   System.OverflowException
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return Add(f1, f2);
        }
        //
        // Summary:
        //     Increments the Fraction operand by 1.
        //
        // Parameters:
        //   f:
        //     The Fraction operand.
        //
        // Returns:
        //     The value of f incremented by 1.
        //
        // Exceptions:
        //   System.OverflowException:
        //     The return value is less than Fraction.MinValue or greater than Fraction.MaxValue.
        public static Fraction operator ++(Fraction f)
        {
            return Add(f, new Fraction(1, 0, 0));
        }
        //
        // Summary:
        //     Returns a value indicating whether a specified Fraction is less than
        //     another specified Fraction.
        //
        // Parameters:
        //   f2:
        //     A Fraction.
        //
        //   f1:
        //     A Fraction.
        //
        // Returns:
        //     true if f1 is less than f2; otherwise, false.
        public static bool operator <(Fraction f1, Fraction f2)
        {
            return (f1 - f2).Value < 0;
        }
        //
        // Summary:
        //     Returns a value indicating whether a specified Fraction is less than
        //     or equal to another specified Fraction.
        //
        // Parameters:
        //   f2:
        //     A Fraction.
        //
        //   f1:
        //     A Fraction.
        //
        // Returns:
        //     true if f1 is less than or equal to f2; otherwise, false.
        public static bool operator <=(Fraction f1, Fraction f2)
        {
            return (f1 - f2).Value <= 0;
        }
        //
        // Summary:
        //     Returns a value indicating whether two instances of Fraction are equal.
        //
        // Parameters:
        //   f2:
        //     A Fraction.
        //
        //   f1:
        //     A Fraction.
        //
        // Returns:
        //     true if f1 and f2 are equal; otherwise, false.
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return f1.Equals(f2);
        }
        //
        // Summary:
        //     Returns a value indicating whether a specified Fraction is greater
        //     than another specified Fraction.
        //
        // Parameters:
        //   f2:
        //     A Fraction.
        //
        //   f1:
        //     A Fraction.
        //
        // Returns:
        //     true if f1 is greater than f2; otherwise, false.
        public static bool operator >(Fraction f1, Fraction f2)
        {
            return (f1 - f2).Value > 0;
        }
        //
        // Summary:
        //     Returns a value indicating whether a specified Fraction is greater
        //     than or equal to another specified Fraction.
        //
        // Parameters:
        //   f2:
        //     A Fraction.
        //
        //   f1:
        //     A Fraction.
        //
        // Returns:
        //     true if f1 is greater than or equal to f2; otherwise, false.
        public static bool operator >=(Fraction f1, Fraction f2)
        {
            return (f1 - f2).Value >= 0;
        }
    }
}
