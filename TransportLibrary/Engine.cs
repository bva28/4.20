using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLibrary
{
	/// <summary>
	/// Класс Двигатель.
	/// </summary>
	public class Engine
	{
		/// <summary>
		/// Свойство вид двигателя.
		/// </summary>
		public EngineType EngineType
		{
			get; set;
		}

		/// <summary>
		/// Мощность двигателя.
		/// </summary>
		private int _power;

		/// <summary>
		/// Свойство Мощность двигателя.
		/// </summary>
		public int Power
		{
			get => _power;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException
						("Мощность должна быть положительной");
				}

				_power = value;
			}
		}

		/// <summary>
		/// Конструктор класса двигатель.
		/// </summary>
		/// <param name="power">Мощность.</param>
		/// <param name="engineType">Тип двигателя.</param>
		public Engine(int power, EngineType engineType)
		{
			Power = power;
			EngineType = engineType;
		}

		/// <summary>
		/// Конструктор с параметрами по умолчанию.
		/// </summary>
		public Engine() : this(100, EngineType.Petrol)
		{ }

		/// <summary>
		/// Определение коэфициента расхода в зависимости от объема и типа двигателя.
		/// </summary>
		/// <returns>Коэффициент расхода.</returns>
		public double СalculateExpense()
		{
			double сonsumptionСapacity = 0.1 * Power;

			Dictionary<EngineType, double> сonsumptionFuel = new()
			{
				{EngineType.Diesel, 0.75},
				{EngineType.Petrol, 1},
				{EngineType.Electricity, 0.5},
				{EngineType.GasTurbine, 2},
			};

			double сonsumption = (сonsumptionСapacity * сonsumptionFuel[EngineType])/100;

			return сonsumption;
		}
	}
}
