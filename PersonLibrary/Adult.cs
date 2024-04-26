using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
	/// <summary>
	/// Класс Adult.
	/// </summary>
	public class Adult : PersonBase
	{
		/// <summary>
		/// Поле серии паспорта.
		/// </summary>
		private int _passportSeries;

		/// <summary>
		/// Поле номера паспорта.
		/// </summary>
		private int _passportNumber;

		/// <summary>
		/// Поле партнера.
		/// </summary>
		private Adult _partner;

		/// <summary>
		/// Поле места работы.
		/// </summary>
		private string _job;

		/// <summary>
		/// Минимальный возраст.
		/// </summary>
		public override int MinAge { get; } = 18;

		/// <summary>
		/// Минимальное значение серии паспорта.
		/// </summary>
		public const int MinPassportSeries = 1000;

		/// <summary>
		/// Максимальное значение серии паспорта.
		/// </summary>
		public const int MaxPassportSeries = 9999;

		/// <summary>
		/// Минимальное значение номера паспорта.
		/// </summary>
		public const int MinPassportNumber = 100000;

		/// <summary>
		/// Максимальное значение номера паспорта.
		/// </summary>
		public const int MaxPassportNumber = 999999;

		/// <summary>
		/// Свойство для получения доступа к полю _passportSeries.
		/// </summary>
		public int PassportSeries
		{
			get { return _passportSeries; }
			set
			{
				if (value >= MinPassportSeries && value <= MaxPassportSeries)
				{
					_passportSeries = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException
						("Серия паспорта должна содержать 4 цифры");
				}
			}
		}

		/// <summary>
		/// Свойство для получения доступа к полю _passportNumber.
		/// </summary>
		public int PassportNumber
		{
			get { return _passportNumber; }
			set
			{
				if (value >= MinPassportNumber && value <= MaxPassportNumber)
				{
					_passportNumber = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException
						("Номер паспорта должна содержать 6 цифры");
				}
			}
		}

		/// <summary>
		/// Свойство для получения доступа к полю _partner.
		/// </summary>
		public Adult Partner
		{
			get { return _partner; }
			set
			{
				if (value?.Gender == Gender)
				{
					throw new ArgumentException
						("Невозможно создать однополый брак в соответвие с законодательством РФ");
				}

				_partner = value;
				if (value is not null)
				{
					value._partner = this;
				}
			}
		}

		/// <summary>
		/// Свойство для получения доступа к полю _job.
		/// </summary>
		public string Job
		{
			get { return _job; }
			set
			{
				_job = value;
				if (value == null || value == "")
				{
					_job = "безработный";
				}
			}
		}

        /// <summary>
        /// Конструктор класса Adult.
        /// </summary>
        public Adult() : this("Неизвестно", "Неизвестно", 18, Gender.Male,
			1000, 100000, null, "")
		{ }

		/// <summary>
		/// Конструктор класса Adult.
		/// </summary>
		/// <param name="firstName">Имя.</param>
		/// <param name="lastName">Фамилия.</param>
		/// <param name="age">Возраст.</param>
		/// <param name="gender">Пол.</param>
		/// <param name="passportSeries">Серия паспорта.</param>
		/// <param name="passportNumber">Номер паспорта.</param>
		/// <param name="partner">Партнер.</param>
		/// <param name="job">Место работы.</param>
		public Adult(string firstName, string lastName, int age,
					 Gender gender, int passportSeries, int passportNumber,
					 Adult partner, string job)
			: base(firstName, lastName, age, gender)
		{
			PassportSeries = passportSeries;
			PassportNumber = passportNumber;
			Partner = partner;
			Job = job;
		}

        /// <summary>
        /// Возвращает информацию о человеке в виде строки. 
        /// </summary>
        /// <returns>Информация о человеке в виде строки.</returns>
        public override string GetInfo()
		{
			string partner = "";
			if (Partner == null)
			{
				partner = "не в браке";
			}
			else
			{
				partner = Partner.FirstName + " " + Partner.LastName;
			}

			return base.GetInfo() +
				   $", Паспорт: {PassportSeries} {PassportNumber}," +
				   $" Партнер: {partner}, Место работы: {Job}\n";
		}

		/// <summary>
		/// Жалобы на работы.
		/// </summary>
		/// <returns>Строка жалоб.</returns>
		public string ComplainAboutWork()
		{
			return "Не любит вставать по утрам на работу";
		}
	}
}
