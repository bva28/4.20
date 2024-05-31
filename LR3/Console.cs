using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLibrary;

namespace LR3
{
	/// <summary>
	/// Класс для консольного ввода транспорта.
	/// </summary>
	public static class ConsoleTransport
	{
		/// <summary>
		/// Метод Выбора Транспорта для расчета расхода топлива.
		/// </summary>
		/// <returns>Транспорт.</returns>
		public static TransportBase SelectTransport()
		{
			TransportBase transport = new Car();

			Dictionary<Type, Action<string>> catchDictionary =
				new Dictionary<Type, Action<string>>()
			{
				{
					typeof(ArgumentOutOfRangeException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
			};

			List<Action> actions = new()
			{
				()=>
				{
					 Console.WriteLine("\nВыберите тип транспорта:" +
						"\n\t1 - машина" +
						"\n\t2 - машина-гибрид" +
						"\n\t3 - вертолет");

					char readTransport = Console.ReadKey().KeyChar;

					switch (readTransport)
					{
						case '1':
						{
							transport = ReadCar();
							break;
						}

						case '2':
						{
							transport = ReadHybridCar();
							break;
						}

						case '3':
						{
							transport = ReadHelicopter();
							break;
						}

						default:
						{
							throw new ArgumentOutOfRangeException(
								"Неверно введен тип транспорта");
						}
					}
				},
			};

			ActionsHandler(actions, catchDictionary);

			return transport;
		}

		/// <summary>
		/// Метод Ввода данных о Машине.
		/// </summary>
		/// <returns>Машина.</returns>
		public static Car ReadCar()
		{
			Dictionary<Type, Action<string>> catchDictionary =
			new Dictionary<Type, Action<string>>()
			{
				{
					typeof(ArgumentException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
				{
					typeof(FormatException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
				{
					typeof(OverflowException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
			};

			Car car = new Car();

			List<Action> actions = new()
			{
				()=>
				{
					 Console.WriteLine($"\nВведите данные о двигателе");
					 car.Engine = ReadEngine(car);
				},

				()=>
				{
					Console.Write($"\nВведите массу машины в кг" +
						$" (нажмите Enter): ");
					car.Mass = Convert.ToInt32(Console.ReadLine());
				},
			};

			ActionsHandler(actions, catchDictionary);

			return car;
		}

		/// <summary>
		/// Метод Ввода данных о Вертолете.
		/// </summary>
		/// <returns>Вертолет.</returns>
		public static Helicopter ReadHelicopter()
		{
			Dictionary<Type, Action<string>> catchDictionary =
			new Dictionary<Type, Action<string>>()
			{
				{
					typeof(ArgumentException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
				{
					typeof(FormatException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
				{
					typeof(OverflowException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
			};

			Helicopter helicopter = new Helicopter();

			List<Action> actions = new()
			{
				()=>
				{
					 Console.WriteLine($"\nВведите данные о двигателе");
					 helicopter.Engine = ReadEngine(helicopter);
				},

				()=>
				{
					Console.Write($"\nВведите массу вертолета в тоннах" +
						$" (нажмите Enter): ");
					helicopter.Mass = Convert.ToInt32(Console.ReadLine());
				},

			};

			ActionsHandler(actions, catchDictionary);

			return helicopter;
		}

		/// <summary>
		/// Метод Ввода данных о Гибридной машине.
		/// </summary>
		/// <returns>Гибридная машина.</returns>
		public static HybridCar ReadHybridCar()
		{
			Dictionary<Type, Action<string>> catchDictionary =
			new Dictionary<Type, Action<string>>()
			{
				{
					typeof(ArgumentException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
				{
					typeof(FormatException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
				{
					typeof(OverflowException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
			};

			HybridCar hybridCar = new HybridCar();

			List<Action> actions = new()
			{
				()=>
				{
					 Console.WriteLine($"\nВведите данные об основном" +
						 $" двигателе");
					 hybridCar.Engine = ReadEngine(hybridCar);
				},

				()=>
				{
					Console.WriteLine($"\nВведите данные о дополнительном" +
						$" двигателе");
					hybridCar.ElectricMotorPower = ReadEngine(hybridCar.Engine);
				},

				()=>
				{
					Console.Write($"\nВведите массу машины в кг" +
						$" (нажмите Enter): ");
					hybridCar.Mass = Convert.ToInt32(Console.ReadLine());
				},
			};

			ActionsHandler(actions, catchDictionary);

			return hybridCar;
		}

		/// <summary>
		/// Метод Ввода данных о Двигателе.
		/// </summary>
		/// <param name="transport">Объект транспорт.</param>
		/// <returns>Двигатель.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Выход
		/// за пределы.</exception>
		public static Engine ReadEngine(TransportBase transport)
		{
			Dictionary<Type, Action<string>> catchDictionary =
			new Dictionary<Type, Action<string>>()
			{
				{
					typeof(ArgumentOutOfRangeException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
				{
					typeof(ArgumentException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
				{
					typeof(FormatException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
				{
					typeof(OverflowException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
			};

			Engine engine = new Engine();

			List<Action> actions = new()
			{
				()=>
				{
					Dictionary<char, EngineType> сonsumptionFuel;
					char keyInfo;
					Console.WriteLine($"\n\tВыберите вид топлива: ");
					if ( transport is HybridCar )
					{
						Console.WriteLine($"\t1 - бензин");

						keyInfo = Console.ReadKey().KeyChar;

						сonsumptionFuel = new()
						{
							{'1', EngineType.Petrol},

						};
					}
					else 
					{
						Console.WriteLine($"\t1 - бензин" +
										 "\n\t2 - дизель" +
										 "\n\t3 - керосин");

						keyInfo = Console.ReadKey().KeyChar;
						сonsumptionFuel = new()
						{
							{'1', EngineType.Petrol},
							{'2', EngineType.Diesel},
							{'3', EngineType.GasTurbine},
						};
					}

					if(!сonsumptionFuel.ContainsKey(keyInfo))
					{
						throw new ArgumentOutOfRangeException();
					}

					engine.EngineType = сonsumptionFuel[keyInfo];

				},
				
				()=>
				{
					Console.Write($"\n\tВведите мощность двигателя в л.с " +
						$"(нажмите Enter): ");

					engine.Power = Convert.ToInt32(Console.ReadLine());
				},
			};

			ActionsHandler(actions, catchDictionary);

			return engine;
		}

		/// <summary>
		/// Метод Ввода данных о Гибридном Двигателе.
		/// </summary>
		/// <param name="engine">Основной двигатель.</param>
		/// <returns>Гибридный двигатель.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Выход
		/// за пределы.</exception>
		public static Engine ReadEngine(Engine engine)
		{
			Dictionary<Type, Action<string>> catchDictionary =
			new Dictionary<Type, Action<string>>()
			{
				{
					typeof(ArgumentOutOfRangeException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
				{
					typeof(ArgumentException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
				{
					typeof(FormatException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
				{
					typeof(OverflowException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
			};

			Engine additionalMotor = new Engine();

			List<Action> actions = new()
			{
				()=>
				{
					engine.EngineType = EngineType.Electricity;
				},

				()=>
				{
					Console.Write($"\n\tВведите мощность двигателя в кВт " +
						$"(нажмите Enter): ");

					engine.Power = Convert.ToInt32(Console.ReadLine());
				},
			};

			ActionsHandler(actions, catchDictionary);

			return additionalMotor;
		}

		/// <summary>
		/// Метод Расчета расхода топлива.
		/// </summary>
		/// <param name="transport">Объект транспорт.</param>
		public static void СalculateСonsumptionFuel(TransportBase transport)
		{
			Dictionary<Type, Action<string>> catchDictionary =
			new Dictionary<Type, Action<string>>()
			{
				{
					typeof(ArgumentOutOfRangeException),
					(string message) =>
					{
						Console.WriteLine($"\nИсключение: {message}");
					}
				},
			};

			Action action =
				() =>
				{
					if (transport is HybridCar newHybridCar)
					{
						Console.Write($"\nВведите расстояние в км " +
							$"(нажмите Enter): ");

						double distance = Convert.ToDouble(Console.ReadLine());

						ReadPositiveDouble(distance);

						var consumption = Math.Round((newHybridCar.CalculateFuel(distance)), 1);

						Console.Write($"\nРасход топлива для прохождения расстояния" +
							$" {distance} км составит {consumption} л.");
					}
					else if (transport is Car newCar)
					{
						Console.Write("\nВведите расстояние в км (нажмите Enter): ");

						double distance = Convert.ToDouble(Console.ReadLine());

						ReadPositiveDouble(distance);

						Console.Write($"\nРасход топлива для прохождения расстояния" +
						   $" {distance} км составит" +
						   $" {Math.Round(newCar.CalculateFuel(distance), 1)} л.\n");
					}

					else if (transport is Helicopter newHelicopter)
					{
						Console.Write("\nВведите расстояние в км (нажмите Enter):" +
							" (нажмите Enter): ");

						double distance = Convert.ToDouble(Console.ReadLine());

						ReadPositiveDouble(distance);

						Console.Write($"\nРасход топлива для {distance} км полета" +
							$" составит {Math.Round(newHelicopter.CalculateFuel(distance), 1)} л.\n");
					}
				};

			ActionHandler(action, catchDictionary);
		}

		/// <summary>
		/// Метод проверки на ввод положительного числа.
		/// </summary>
		/// <param name="value">.</param>
		private static void ReadPositiveDouble(double value)
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException("Число должно быть" +
					" положительным");
			}
		}

		/// <summary>
		/// Метод Обработки действий.
		/// </summary>
		/// <param name="assignActions">Действие требующее проверки.</param>
		/// <param name="catchDictionary">Словарь исключений.</param>
		private static void ActionsHandler(List<Action> assignActions,
			Dictionary<Type, Action<string>> catchDictionary)
		{
			foreach (var assignAction in assignActions)
			{
				ActionHandler(assignAction, catchDictionary);
			}
		}

		/// <summary>
		/// Метод Обработки действия.
		/// </summary>
		/// <param name="assignAction">Действие требующее проверки.</param>
		/// <param name="catchDictionary">Словарь исключений.</param>
		private static void ActionHandler(Action assignAction,
			Dictionary<Type, Action<string>> catchDictionary)
		{
			while (true)
			{
				try
				{
					assignAction.Invoke();
					break;
				}
				catch (Exception ex)
				{
					catchDictionary[ex.GetType()].Invoke(ex.Message);
				}
			}
		}
	}
}
