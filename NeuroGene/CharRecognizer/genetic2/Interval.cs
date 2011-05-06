using System;
using System.Collections.Generic;
using System.Text;

namespace Jenyay.Genetic
{
	public class Interval
	{
		double m_minVal = double.MinValue;

		/// <summary>
		/// ����������� �������� ���������
		/// </summary>
		public double MinValue
		{
			get { return m_minVal; }
			set { m_minVal = value; }
		}


		double m_maxVal = double.MaxValue;

		/// <summary>
		/// ������������ �������� ���������
		/// </summary>
		public double MaxValue
		{
			get { return m_maxVal; }
			set { m_maxVal = value; }
		}

		public Interval (double minval, double maxval)
		{
			m_minVal = minval;
			m_maxVal = maxval;
		}

		/// <summary>
		/// �������� �� �������� � �������� ��������
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public bool IsInside (double val)
		{
			return val >= m_minVal && val <= m_maxVal;
		}
	}
}
