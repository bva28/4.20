using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLibrary
{
	//TODO: XML
	public class HybridCar : Car
	{
		/// <summary>
		/// Мощность электродвигателя кВт
		/// </summary>
		private Engine _electricMotorPower;

		/// <summary>
		/// Свойство электродвигателя.
		/// </summary>
		public Engine ElectricMotorPower
		{
			get => _electricMotorPower;
			set
			{
				if ((value.EngineType == Engine.EngineType) && 
					(value.EngineType != EngineType.Electricity))
				{
					throw new ArgumentException("Вспомогательный двигатель " +
						"должен быть электрическим");
				}

				if (value is null)
				{
					throw new NullReferenceException
							  ("Передано null");
				}

				_electricMotorPower = value;
			}
		}

		/// <summary>
		/// Конструктор класса Гибридная Машина.
		/// </summary>
		/// <param name="motor">Основной Двигатель.</param>
		/// <param name="mass">Масса.</param>
		/// <param name="additionalMotor">Дополнительный двигатель.</param>
		/// <param name="fielPer100km">Расход на 100 км.</param>
		public HybridCar(Engine motor, int mass, Engine electricMotorPower) :
			base(motor, mass)
		{
			ElectricMotorPower = electricMotorPower;
		}

		/// <summary>
		/// Конструктор с параметрами по умолчанию.
		/// </summary>
		public HybridCar() : this(new Engine(100, EngineType.Petrol), 1000,
			new Engine(50, EngineType.Electricity))
		{ }

		/// <summary>
		/// Переопределенный метод Расчета расхода топлива.
		/// </summary>
		/// <param name="distance">Растояние км.</param>
		/// <returns></returns>
		public double CalculateFuel(double distance)
		{
			double coeffСonsumptionBase = Engine.СalculateExpense();

			double coeffСonsumptionAdd = ElectricMotorPower.СalculateExpense();

			return ((distance * coeffСonsumptionAdd * (RatioMass * Mass))
				- (distance * coeffСonsumptionBase * (RatioMass * Mass)));
		}
	}
}
