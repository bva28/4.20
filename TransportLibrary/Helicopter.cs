using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLibrary
{
	//TODO: XML
	public class Helicopter : TransportBase
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
		public override double RatioMass { get; } = 0.000154;

		/// <summary>
		/// Конструктор класса Вертолет.
		/// </summary>
		/// <param name="engine">Двигатель.</param>
		/// <param name="mass">Масса (кг).</param>
		public Helicopter(Engine engine, int mass)
		{
			Engine = engine;
			Mass = mass;
		}

		/// <summary>
		/// Конструктор с параметрами по умолчанию.
		/// </summary>
		public Helicopter() : this(new Engine(1900, EngineType.GasTurbine), 6500)
		{ }

		/// <summary>
		/// Переопределенный метод Расчета расхода топлива.
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
