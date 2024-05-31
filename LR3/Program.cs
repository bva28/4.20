using TransportLibrary;
namespace LR3
{
	/// <summary>
	/// Класс Программа.
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Метод Main.
		/// </summary>
		static void Main(string[] args)
		{
			bool workProgram = true;

			while (workProgram)
			{
				Console.WriteLine("\n1 - Выполнить расчет расхода топлива" +
			   "\n2 - Выйти");

				char readProgram = Console.ReadKey().KeyChar;

				switch (readProgram)
				{
					case '1':
						{
							TransportBase transport = ConsoleTransport.SelectTransport();
							ConsoleTransport.СalculateСonsumptionFuel(transport);
							break;
						}

					case '2':
						{
							Console.WriteLine("\nПрограмма завершена");
							workProgram = false;
							break;
						}

					default:
						{
							Console.WriteLine("\nНекорректный ввод. Попробуйте еще раз");
							break;
						}
				}
			}
		}
	}
}