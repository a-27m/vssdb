using System;
using System.Collections.Generic;
using System.Text;

namespace Jenyay.Genetic
{
	public class Analytics<TSpecies>
		where TSpecies: BaseDoubleSpecies<TSpecies>
	{
		/// <summary>
		/// ����� ������ ������ ������ � ������ ���������
		/// </summary>
		List<BaseDoubleSpecies<TSpecies>> m_bestSpecies = new List<BaseDoubleSpecies<TSpecies>> ();

		public List<BaseDoubleSpecies<TSpecies>> BestSpecies
		{
			get { return m_bestSpecies; }
		}

		/// <summary>
		/// �������� ����� � ������
		/// </summary>
		/// <param name="species"></param>
		public void Add (BaseDoubleSpecies<TSpecies> species)
		{
			m_bestSpecies.Add ((BaseDoubleSpecies<TSpecies>)species.Clone ());
		}

		/// <summary>
		/// �������� ������ ������
		/// </summary>
		public void Clear ()
		{
			m_bestSpecies.Clear ();
		}

		/// <summary>
		/// �������� ���������� � ���� ��������
		/// </summary>
		/// <remarks>�������: ���������1, ���������2, ..., ������� �������</remarks>
		/// <returns></returns>
		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder ();

			foreach (BaseDoubleSpecies<TSpecies> species in m_bestSpecies)
			{
				foreach (double chromosome in species.Cromosomes)
				{
					sb.AppendFormat ("{0}    ", chromosome);
				}

				sb.AppendFormat ("{0}\r\n", species.FinalFunc);
			}

			return sb.ToString ();
		}
	}
}
