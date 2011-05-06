using System;
//using System.Diagnostics;

namespace NeuroGenes.Genetic
{
	/// <summary>
	/// Базовый класс для вида
	/// </summary>
	abstract public class BaseSpecies<TSpecies>: IComparable 
		where TSpecies: BaseSpecies<TSpecies>
	{
		/// <summary>
		/// Используется для получения позиции пересечения хромосом и мутации
		/// </summary>
		static protected Random m_Rnd = new Random();

		#region Статические функции для скрещивания хромосом базовых типов
		/// <summary>
		/// Скрестить две хромосомы типа double
		/// </summary>
		/// <param name="x">1-я хромосома</param>
		/// <param name="y">2-я хромосома</param>
		/// <returns>Новая хромосома</returns>
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
		/// Скрестить две хромосомы типа int
		/// </summary>
		/// <param name="x">1-я хромосома</param>
		/// <param name="y">2-я хромосома</param>
		/// <returns>Новая хромосома</returns>
		static protected Int32 Cross (Int32 x, Int32 y)
		{
			// Число бит, оставшиеся слева от точки пересечения хромосом
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
		/// Скрестить побитово без учета знака две хромосомы типа Int64
		/// </summary>
		/// <param name="x">1-я хромосома</param>
		/// <param name="y">2-я хромосома</param>
		/// <returns>Новая хромосома</returns>
		static protected Int64 BitCross (Int64 x, Int64 y)
		{
			// Число бит, оставшиеся слева от точки пересечения хромосом
			int Count = m_Rnd.Next(62) + 1;
			Int64 mask = ~0;

			mask = mask << (64 - Count);

            return (x & mask) | (y & ~mask);
		}

		/// <summary>
		/// Скрестить побитово с учетом знака две хромосомы типа Int64
		/// </summary>
		/// <param name="x">1-я хромосома</param>
		/// <param name="y">2-я хромосома</param>
		/// <returns>Новая хромосома</returns>
		static protected Int64 Cross (Int64 x, Int64 y)
		{
			/*// Число бит, оставшиеся слева от точки пересечения хромосом
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
		
		#region Методы для мутаций в базовых типах
		/// <summary>
		/// Мутация для типа double
		/// </summary>
		/// <param name="val">Мутируемое значение</param>
		/// <returns>Промутирующее значение</returns>
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
		/// Мутация для типа Int32
		/// </summary>
		/// <param name="val">Мутируемое значение</param>
		/// <returns>Промутирующее значение</returns>
		static protected Int32 Mutation (Int32 val)
		{
			Int32 mask = (1 << m_Rnd.Next(31));

			return val ^ mask;
		}

		/// <summary>
		/// Мутация для типа Int64
		/// </summary>
		/// <param name="val">Мутируемое значение</param>
		/// <returns>Промутирующее значение</returns>
		static protected Int64 Mutation (Int64 val)
		{
			//Int64 mask = (1 << m_Rnd.Next(63));

			Int64 mask = 1;
			mask <<= m_Rnd.Next(63);

			return val ^ mask;
		}

		#endregion

		/// <summary>
		/// Мертв ли вид.
		/// </summary>
		/// <remarks>Например, когда хромосовы не попадают в заданные интервал</remarks>
		protected Boolean m_Dead = false;

		/// <summary>
		/// Мертвый ли вид?
		/// </summary>
		public bool Dead
		{
			get	{ return m_Dead; }
		}

		/// <summary>
		/// Проверяет, чтобы все хромосомы попали бы в заданные интервалы. 
		/// В противном случае помечает вид как "мертвый".
		/// </summary>
		abstract public void TestChromosomes();

		/// <summary>
		/// Метод для скрещивания себя с другим видом
		/// </summary>
		/// <param name="Species">Другой вид</param>
		/// <returns>Полученный вид</returns>
		abstract public TSpecies Cross (TSpecies Species);

		/// <summary>
		/// Произвести мутацию
		/// </summary>
		abstract public void Mutation();

		/// <summary>
		/// Целевая функция. Должна в случае удачного набора хромосом стремиться к своему минимуму
		/// </summary>
		/// <returns>Значение целевой функции</returns>
		abstract public double FinalFunc
		{
			get;
		}

		#region IComparable Members

		/// <summary>
		/// Вид считается больше, если он мертв или у него больше целевая функция
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public Int32 CompareTo(object obj)
		{
			TSpecies Other = (TSpecies)obj;

			Int32 res = 0;

			// Если сам мертв, а другой - нет
			if (this.Dead && !Other.Dead)
			{
				res = 1;
			}
			else if (!this.Dead && Other.Dead)
			{
				// Если сам жив, а другой вид мертв
				res = -1;
			}
			else
			{
				// "Там все живы..." (c) :)
				// Все определяет целевая функция

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
