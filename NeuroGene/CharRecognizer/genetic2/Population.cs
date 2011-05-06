using System;
using System.Collections.Generic;

namespace NeuroGenes.Genetic
{
	/// <summary>
	/// ���������, ����� �������� �������� ����� ���������, � ������� ����� ���
	/// </summary>
	class ZeroSizePopulationException: Exception
	{
	}

	/// <summary>
	/// ����� ���������. ��� ���� ������������ � ����� � ���������
	/// </summary>
	public class Population<TSpecies> where TSpecies:BaseSpecies<TSpecies>
	{
		/// <summary>
		/// ����� �������� ���������
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
		/// ����� ������ ��� ����
		/// </summary>
		protected List<TSpecies> m_Species = new List<TSpecies> ();

		/// <summary>
		/// ������������ ����� �����, ������� ����� ��������� ���������
		/// </summary>
		protected Int32 m_MaxSize = 500;

		/// <summary>
		/// ������������ ����� �����, ������� ����� ��������� ���������
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
						"������ ��������� ������ ���� ������ 2");
				}

				m_MaxSize = value;
			}
		}

		/// <summary>
		/// ����������� �����������
		/// </summary>
		protected double m_CrossPossibility = 0.95;

		/// <summary>
		/// ����������� �����������
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
						"����������� ����������� ������ ���� ������������� � ������ 1.0");
				}

				m_CrossPossibility = value;
			}
		}

		/// <summary>
		/// ����������� �������
		/// </summary>
		protected double m_MutationPossibility = 0.1;

		/// <summary>
		/// ����������� �������
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
						"����������� ������� ������ ���� ������������� � ������ 1.0");
				}

				m_MutationPossibility = value;
			}
		}

		public Population()
		{
		}

		Random m_Rnd = new Random();

		/// <summary>
		/// �������� ��������� (�������� ��������� ���������)
		/// </summary>
		virtual public void NextGeneration()
		{
			if (m_Generation == 0 && m_Species.Count == 0)
			{
				throw new ZeroSizePopulationException();
			}

			// ������� ��������
			Cross();
			
			// ����������� � ������ �������� ��� ���������
			foreach (TSpecies species in m_Species)
			{
				// ���� ���� ���������� � ������ �����������.
				if (m_Rnd.NextDouble() <= m_MutationPossibility)
				{
					species.Mutation();
				}

				species.TestChromosomes();
			}

			// ������� ����� ������� ����
			m_Species.Sort();
			Selection();

			m_Generation++;
		}

		#region ��������������� ������� ��� ��������� ������ ���������

		/// <summary>
		/// �������� ����� ���� ������������
		/// </summary>
		protected void Cross()
		{
			// ������ �� ������ ���������� ��������� (����� �� ���������� ����� ����,
			// ������� ����������� � ����� ������)
			Int32 OldSize = m_Species.Count;

			// ����� ���� ��� ������������� ����
			Int32 Count = m_Species.Count;

			for (int i = 0; i < Count; ++i)
			{
				// ���� ���� ���������� � ������ �����������.
				if (m_Rnd.NextDouble() <= m_CrossPossibility)
				{
					// ��������� � ������ ���, ���������� ������������ ���������� ���� �
					// ���� �� ��������� �������.
					m_Species.Add (m_Species[i].Cross (m_Species[m_Rnd.Next (OldSize)] ) );
				}
			}
		}

		/// <summary>
		/// �������� ��������� �������� ������� �������
		/// </summary>
		public double BestFunc
		{
			get
			{
				return m_Species[0].FinalFunc;
			}
		}

		/// <summary>
		/// �������� ������ ���
		/// </summary>
		public TSpecies BestSpecies
		{
			get
			{
				return m_Species[0];
			}
		}

		/// <summary>
		/// ���������� ����� ����� "�������" �����
		/// </summary>
		protected void Selection()
		{
			// ������� ����� ���� �������
			Int32 Count = m_Species.Count - m_MaxSize;

			for (Int32 i = 0; i < Count; ++i)
			{
				m_Species.RemoveAt (m_Species.Count - 1);
			}
		}

		#endregion

		/// <summary>
		/// ���������� True, ���� ��������� � ������ (��� ���� ����������)
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
		/// �������� ��� � ���������
		/// </summary>
		/// <param name="species">����� ���</param>
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
