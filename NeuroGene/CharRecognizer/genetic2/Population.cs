using System;
using System.Collections.Generic;

namespace NeuroGenes.Genetic
{
	/// <summary>
	/// Бросается, когда пытаемся получить новое поколение, а готовых видов нет
	/// </summary>
	class ZeroSizePopulationException: Exception
	{
	}

	/// <summary>
	/// Класс популяции. Все виды размножаются и живут в популяции
	/// </summary>
	public class Population<TSpecies> where TSpecies:BaseSpecies<TSpecies>
	{
		/// <summary>
		/// Номер текущего поколения
		/// </summary>
		protected Int32 m_Generation = 0;

		public Int32 Generation
		{
			get
			{
				return m_Generation;
			}
		}

		/// <summary>
		/// Здесь храним все виды
		/// </summary>
		protected List<TSpecies> m_Species = new List<TSpecies> ();

		/// <summary>
		/// Максимальное число видов, которое может содержать популяция
		/// </summary>
		protected Int32 m_MaxSize = 500;

		/// <summary>
		/// Максимальное число видов, которое может содержать популяция
		/// </summary>
		public Int32 MaxSize
		{
			get
			{
				return m_MaxSize;
			}
			set
			{
				if (value < 2)
				{
					throw new ArgumentOutOfRangeException("MaxSize", value, 
						"Размер популяции должен быть больше 2");
				}

				m_MaxSize = value;
			}
		}

		/// <summary>
		/// Вероятность скрещивания
		/// </summary>
		protected double m_CrossPossibility = 0.95;

		/// <summary>
		/// Вероятность скрещивания
		/// </summary>
		public double CrossPossibility
		{
			get
			{
				return m_CrossPossibility;
			}

			set
			{
				if (value <= 0  || value > 1.0)
				{
					throw new ArgumentOutOfRangeException("CrossPossibility", value, 
						"Вероятность скрещивания должна быть положительной и меньше 1.0");
				}

				m_CrossPossibility = value;
			}
		}

		/// <summary>
		/// Вероятность мутации
		/// </summary>
		protected double m_MutationPossibility = 0.1;

		/// <summary>
		/// Вероятность мутации
		/// </summary>
		public double MutationPossibility
		{
			get
			{
				return m_MutationPossibility;
			}

			set
			{
				if (value < 0  || value > 1.0)
				{
					throw new ArgumentOutOfRangeException("MutationPossibility", value, 
						"Вероятность мутации должна быть положительной и меньше 1.0");
				}

				m_MutationPossibility = value;
			}
		}

		public Population()
		{
		}

		Random m_Rnd = new Random();

		/// <summary>
		/// Обновить популяцию (получить следующее поколение)
		/// </summary>
		virtual public void NextGeneration()
		{
			if (m_Generation == 0 && m_Species.Count == 0)
			{
				throw new ZeroSizePopulationException();
			}

			// Сначала скрестим
			Cross();
			
			// Промутируем и заодно проверим все хромосомы
			foreach (TSpecies species in m_Species)
			{
				// Если надо мутировать с учетом вероятности.
				if (m_Rnd.NextDouble() <= m_MutationPossibility)
				{
					species.Mutation();
				}

				species.TestChromosomes();
			}

			// Отберем самые живучие виды
			m_Species.Sort();
			Selection();

			m_Generation++;
		}

		#region Вспомогательные функции для получения нового поколения

		/// <summary>
		/// Получить новые виды скрещиванием
		/// </summary>
		protected void Cross()
		{
			// Размер до начала пополнения популяции (чтобы не скрещивать новые виды,
			// которые добавляются в конец списка)
			Int32 OldSize = m_Species.Count;

			// Номер пары для скрещиваемого вида
			Int32 Count = m_Species.Count;

			for (int i = 0; i < Count; ++i)
			{
				// Если надо скрещивать с учетом вероятности.
				if (m_Rnd.NextDouble() <= m_CrossPossibility)
				{
					// Добавляем в список вид, полученный скрещиванием очередного вида и
					// вида со случайным номером.
					m_Species.Add (m_Species[i].Cross (m_Species[m_Rnd.Next (OldSize)] ) );
				}
			}
		}

		/// <summary>
		/// Получить наилучшее значение целевой функции
		/// </summary>
		public double BestFunc
		{
			get
			{
				return m_Species[0].FinalFunc;
			}
		}

		/// <summary>
		/// Получить лучший вид
		/// </summary>
		public TSpecies BestSpecies
		{
			get
			{
				return m_Species[0];
			}
		}

		/// <summary>
		/// Произвести отбор самых "живучих" видов
		/// </summary>
		protected void Selection()
		{
			// Сколько видов надо удалить
			Int32 Count = m_Species.Count - m_MaxSize;

			for (Int32 i = 0; i < Count; ++i)
			{
				m_Species.RemoveAt (m_Species.Count - 1);
			}
		}

		#endregion

		/// <summary>
		/// Возвращает True, если популяция в тупике (все виды одинаковые)
		/// </summary>
		public Boolean Impasse
		{
			get
			{
				Boolean res = true;
				TSpecies FirstSpecies = m_Species[0];

				foreach (TSpecies species in m_Species)
				{
					if (species.CompareTo(FirstSpecies) != 0)
					{
						res = false;
						break;
					}
				}

				return res;
			}
		}

		/// <summary>
		/// Добавить вид в популяцию
		/// </summary>
		/// <param name="species">Новый вид</param>
		public void Add (TSpecies species)
		{
			m_Species.Add(species);
		}

		public void Reset()
		{
			m_Generation = 0;
			m_Species.Clear();
		}
	}
}
