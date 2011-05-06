using System;
//using System.Diagnostics;

namespace NeuroGenes.Genetic
{
	/// <summary>
	/// ������� ����� ��� ����
	/// </summary>
	abstract public class BaseSpecies<TSpecies>: IComparable 
		where TSpecies: BaseSpecies<TSpecies>
	{
		/// <summary>
		/// ������������ ��� ��������� ������� ����������� �������� � �������
		/// </summary>
		static protected Random m_Rnd = new Random();

		#region ����������� ������� ��� ����������� �������� ������� �����
		/// <summary>
		/// ��������� ��� ��������� ���� double
		/// </summary>
		/// <param name="x">1-� ���������</param>
		/// <param name="y">2-� ���������</param>
		/// <returns>����� ���������</returns>
		static protected double Cross (double x, double y)
		{
			Int64 ix = BitConverter.DoubleToInt64Bits(x);
			Int64 iy = BitConverter.DoubleToInt64Bits(y);

			double res = BitConverter.Int64BitsToDouble(BitCross(ix, iy));

			if (m_Rnd.Next() % 2 == 0)
			{
				if (x * res < 0)
				{
					res = -res;
				}
			}
			else
			{
				if (y * res < 0)
				{
					res = -res;
				}
			}

			return res;

			//return (x + y) / 2.0;
		}
		
		/// <summary>
		/// ��������� ��� ��������� ���� int
		/// </summary>
		/// <param name="x">1-� ���������</param>
		/// <param name="y">2-� ���������</param>
		/// <returns>����� ���������</returns>
		static protected Int32 Cross (Int32 x, Int32 y)
		{
			// ����� ���, ���������� ����� �� ����� ����������� ��������
			Int32 Count = m_Rnd.Next(1, 31);
			Int32 mask = ~0;

			mask = mask << (32 - Count);

			//Debug.Assert(mask != 0 && mask != ~0 ,String.Format("mask = {0}", mask));

            Int32 res = (x & mask) | (y & ~mask);

			if (m_Rnd.Next() % 2 == 0)
			{
				if (x * res < 0)
				{
					res = -res;
				}
			}
			else
			{
				if (y * res < 0)
				{
					res = -res;
				}
			}

			return res;
		}
		
		/// <summary>
		/// ��������� �������� ��� ����� ����� ��� ��������� ���� Int64
		/// </summary>
		/// <param name="x">1-� ���������</param>
		/// <param name="y">2-� ���������</param>
		/// <returns>����� ���������</returns>
		static protected Int64 BitCross (Int64 x, Int64 y)
		{
			// ����� ���, ���������� ����� �� ����� ����������� ��������
			int Count = m_Rnd.Next(62) + 1;
			Int64 mask = ~0;

			mask = mask << (64 - Count);

            return (x & mask) | (y & ~mask);
		}

		/// <summary>
		/// ��������� �������� � ������ ����� ��� ��������� ���� Int64
		/// </summary>
		/// <param name="x">1-� ���������</param>
		/// <param name="y">2-� ���������</param>
		/// <returns>����� ���������</returns>
		static protected Int64 Cross (Int64 x, Int64 y)
		{
			/*// ����� ���, ���������� ����� �� ����� ����������� ��������
			int Count = m_Rnd.Next(62) + 1;
			Int64 mask = ~0;

			mask = mask << (64 - Count);

            return (x & mask) | (y & ~mask);*/

			Int64 res = BitCross(x, y);

			if (m_Rnd.Next() % 2 == 0)
			{
				if (x * res < 0)
				{
					res = -res;
				}
			}
			else
			{
				if (y * res < 0)
				{
					res = -res;
				}
			}

			return res;
		}

		/*protected Int64 Cross2 (Int64 x, Int64 y)
		{
			Int64 a = x;
			Int64 b = y;

			int Count1 = 0;
			for (Count1 = 0; a != 0; a /= 10, Count1++);

			int Count2 = 0;
			for (Count2 = 0; b != 0; b /= 10, Count2++);

			Int32 n1 = Math.Max(Count1, Count2) - 1;
			Int32 n2 = m_Rnd.Next(n1 + 1);
			Int64 t1 = (Int64)(a / Math.Pow(10, n2));
			Int64 t2 = (Int64)(Math.Abs(b) - (Int64)(Math.Abs(b) / Math.Pow(10, n2)) * Math.Pow(10, n2));

			Int64 res = (Int64)(Math.Abs(t1) * Math.Pow(10, n2) + t2);
			if (res * x < 0)
			{
				res = -res;
			}

			return res;
		}*/
		#endregion
		
		#region ������ ��� ������� � ������� �����
		/// <summary>
		/// ������� ��� ���� double
		/// </summary>
		/// <param name="val">���������� ��������</param>
		/// <returns>������������� ��������</returns>
		static protected double Mutation (double val)
		{
			UInt64 x = BitConverter.ToUInt64(BitConverter.GetBytes(val), 0);
			//Int64 mask = (1 << m_Rnd.Next(63));

			UInt64 mask = 1;
			mask <<= m_Rnd.Next(63);
			x ^= mask;

			double res = BitConverter.ToDouble(BitConverter.GetBytes(x), 0);

//			Debug.Assert(!double.IsNaN(res), 
//				String.Format("val = {0}   mask = {1}   x = {2}", val, mask, x));

			return res;
		}

		/// <summary>
		/// ������� ��� ���� Int32
		/// </summary>
		/// <param name="val">���������� ��������</param>
		/// <returns>������������� ��������</returns>
		static protected Int32 Mutation (Int32 val)
		{
			Int32 mask = (1 << m_Rnd.Next(31));

			return val ^ mask;
		}

		/// <summary>
		/// ������� ��� ���� Int64
		/// </summary>
		/// <param name="val">���������� ��������</param>
		/// <returns>������������� ��������</returns>
		static protected Int64 Mutation (Int64 val)
		{
			//Int64 mask = (1 << m_Rnd.Next(63));

			Int64 mask = 1;
			mask <<= m_Rnd.Next(63);

			return val ^ mask;
		}

		#endregion

		/// <summary>
		/// ����� �� ���.
		/// </summary>
		/// <remarks>��������, ����� ��������� �� �������� � �������� ��������</remarks>
		protected Boolean m_Dead = false;

		/// <summary>
		/// ������� �� ���?
		/// </summary>
		public bool Dead
		{
			get	{ return m_Dead; }
		}

		/// <summary>
		/// ���������, ����� ��� ��������� ������ �� � �������� ���������. 
		/// � ��������� ������ �������� ��� ��� "�������".
		/// </summary>
		abstract public void TestChromosomes();

		/// <summary>
		/// ����� ��� ����������� ���� � ������ �����
		/// </summary>
		/// <param name="Species">������ ���</param>
		/// <returns>���������� ���</returns>
		abstract public TSpecies Cross (TSpecies Species);

		/// <summary>
		/// ���������� �������
		/// </summary>
		abstract public void Mutation();

		/// <summary>
		/// ������� �������. ������ � ������ �������� ������ �������� ���������� � ������ ��������
		/// </summary>
		/// <returns>�������� ������� �������</returns>
		abstract public double FinalFunc
		{
			get;
		}

		#region IComparable Members

		/// <summary>
		/// ��� ��������� ������, ���� �� ����� ��� � ���� ������ ������� �������
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public Int32 CompareTo(object obj)
		{
			TSpecies Other = (TSpecies)obj;

			Int32 res = 0;

			// ���� ��� �����, � ������ - ���
			if (this.Dead && !Other.Dead)
			{
				res = 1;
			}
			else if (!this.Dead && Other.Dead)
			{
				// ���� ��� ���, � ������ ��� �����
				res = -1;
			}
			else
			{
				// "��� ��� ����..." (c) :)
				// ��� ���������� ������� �������

				double ThisFunc = this.FinalFunc;
				double OtherFunc = Other.FinalFunc;
				if (ThisFunc > OtherFunc)
				{
					res = 1;
				}
				else if (ThisFunc < OtherFunc)
				{
					res = -1;
				}
			}

			return res;
		}	// public Int32 CompareTo(object obj)

		#endregion
	}
}
