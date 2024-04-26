using PersonLibrary;

namespace LR2
{
	/// <summary>
	/// Класс Program.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Метод вывода данных полей объекта класса Person в консоль.
		/// </summary>
		/// <param name="person">Объект класса Person.</param>
		public static void PrintPersonToConsole(PersonBase person)
		{
			Console.WriteLine(person.GetInfo());
		}

		/// <summary>
		/// Метод обработки возможных исключений.
		/// </summary>
		/// <param name="action">Действие.</param>
		public static void ActionHandler(Action action)
		{
			while (true)
			{
				try
				{
					action.Invoke();
					return;
				}

				catch (Exception ex)
				{
					var exceptionType = ex.GetType();
					if (exceptionType == typeof(FormatException) ||
						exceptionType == typeof(ArgumentOutOfRangeException) ||
						exceptionType == typeof(ArgumentException))
					{
						Console.WriteLine(ex.Message);
					}
				}
			}
		}

		/// <summary>
		/// Метод Main.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			Random random = new Random();
			PersonList personList = new PersonList();
			for (int i = 0; i < 7; i++)
			{
				int randomClass = random.Next(2);
				if (randomClass == 0)
				{
					personList.AddElement(RandomPerson.GetRandomAdult());
				}
				else
				{
					personList.AddElement(RandomPerson.GetRandomChild());
				}
			}

			Console.WriteLine(personList.GetPersonList());

			var person = personList.SearchElementByIndex(3);
			Type type = person.GetType();
			Console.WriteLine($"Тип четвертого человека в списке: {type}");

			switch (person)
			{
				//TODO: RSDN+
				case Adult adult:
					{
                        Console.WriteLine(adult.ComplainAboutWork());
                        break;
                    }
				case (Child child):
					{
                        Console.WriteLine(child.ComplainAboutSchool());
                        break;
                    }
			}
		}
	}
}