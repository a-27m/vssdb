using System;

namespace Fractions
{
    [Serializable()]
    public class Fraction : ICloneable, IComparable, IFormattable
    {
        //?const Fraction One = new Fraction(1, 1);
        //?const Fraction Zero = new Fraction(0, 0, 1);

        long m_integer;
        long m_numerator;
        long m_denominator;
        sbyte m_sign;

        /// <summary>
        /// Constructs new fraction number. Integer part contains sign,
        /// numerator and denominator are passed as unsigned numbers.
        /// </summary>
        /// <param name="integer">Integer part of a fraction number</param>
        /// <param name="numerator">The numerator of a new fraction number</param>
        /// <param name="denominator">The denominator of a new fraction number</param>
        public Fraction(long integer, uint numerator, uint denominator)
        {
            if (denominator == 0)
                throw new NotFiniteNumberException("Denominator is zero!", denominator);

            this.m_sign = (sbyte)MySign(integer);
            this.m_integer = Math.Abs(integer);
            this.m_numerator = numerator;
            this.m_denominator = denominator;

        }
        public Fraction(long numerator, long denominator)
        {
            if (denominator == 0)
                throw new NotFiniteNumberException("Denominator is zero!", denominator);

            this.m_sign = (sbyte)(MySign(numerator) * MySign(denominator));

            this.m_integer = 0;
            this.m_numerator = Math.Abs(numerator);
            this.m_denominator = Math.Abs(denominator);

        }
        public Fraction(Decimal value)
        {
            this.Value = value;
        }
        public Fraction()
        {
            m_sign = 1;
            m_integer = 0;
            m_numerator = 0;
            m_denominator = 1;
        }

        public Decimal Value
        {
            get
            {
                return ((decimal)m_numerator / m_denominator + m_integer) * m_sign;
            }
            set
            {
                m_sign = (sbyte)MySign(value);

                value = Math.Abs(value);

                int digitsCount = 0;
                Decimal decfrac = value - Math.Truncate(value);
                while (!decfrac.Equals(Math.Truncate(decfrac)))
                {
                    digitsCount++;
                    decfrac *= 10m;
                }

                m_denominator = (long)Math.Pow(10, digitsCount);
                m_numerator = (long)decfrac;
                m_integer = (long)(Math.Truncate(value));
                this.Simplify();
            }
        }

        public long Numerator
        {
            get
            {
                return (m_numerator + m_integer * m_denominator) * m_sign;
            }
            set
            {
                m_sign = MySign(value);
                m_numerator = Math.Abs(value);
                m_integer = 0;
                Simplify();
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
                if (value > 0)
                {
                    m_denominator = value;
                }
                else
                {
                    m_sign = MySign(((decimal)m_numerator / value + m_integer) * m_sign);
                    m_denominator = -value;
                }
            }
        }
        public long Integer
        {
            get
            {
                return m_integer * m_sign;
            }
            set
            {
                m_sign = MySign(((decimal)m_numerator / m_denominator + value) * m_sign);
                m_integer = Math.Abs(value);
            }
        }

        public virtual void Simplify()
        {
            if (m_numerator == 0)
                m_denominator = 1;

            m_sign = MySign(m_sign * (m_numerator + m_integer * m_denominator));
            m_integer = Math.Abs(m_integer);
            m_numerator = Math.Abs(m_numerator);
            m_denominator = Math.Abs(m_denominator);

            long gcd = GCD(m_numerator, m_denominator);

            m_numerator /= gcd;
            m_denominator /= gcd;

            //if (m_denominator == 0)
            //    throw new NotFiniteNumberException("Denominator is set to zero while simplifying the fraction: " + this.ToString());

            if (m_denominator < m_numerator)
                m_integer += Math.DivRem(m_numerator, m_denominator, out m_numerator);
        }

        public static Fraction Add(Fraction a, Fraction b)
        {
            long lcm = LCM(a.m_denominator, b.m_denominator);
            long d_a = lcm / a.m_denominator;
            long d_b = lcm / b.m_denominator;

            long i, n;
            sbyte s;

            i = a.m_integer * a.m_sign + b.m_integer * b.m_sign;
            n = a.m_numerator * d_a * a.m_sign + b.m_numerator * d_b * b.m_sign;
            s = MySign(i);
            if (n != 0)
            {
                if (Math.Sign(i) == -1 && MySign(n) == -1)
                {
                    i = -i;
                    n = -n;
                }
                else
                    if (Math.Sign(i) == -1 && MySign(n) == 1)
                    {
                        long k = Math.DivRem(n, lcm, out n);
                        i = -i - (k == 0 ? 1 : k);
                        n = (n == 0 ? 0 : lcm + n);
                    }
                    else
                        if (Math.Sign(i) == 1 && MySign(n) == -1)
                        {
                            long k = Math.DivRem(n, lcm, out n);
                            i = i - (k == 0 ? 1 : k);
                            n = (n == 0 ? 0 : lcm + n);
                        }

                long gcd = GCD(n, lcm);
                n /= gcd;
                lcm /= gcd;
            }
            if (i == 0)
                return new Fraction(n, lcm);
            else
                return new Fraction(Math.Abs(i) * s, (uint)n, (uint)lcm);
        }
        public static Fraction Negate(Fraction a)
        {
            Fraction f = (Fraction)(a.MemberwiseClone());
            f.m_sign *= -1;
            return f;
        }
        public static Fraction Substract(Fraction a, Fraction b)
        {
            return Add(a, Negate(b));
        }
        public static Fraction Multiply(Fraction a, Fraction b)
        {
            a.Simplify();
            b.Simplify();
            long d = a.m_denominator * b.m_denominator;
            long t, i, n;

            i = a.m_integer * b.m_integer + Math.DivRem(a.m_integer * b.m_numerator, b.m_denominator, out t);
            n = a.m_numerator * b.m_numerator + t * a.m_denominator;//t*lklkl??

            i += Math.DivRem(b.m_integer * a.m_numerator, a.m_denominator, out t);
            n += t * b.m_denominator;

            long gcd = GCD(n, d);
            n /= gcd;
            d /= gcd;

            i += Math.DivRem(n, d, out n);

            if (i == 0)
                return new Fraction(n * a.m_sign * b.m_sign, d);
            else
                return new Fraction(i * a.m_sign * b.m_sign, (uint)n, (uint)d);
        }
        public static Fraction Divide(Fraction a, Fraction b)
        {
            return Fraction.Multiply(a, new Fraction(b.m_denominator * b.m_sign, b.m_integer * b.m_denominator + b.m_numerator));
            //Fraction div = new Fraction(
            //    (a.m_integer * a.m_denominator * MySign(a.m_numerator) + a.m_numerator) * b.m_denominator,
            //    (b.m_integer * b.m_denominator * MySign(b.m_numerator) + b.m_numerator) * a.m_denominator);
            //div.Simplify();
            //return div;
        }
        public static Fraction Simplify(Fraction a)
        {
            a.Simplify();
            return a;
        }

        public static long GCD(long a, long b)
        {
            if (a <= 1 || b <= 1)
                return 1;
            // ���. �������� ������� ��� ������ ���
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                    if (a > b)
                    {
                        Math.DivRem(a, b, out a);
                        if (a == 0)
                            return b;
                    }
                    continue;
                }
                if (b > a)
                {
                    b = b - a;
                    if (b > a)
                    {
                        Math.DivRem(b, a, out b);
                        if (b == 0)
                            return a;
                    }
                }
            }
            return a;
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

                return
                    _f1.m_sign == _f2.m_sign &&
                    _f1.m_denominator == _f2.m_denominator &&
                    ((decimal)_f1.m_numerator / _f1.m_denominator + _f1.m_integer ==
                    (decimal)_f2.m_numerator / _f2.m_denominator + _f2.m_integer);

                //_f1.m_sign == _f2.m_sign &&
                //_f1.m_integer == _f2.m_integer &&
                //_f1.m_numerator == _f2.m_numerator &&
                //_f1.m_denominator == _f2.m_denominator;
            }
            if (obj is decimal)
            {
                return Value.Equals((obj as Fraction).Value);
            }

            return base.Equals(obj);
            //throw new ArgumentException("Cannot compare arguments");
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        //
        // Summary:
        //     Converts the string representation of a number to its Fraction
        //     equivalent. Format: [-]iii nnn/ddd
        //
        // Parameters:
        //   s:
        //     A string containing a number to convert.
        //
        // Returns:
        //     A Fraction equivalent to the number contained in s.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     s is null.
        //
        //   System.OverflowException
        //
        //   System.FormatException:
        //     s is not in the correct format.
        public static Fraction Parse(string s)
        {
            if (s == null)
                throw new ArgumentNullException("s is null");

            int iSlash = s.IndexOf('/');

            if (iSlash > -1 && s.LastIndexOf('/') != iSlash)
                throw new FormatException("Only one line in a fraction is permitted." +
                    Environment.NewLine + "Format: [{+|-}][iii] nnn/ddd");

            if (iSlash > -1)
            {
                sbyte sign = 1;

                s = s.TrimStart();

                if (s.StartsWith("-"))
                {
                    sign = -1;
                    s = s.Remove(0, 1);
                }
                if (s.StartsWith("+"))
                {
                    s = s.Remove(0, 1);
                }

                iSlash = s.IndexOf('/');

                if (iSlash == s.Length - 1)
                    throw new FormatException("Please, check the fraction format.");

                long denominator;
                if (!long.TryParse(s.Substring(iSlash + 1), out denominator))
                    throw new FormatException("Please, check the denominator format.");

                string[] sIntAndNum;
                sIntAndNum = s.Substring(0, iSlash).Split(
                    new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                long numerator = 0;
                long integer = 0;
                if (sIntAndNum.Length >= 1)
                {
                    //if (sIntAndNum[0] == "")
                    //    throw new FormatException("Please, check the numerator format.");

                    if (!long.TryParse(sIntAndNum[0], out numerator))
                        throw new FormatException("Please, check the numerator format.");
                }
                if (sIntAndNum.Length == 2)
                {
                    integer = numerator;

                    if (sIntAndNum[1] == "")
                        throw new FormatException("Please, check the integer part format.");

                    if (!long.TryParse(sIntAndNum[1], out numerator))
                        throw new FormatException("Please, check the integer part format.");

                    if ((integer < 0) || (numerator < 0))
                        throw new FormatException("Please, check the integer part format.");
                }

                if (sIntAndNum.Length > 2)
                    throw new FormatException("Bad integer part or numerator format.");


                return Fraction.Simplify(new Fraction(integer * sign, (uint)numerator, (uint)denominator));
            }
            else
            {
                return new Fraction(long.Parse(s), 0, 1);
            }
        }
        //
        // Summary:
        //     Converts the string representation of a number to its Fraction
        //     equivalent. A return value indicates whether the conversion succeeded or
        //     failed. Format: [-]iii nnn/ddd
        //
        // Parameters:
        //   s:
        //     A string containing a number to convert.
        //
        //   result:
        //     When this method returns, contains the Fraction value equivalent
        //     to the number contained in s, if the conversion succeeded, or zero if the
        //     conversion failed. The conversion fails if the s parameter is null, is not
        //     of the correct format. This parameter is passed uninitialized.
        //
        // Returns:
        //     true if s was converted successfully; otherwise, false.
        public static bool TryParse(string s, out Fraction result)
        {
            result = null;
            try
            {
                result = Fraction.Parse(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return this.ToString("W");
        }
        public string ToString(string format)
        {
            if ((this.m_integer == 0) && (this.m_numerator == 0))
                return "0";
            if (this.m_numerator == 0)
                return (this.m_integer * this.m_sign).ToString();
            //if (this.m_integer * this.m_denominator + this.m_numerator == m_denominator)
            //    return m_sign.ToString();

            if (this.m_denominator == 1)
                return ((m_integer + m_numerator) * m_sign).ToString();

            if (format.ToUpper().StartsWith("R"))
                return string.Format("{0}{1} {2}/{3}",
                    m_sign > 0 ? "" : "-",
                    (m_integer != 0 ? m_integer.ToString() : "") + " ",
                    m_numerator,
                    m_denominator);

            if (format.ToUpper().StartsWith("W"))
                return string.Format("{0}{1}/{2}",
                    m_sign > 0 ? "" : "-",
                    m_integer * m_denominator + m_numerator,
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
            if ((object)f2 == null && (object)f1 == null)
                return true;
            if ((object)f2 == null || (object)f1 == null)
                return false;
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

        protected static sbyte MySign(long num)
        {
            int sign = Math.Sign(num);
            return sign == 0 ? (sbyte)1 : (sbyte)sign;
        }
        protected static sbyte MySign(decimal num)
        {
            int sign = Math.Sign(num);
            return sign == 0 ? (sbyte)1 : (sbyte)sign;
        }
    }

    public struct FractionPoint
    {
        private Fraction x, y;

        //
        // Summary:
        //     Initializes a new instance of the FractionPoint class with the specified
        //     coordinates.
        //
        // Parameters:
        //   y:
        //     The vertical position of the point.
        //
        //   x:
        //     The horizontal position of the point.
        public FractionPoint(Fraction x, Fraction y)
        {
            if (x == null)
                throw new ArgumentNullException("x");
            if (y == null)
                throw new ArgumentNullException("y");

            this.x = (Fraction)x.Clone();
            this.y = (Fraction)y.Clone();
        }

        //
        // Summary:
        //     Determines whether the coordinates of the specified points are not equal.
        //
        // Parameters:
        //   right:
        //     A FractionPoint to compare.
        //
        //   left:
        //     A FractionPoint to compare.
        //
        // Returns:
        //     true to indicate the FractionPoint.X and FractionPoint.Y
        //     values of left and right are not equal; otherwise, false.
        public static bool operator !=(FractionPoint left, FractionPoint right)
        {
            return !(left == right);                
        }
        //
        // Summary:
        //     Compares two FractionPoint structures. The result specifies whether
        //     the values of the FractionPoint.X and FractionPoint.Y properties
        //     of the two FractionPoint structures are equal.
        //
        // Parameters:
        //   right:
        //     A FractionPoint to compare.
        //
        //   left:
        //     A FractionPoint to compare.
        //
        // Returns:
        //     true if the FractionPoint.X and FractionPoint.Y values of
        //     the left and right FractionPoint structures are equal; otherwise,
        //     false.
        public static bool operator ==(FractionPoint left, FractionPoint right)
        {
            if ((left == null) && (right == null))
                return true;
            else if ((left == null) || (right == null))
                return false;

            return ((left.x == right.x) && (left.y == right.y));
        }

        //
        // Summary:
        //     Gets or sets the x-coordinate of this FractionPoint.
        //
        // Returns:
        //     The x-coordinate of this FractionPoint.
        public Fraction X
        {
            get
            {
                return (Fraction)this.x.Clone();
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("x");

                x = (Fraction)value.Clone();
            }
        }
        //
        // Summary:
        //     Gets or sets the y-coordinate of this System.Drawing.FractionPoint.
        //
        // Returns:
        //     The y-coordinate of this System.Drawing.FractionPoint.
        public Fraction Y
        {
            get
            {
                return (Fraction)this.y.Clone();
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("y");

                y = (Fraction)value.Clone();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is FractionPoint)
                return this == (FractionPoint)obj;
            else
                throw new ArgumentException("Object is not a Fraction");
        }
        //
        // Summary:
        //     Returns a hash code for this System.Drawing.FractionPoint structure.
        //
        // Returns:
        //     An integer value that specifies a hash value for this System.Drawing.FractionPoint
        //     structure.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("X:{0}, Y:{1}", x, y);
        }
    }
}
