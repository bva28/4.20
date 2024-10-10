namespace TransportLibrary
{
    /// <summary>
    /// Класс Гибридная Машина.
    /// </summary>
    public class HybridCar : Car
    {
        /// <summary>
        /// Дополнительный двигатель.
        /// </summary>
        private Engine _electricMotorPower;

        /// <summary>
        /// Конструктор класса Гибридная Машина.
        /// </summary>
        /// <param name="motor">Основной Двигатель.</param>
        /// <param name="mass">Масса.</param>
        /// <param name="electricMotorPower">Дополнительный двигатель.</param>
        /// <param name="fielPer100km">Расход на 100 км.</param>
        public HybridCar(Engine motor, double mass, Engine electricMotorPower) :
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
        /// Свойство Дополнительный двигатель.
        /// </summary>
        public Engine ElectricMotorPower
        {
            get => _electricMotorPower;
            set
            {
                if (value.EngineType == Engine.EngineType)
                {
                    throw new ArgumentException("Вид топлива основного " +
                        "двигателя и дополнительного должны отличаться");
                }

                if (value is null)
                {
                    throw new NullReferenceException
                              ("Передано null");
                }

                _electricMotorPower = value;
            }
        }

        /// <inheritdoc/>
        public override string FuelConsumption
        {
            get => $"{Math.Round(CalculateFuel(100), 2)} л. на 100 км.";
        }

        /// <inheritdoc/>
        public override string Info
        {
            get => $"{base.Info}\nДополнительный двигатель:\n{ElectricMotorPower.Info}";
        }

        /// <inheritdoc/>
        public override string TypeTransport
        {
            get => "Гибридная машина";
        }

        /// <summary>
        /// Переопределенный метод Расчета расхода топлива.
        /// </summary>
        /// <param name="distance">Расстояние, пройденное на основном
        /// двигателе.</param>
        /// <returns>Расход топлива (л).</returns>
        public double CalculateFuel(double distance)
        {

            double coeffСonsumptionBase = Engine.СalculateConsumption();

            double coeffСonsumptionAdd = ElectricMotorPower.СalculateConsumption();

            double fuelConsumption = ((distance * coeffСonsumptionBase * (RatioMass * Mass))
            - (distance * coeffСonsumptionAdd * (RatioMass * Mass)));

            return fuelConsumption < 0 ? Math.Abs(fuelConsumption) * 0.05 : fuelConsumption;
        }
    }
}
