namespace TransportLibrary
{
    /// <summary>
    /// Класс Машина.
    /// </summary>
    public class Car : TransportBase
    {
        /// <summary>
        /// Двигатель.
        /// </summary>
        private Engine _engine;

        /// <summary>
        /// Конструктор класса Машина.
        /// </summary>
        /// <param name="engine">Двигатель.</param>
        /// <param name="mass">Масса (т).</param>
        public Car(Engine engine, double mass)
        {
            Engine = engine;
            Mass = mass;
        }

        /// <summary>
        /// Конструктор с параметрами по умолчанию.
        /// </summary>
        public Car() : this(new Engine(100, EngineType.Petrol), 1)
        { }

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
		private protected override double RatioMass { get; } = 1;

        /// <inheritdoc/>
        public override string Info
        {
            get => $"{Engine.Info} \nМасса: {Mass} т.";
        }

        /// <inheritdoc/>
        public override string TypeTransport
        {
            get => "Машина";
        }

        /// <inheritdoc/>
        public override string FuelConsumption
        {
            get => $"{Math.Round(CalculateFuel(100), 2)} л. на 100 км.";
        }

        /// <summary>
        /// Переопределенный метод расчета расхода топлива.
        /// </summary>
        /// <param name="distance">Расстояние (км).</param>
        /// <returns>Расход топлива (л).</returns>
        public override double CalculateFuel(double distance)
        {
            double coeffСonsumption = Engine.СalculateConsumption();

            return distance * coeffСonsumption * (RatioMass * Mass);
        }
    }
}
