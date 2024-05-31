using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLibrary
{
	public class Car : TransportBase
	{
		/// <summary>
		/// Двигатель.
		/// </summary>
		private Engine _engine;

		/// <summary>
		/// Свойство Двигатель.
		/// </summary>
		public Engine Engine
		{
			get => _engine;
			set
			{
				if (value is null)
				{
					throw new NullReferenceException
							  ("Передано null");
				}

				_engine = value;
			}
		}

		/// <summary>
		/// Коэфициент пересчета массы.
		/// </summary>
		public override double RatioMass { get; } = 0.001;

		/// <summary>
		/// Конструктор класса Машина.
		/// </summary>
		/// <param name="motor">Двигатель.</param>
		/// <param name="mass">Масса (кг).</param>
		public Car(Engine engine, int mass)
		{
			Engine = engine;
			Mass = mass;
		}

		/// <summary>
		/// Конструктор с параметрами по умолчанию.
		/// </summary>
		public Car() : this(new Engine(100, EngineType.Petrol), 1000)
		{ }

		/// <summary>
		/// Переопределенный метод расчета расхода топлива.
		/// </summary>
		/// <param name="distance">Расстояние (км).</param>
		/// <returns>Расход топлива (л).</returns>
		public override double CalculateFuel(double distance)
		{
			double coeffСonsumption = Engine.СalculateExpense();

			return distance * coeffСonsumption * (RatioMass * Mass);
		}
	}
}
