using System;

namespace Fractions
{
    [Serializable()]
    public class Fraction : ICloneable, IComparable, IFormattable
    {
        long m_integer;
        long m_numerator;
        long m_denominator;

        public Fraction(long integer, long numerator, long denominator)
        {
            if (denominator == 0)
                throw new NotFiniteNumberException("Denominator is zero!", denominator);
            if (denominator > 0)
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
            if (denominator == 0)
                throw new NotFiniteNumberException("Denominator is zero!", denominator);
            if (denominator > 0)
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
        public Fraction(Decimal value)
        {
            this.Value = value;
        }

        public Decimal Value
        {
            get
            {
                return (Decimal)m_numerator / m_denominator + m_integer*Math.Sign(m_numerator);
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
            Fraction f = Fraction.Simplify(this);
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
            Fraction sum = new Fraction(
                a.m_integer * Math.Sign(a.m_numerator) + b.m_integer * Math.Sign(b.m_numerator),
                a.m_numerator * d_a + b.m_numerator * d_b,
                lcm);
            sum.Simplify();
            return sum;
        }
        public static Fraction Negate(Fraction a)
        {
            return new Fraction(a.m_integer, -a.m_numerator, a.m_denominator);
        }
        public static Fraction Substract(Fraction a, Fraction b)
        {
            return Add(a, Negate(b));
            // Fraction sum = new Fraction(a.m_integer - b.m_integer, a.m_numerator * d_a - b.m_numerator * d_b, lcm);
        }
        public static Fraction Multiply(Fraction a, Fraction b)
        {
            Fraction mul = new Fraction(
                (a.m_integer * a.m_denominator * Math.Sign(a.m_numerator) + a.m_numerator) *
                (b.m_integer * b.m_denominator * Math.Sign(b.m_numerator) + b.m_numerator),
                a.m_denominator * b.m_denominator);
            mul.Simplify();
            return mul;
        }
        public static Fraction Divide(Fraction a, Fraction b)
        {
            Fraction div = new Fraction(
                (a.m_integer * a.m_denominator * Math.Sign(a.m_numerator) + a.m_numerator) * b.m_denominator,
                (b.m_integer * b.m_denominator * Math.Sign(b.m_numerator) + b.m_numerator) * a.m_denominator);
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
            if (a.m_denominator == 0)
                    throw new NotFiniteNumberException("Denominator is set to zero while simplifying the fraction: "+a.ToString());

            return a;
        }

        public static long GCD(long a, long b)
        {
            // �������� ������� ��� ������ ���
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
            return this.MemberwiseClone();
//            return new Fraction(this.m_integer, this.m_numerator, this.m_denominator);
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

        public override string ToString()
        {
            return this.ToString("R");
        }
        public string ToString(string format)
        {
            if (this.m_integer * this.m_denominator * Math.Sign(this.m_numerator) + this.m_numerator == 0)
                return "0";
            if (this.m_integer * this.m_denominator * Math.Sign(this.m_numerator) + this.m_numerator == m_denominator)
                return "1";
            if (this.m_integer * this.m_denominator * Math.Sign(this.m_numerator) + this.m_numerator == -m_denominator)
                return "-1";
            if (format.ToUpper().StartsWith("R"))
                return string.Format("{0}{1} {2}/{3}",
                    m_numerator > 0 ? "-" : "",
                    m_integer != 0 ? m_integer.ToString() : "",
                    m_numerator,
                    m_denominator);
            if (format.ToUpper().StartsWith("W"))
                return string.Format("{0}{1}/{2}",
                    m_numerator > 0 ? "-" : "",
                    m_integer * m_denominator * Math.Sign(m_numerator) + m_numerator,
                    m_denominator);
            throw new ArgumentException("Specifed format is not valid, use 'Right' or 'Wrong'.");
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return this.ToString(format);
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
            return Divide(f1, f2);
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

        //
        // Summary:
        //     Converts a Fraction to a single-precision floating-point number.
        //
        // Parameters:
        //   value:
        //     A Fraction to convert.
        //
        // Returns:
        //     A single-precision floating-point number that represents the converted Fraction.
        public static explicit operator float(Fraction value)
        {
            return (float)value.Value;
        }
        //
        // Summary:
        //     Converts a Fraction to a double-precision floating-point number.
        //
        // Parameters:
        //   value:
        //     A Fraction to convert.
        //
        // Returns:
        //     A double-precision floating-point number that represents the converted Fraction.
        public static explicit operator double(Fraction value)
        {
            return (double)value.Value;
        }
        //
        // Summary:
        //     Converts a Fraction to a Unicode character.
        //
        // Parameters:
        //   value:
        //     A Fraction to convert.
        //
        // Returns:
        //     A Unicode character that represents the converted Fraction.
        //
        // Exceptions:
        //   System.OverflowException:
        //     value is less than System.Int16.MinValue or greater than System.Int16.MaxValue.
        public static explicit operator char(Fraction value)
        {
            return (char)value.Value;
        }
        //
        // Summary:
        //     Converts a Fraction to a 64-bit signed integer.
        //
        // Parameters:
        //   value:
        //     A Fraction to convert.
        //
        // Returns:
        //     A 64-bit signed integer that represents the converted Fraction.
        //
        // Exceptions:
        //   System.OverflowException:
        //     value is less than System.Int64.MinValue or greater than System.Int64.MaxValue.
        public static explicit operator long(Fraction value)
        {
            return (long)value.Value;
        }
        //
        // Summary:
        //     Converts a Fraction to a 64-bit unsigned integer.
        //
        // Parameters:
        //   value:
        //     A Fraction to convert.
        //
        // Returns:
        //     A 64-bit unsigned integer that represents the converted Fraction.
        //
        // Exceptions:
        //   System.OverflowException:
        //     value is negative or greater than System.UInt64.MaxValue.
        public static explicit operator ulong(Fraction value)
        {
            return (ulong)value.Value;
        }
        //
        // Summary:
        //     Converts a Fraction to a 32-bit unsigned integer.
        //
        // Parameters:
        //   value:
        //     A Fraction to convert.
        //
        // Returns:
        //     A 32-bit unsigned integer that represents the converted Fraction.
        //
        // Exceptions:
        //   System.OverflowException:
        //     value is negative or greater than System.UInt32.MaxValue.
        public static explicit operator uint(Fraction value)
        {
            return (uint)value.Value;
        }
        //
        // Summary:
        //     Converts a Fraction to an 8-bit unsigned integer.
        //
        // Parameters:
        //   value:
        //     A Fraction to convert.
        //
        // Returns:
        //     An 8-bit unsigned integer that represents the converted Fraction.
        //
        // Exceptions:
        //   System.OverflowException:
        //     value is less than System.Byte.MinValue or greater than System.Byte.MaxValue.
        public static explicit operator byte(Fraction value)
        {
            return (byte)value.Value;
        }
        //
        // Summary:
        //     Converts a Fraction to an 8-bit signed integer.
        //
        // Parameters:
        //   value:
        //     A Fraction to convert.
        //
        // Returns:
        //     An 8-bit signed integer that represents the converted Fraction.
        //
        // Exceptions:
        //   System.OverflowException:
        //     value is less than System.SByte.MinValue or greater than System.SByte.MaxValue.
        public static explicit operator sbyte(Fraction value)
        {
            return (sbyte)value.Value;
        }
        //
        // Summary:
        //     Converts a Fraction to a 32-bit signed integer.
        //
        // Parameters:
        //   value:
        //     A Fraction to convert.
        //
        // Returns:
        //     A 32-bit signed integer that represents the converted Fraction.
        //
        // Exceptions:
        //   System.OverflowException:
        //     value is less than System.Int32.MinValue or greater than System.Int32.MaxValue.
        public static explicit operator int(Fraction value)
        {
            return (int)value.Value;
        }
        //
        // Summary:
        //     Converts a Fraction to a 16-bit signed integer.
        //
        // Parameters:
        //   value:
        //     A Fraction to convert.
        //
        // Returns:
        //     A 16-bit signed integer that represents the converted Fraction.
        //
        // Exceptions:
        //   System.OverflowException:
        //     value is less than System.Int16.MinValue or greater than System.Int16.MaxValue.
        public static explicit operator short(Fraction value)
        {
            return (short)value.Value;
        }
        //
        // Summary:
        //     Converts a Fraction to a 16-bit unsigned integer.
        //
        // Parameters:
        //   value:
        //     A Fraction to convert.
        //
        // Returns:
        //     A 16-bit unsigned integer that represents the converted Fraction.
        //
        // Exceptions:
        //   System.OverflowException:
        //     value is greater than System.UInt16.MaxValue or less than System.UInt16.MinValue.
        public static explicit operator ushort(Fraction value)
        {
            return (ushort)value.Value;
        }
        //
        // Summary:
        //     Converts a double-precision floating-point number to a Fraction.
        //
        // Parameters:
        //   value:
        //     A double-precision floating-point number.
        //
        // Returns:
        //     A Fraction that represents the converted double-precision floating
        //     point number.
        //
        // Exceptions:
        //   System.OverflowException:
        //     value is less than Fraction.MinValue or greater than Fraction.MaxValue.-or-
        //     value is System.Double.NaN, System.Double.PositiveInfinity, or System.Double.NegativeInfinity.
        public static explicit operator Fraction(double value)
        {
            return new Fraction((decimal)value);
        }
        //
        // Summary:
        //     Converts a single-precision floating-point number to a Fraction.
        //
        // Parameters:
        //   value:
        //     A single-precision floating-point number.
        //
        // Returns:
        //     A Fraction that represents the converted single-precision floating
        //     point number.
        //
        // Exceptions:
        //   System.OverflowException:
        //     value is less than Fraction.MinValue or greater than Fraction.MaxValue.-or-
        //     value is System.Single.NaN, System.Single.PositiveInfinity, or System.Single.NegativeInfinity.
        public static explicit operator Fraction(float value)
        {
            return new Fraction((decimal)value);
        }
        //
        // Summary:
        //     Converts an 8-bit unsigned integer to a Fraction.
        //
        // Parameters:
        //   value:
        //     An 8-bit unsigned integer.
        //
        // Returns:
        //     A Fraction that represents the converted 8-bit unsigned integer.
        public static implicit operator Fraction(byte value)
        {
            return new Fraction((decimal)value);
        }
        //
        // Summary:
        //     Converts a Unicode character to a Fraction.
        //
        // Parameters:
        //   value:
        //     A Unicode character.
        //
        // Returns:
        //     A Fraction that represents the converted Unicode character.
        public static implicit operator Fraction(char value)
        {
            return new Fraction((decimal)value);
        }
        //
        // Summary:
        //     Converts a 32-bit signed integer to a Fraction.
        //
        // Parameters:
        //   value:
        //     A 32-bit signed integer.
        //
        // Returns:
        //     A Fraction that represents the converted 32-bit signed integer.
        public static implicit operator Fraction(int value)
        {
            return new Fraction((decimal)value);
        }
        //
        // Summary:
        //     Converts a 64-bit signed integer to a Fraction.
        //
        // Parameters:
        //   value:
        //     A 64-bit signed integer.
        //
        // Returns:
        //     A Fraction that represents the converted 64-bit signed integer.
        public static implicit operator Fraction(long value)
        {
            return new Fraction((decimal)value);
        }
        //
        // Summary:
        //     Converts an 8-bit signed integer to a Fraction.
        //
        // Parameters:
        //   value:
        //     An 8-bit signed integer.
        //
        // Returns:
        //     A Fraction that represents the converted 8-bit signed integer.
        public static implicit operator Fraction(sbyte value)
        {
            return new Fraction((decimal)value);
        }
        //
        // Summary:
        //     Converts a 16-bit signed integer to a Fraction.
        //
        // Parameters:
        //   value:
        //     A 16-bit signed integer.
        //
        // Returns:
        //     A Fraction that represents the converted 16-bit signed integer.
        public static implicit operator Fraction(short value)
        {
            return new Fraction((decimal)value);
        }
        //
        // Summary:
        //     Converts a 32-bit unsigned integer to a Fraction.
        //
        // Parameters:
        //   value:
        //     A 32-bit unsigned integer.
        //
        // Returns:
        //     A Fraction that represents the converted 32-bit unsigned integer.
        public static implicit operator Fraction(uint value)
        {
            return new Fraction((decimal)value);
        }
        //
        // Summary:
        //     Converts a 64-bit unsigned integer to a Fraction.
        //
        // Parameters:
        //   value:
        //     A 64-bit unsigned integer.
        //
        // Returns:
        //     A Fraction that represents the converted 64-bit unsigned integer.
        public static implicit operator Fraction(ulong value)
        {
            return new Fraction((decimal)value);
        }
        //
        // Summary:
        //     Converts a 16-bit unsigned integer to a Fraction.
        //
        // Parameters:
        //   value:
        //     A 16-bit unsigned integer.
        //
        // Returns:
        //     A Fraction that represents the converted 16-bit unsigned integer.
        public static implicit operator Fraction(ushort value)
        {
            return new Fraction((decimal)value);
        }
    }
}
