namespace TransportLibrary
{
    /// <summary>
    /// Класс Двигатель.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Мощность двигателя.
        /// </summary>
        private double _power;

        /// <summary>
        /// Словарь тип топлива.
        /// </summary>
        private static readonly Dictionary<EngineType, string> _typesFuel = new()
        {
            {EngineType.Petrol, "Бензин"},
            {EngineType.Diesel, "Дизель"},
            {EngineType.Electricity, "Электричество"},
            {EngineType.GasTurbine, "Газтурбинный"}
        };

        /// <summary>
        /// Конструктор класса Двигатель.
        /// </summary>
        /// <param name="power">Мощность двигателя.</param>
        /// <param name="engineType">Вид топлива.</param>
        public Engine(double power, EngineType engineType)
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
        /// Свойство Мощность двигателя.
        /// </summary>
        public double Power
        {
            get => _power;
            set
            {
                if (double.IsNaN(value))
                {
                    throw new ArgumentException
                        ("Мощность должна быть задана");
                }

                if (value <= 0)
                {
                    throw new ArgumentException
                        ("Мощность должна быть положительной");
                }

                _power = value;
            }
        }

        /// <summary>
        /// Свойство Вид топлива.
        /// </summary>
        public EngineType EngineType
        {
            get; set;
        }

        /// <summary>
        /// Информация о двигателе.
        /// </summary>
        public string Info
        {
            get => $"Тип топлива: {_typesFuel[EngineType]}\nМощность: {Power} л.с.";
        }

        /// <summary>
        /// Расчет коэффициента расхода.
        /// </summary>
        /// <returns>Коэффициент расхода.</returns>
        public double СalculateConsumption()
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
