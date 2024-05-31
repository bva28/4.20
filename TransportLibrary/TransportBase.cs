using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLibrary
{
	/// <summary>
	/// Абстрактный класс TransportBase.
	/// </summary>
	public abstract class TransportBase
	{
		/// <summary>
		/// Масса.
		/// </summary>
		private int _mass;

		/// <summary>
		/// Свойство Масса.
		/// </summary>
		public int Mass
		{
			get => _mass;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException
						("Масса должна быть положительной");
				}

				_mass = value;
			}
		}

		/// <summary>
		/// Коэфициент пересчета массы.
		/// </summary>
		public virtual double RatioMass { get; }

		/// <summary>
		/// Метод расчета расхода топлива.
		/// </summary>
		/// <param name="distance">Расстояние.</param>
		/// <returns>Расход топлива (л).</returns>
		public abstract double CalculateFuel(double distance);
	}
}
