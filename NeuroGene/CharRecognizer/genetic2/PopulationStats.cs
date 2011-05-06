using System;
using System.Collections.Generic;
using System.Text;

namespace Jenyay.Genetic
{
	public class PopulationStats<TSpecies> : Population<TSpecies> 
		where TSpecies : BaseSpecies<TSpecies>, ICloneable
	{
		/// <summary>
		/// Лучшие решения. Первый индекс - номер популяции, второй - номер запуска.
		/// </summary>
		List<List<TSpecies>> m_bestSpeciesStats = new List<List<TSpecies>> ();

		public List<List<TSpecies>> BestSpeciesStats
		{
			get { return m_bestSpeciesStats; }
		}

		public PopulationStats ()
			:base()
		{
			// Добавим в 0-й элемент пустой список. 0-е поколение нас интересовать не будет
			m_bestSpeciesStats.Add (new List<TSpecies> ());
		}

		public override void NextGeneration ()
		{
			base.NextGeneration ();

			if (m_bestSpeciesStats.Count == m_Generation)
			{
				m_bestSpeciesStats.Add (new List<TSpecies> ());
			}

			m_bestSpeciesStats[m_Generation].Add ((TSpecies)this.BestSpecies.Clone());
		}
	}
}
