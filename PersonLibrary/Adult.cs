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
	public class Adult : Person
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

		//TODO: XML
		public override int MinAge { get; } = 18;

		/// <summary>
		/// Свойство для получения доступа к полю _passportSeries.
		/// </summary>
		public int PassportSeries
		{
			get { return _passportSeries; }
			set
			{
				if (VerifyPassport(value, 4))
				{
					_passportSeries = value;
				}
				else
				{
					//TODO: RSDN
					throw new ArgumentOutOfRangeException("Серия паспорта должна содержать 4 цифры");
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
				_passportNumber = value;
				if (VerifyPassport(value, 6))
				{
					_passportNumber = value;
				}
				else
				{
					//TODO: RSDN
					throw new ArgumentOutOfRangeException("Номер паспорта должна содержать 6 цифры");
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

		/// <summary>
		/// Проверка длины.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="length"></param>
		/// <returns>Результат проверки.</returns>
		public bool VerifyPassport(int data, int length)
		{
			//TODO: 
			return data.ToString().Length == length;
		}
	}
}
