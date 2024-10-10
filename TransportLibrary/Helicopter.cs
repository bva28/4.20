namespace TransportLibrary
{
    /// <summary>
    /// Вертолет.
    /// </summary>
    public class Helicopter : TransportBase
    {
        /// <summary>
        /// Двигатель.
        /// </summary>
        private Engine _engine;

        /// <summary>
        /// Конструктор класса Вертолет.
        /// </summary>
        /// <param name="engine">Двигатель.</param>
        /// <param name="mass">Масса (т).</param>
        public Helicopter(Engine engine, double mass)
        {
            Engine = engine;
            Mass = mass;
        }

        /// <summary>
        /// Конструктор с параметрами по умолчанию.
        /// </summary>
        public Helicopter() : this(new Engine(1900, EngineType.GasTurbine), 6.5)
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
		private protected double RatioMass { get; } = 15.4;

        /// <inheritdoc/>
        public override string Info
        {
            get => $"{Engine.Info}\nМасса: {Mass} т.";
        }

        /// <inheritdoc/>
        public override string TypeTransport
        {
            get => "Вертолёт";
        }

        /// <inheritdoc/>
        public override string FuelConsumption
        {
            get => $"{Math.Round(CalculateFuel(1), 2)} л. на 100 км.";
        }

        /// <summary>
        /// Переопределенный метод Расчета расхода топлива.
        /// </summary>
        /// <param name="distance">Расстояние (часы).</param>
        /// <returns>Расход топлива (л).</returns>
        public override double CalculateFuel(double distance)
        {
            double coeffСonsumption = Engine.СalculateConsumption();

            return distance * coeffСonsumption * (RatioMass * Mass);
        }
    }
}
