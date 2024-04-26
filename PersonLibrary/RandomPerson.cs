using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
	//TODO: XML
	public class RandomPerson
	{
		/// <summary>
		/// Метод получения рандомного объекта класса Adult.
		/// </summary>
		/// <returns></returns>
		public static Adult GetRandomAdult()
		{
			Adult adult = new Adult();
			SetPersonGender(adult);
			SetPersonData(adult);
			SetAdultData(adult);
			SetAdultPartner(adult);
			return adult;
		}

		/// <summary>
		/// Перегруженный метод получения рандомного объекта класса Adult.
		/// </summary>
		/// <param name="gender">Пол.</param>
		/// <returns></returns>
		public static Adult GetRandomAdult(Gender gender)
		{
			Adult adult = new Adult();
			adult.Gender = gender;
			SetPersonData(adult);
			SetAdultData(adult);
			return adult;
		}

		/// <summary>
		/// Метод получения рандомного объекта класса Child.
		/// </summary>
		/// <returns></returns>
		public static Child GetRandomChild()
		{
			Child child = new Child();
			SetPersonGender(child);
			SetPersonData(child);
			SetChildData(child);
			return child;
		}

		/// <summary>
		/// Метод установки партнера объекту класса Adult.
		/// </summary>
		/// <param name="adult">Объект класса Adult.</param>
		public static void SetAdultPartner(Adult adult)
		{
			Adult partner = new Adult();
			Random random = new Random();
			int isMarried = random.Next(3);
			if (isMarried != 1)
			{
				switch (adult.Gender)
				{
					case Gender.Male:
						partner = GetRandomAdult(Gender.Female);
						partner.LastName = adult.LastName + 'а';
						break;
					case Gender.Female:
						partner = GetRandomAdult(Gender.Male);
						adult.LastName = partner.LastName + 'а';
						break;
				}

				adult.Partner = partner;
			}
		}

		/// <summary>
		/// Метод установки рандомного пола.
		/// </summary>
		/// <param name="person">Объект класса Person.</param>
		public static void SetPersonGender(PersonBase person)
		{
			Random random = new Random();
			person.Gender = (Gender)random.Next(Enum.GetValues
				(typeof(Gender)).Length);
		}

		/// <summary>
		/// Метод установки данных полей базового класса Person.
		/// </summary>
		/// <param name="person">Объект класса Person.</param>
		public static void SetPersonData(PersonBase person)
		{
			Random random = new Random();

			List<string> maleNames = new List<string>()
			{
				"Егор", "Сергей", "Юрий", "Александр", "Николай"
			};

			List<string> femaleNames = new List<string>()
			{
				"Дарья", "Софья", "Екатерина", "Мария", "Виктория"
			};

			List<string> lastNames = new List<string>()
			{
				"Андреев", "Гаврилов", "Ельцин", "Захаров", "Исаев"
			};

			person.LastName = lastNames[random.Next
				(0, lastNames.Count)];
			//TODO: RSDN
			switch (person.Gender)
			{
				case Gender.Male:
					person.FirstName = maleNames[random.Next
						(0, maleNames.Count)];
					break;
				case Gender.Female:
					person.FirstName = femaleNames[random.Next
						(0, femaleNames.Count)];
					person.LastName += "а";
					break;
			}

			person.Age = random.Next(person.MinAge, person.MaxAge);
		}

		/// <summary>
		/// Метод установки данных полей класса Adult.
		/// </summary>
		/// <param name="adult">Объект класса Adult.</param>
		public static void SetAdultData(Adult adult)
		{
			Random random = new Random();
			List<string> jobList = new List<string>()
			{
				"Лукойл", "РЖД", "Аэрофлот", "СБЕР", "НорНикель",
				"СверСталь", "Газпром", "ТатНефть", "ЕВРАЗ", "Роснефть"
			};

			int isEmployed = random.Next(3);
			if (isEmployed != 1)
			{
				adult.Job = jobList[random.Next(0, jobList.Count)];
			}

			adult.PassportSeries = random.Next(1000, 9999);
			adult.PassportNumber = random.Next(100000, 999999);
		}

		/// <summary>
		/// Метод установки данных полей класса Child.
		/// </summary>
		/// <param name="child">Объект класса Child.</param>
		public static void SetChildData(Child child)
		{
			Random random = new Random();
			List<string> schoolList = new List<string>()
			{
				"МБОУ СОШ №1", "МБОУ СОШ №2", "МБОУ СОШ №3", "МБОУ СОШ №4",
				"МБОУ СОШ №5", "МБОУ СОШ №6","МБОУ СОШ №7", "МБОУ СОШ №8"
			};

			int parentsStatus = random.Next(1, 3);
			//TODO: RSDN
			switch (parentsStatus)
			{
				case 3:
					child.Father = GetRandomAdult(Gender.Male);
					break;
				case 2:
					child.Father = GetRandomAdult(Gender.Male);
					SetAdultPartner(child.Father);
					child.Mother = child.Father.Partner;
					break;
				case 1:
					child.Mother = GetRandomAdult(Gender.Female);
					break;
			}

			child.School = schoolList[random.Next(0, schoolList.Count)];
		}
	}
}
