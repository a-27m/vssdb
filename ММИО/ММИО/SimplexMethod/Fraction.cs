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

        bool m_syraja = true;

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
            m_syraja = true;
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
            m_syraja = true;
        }

        public Decimal Value
        {
            get
            {
                return (Decimal)m_numerator / m_denominator;
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
            long gcd = GCD(Math.Abs(m_numerator), m_denominator);
            m_numerator /= gcd;
            m_denominator /= gcd;
            m_syraja = false;
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

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
