using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
	/// <summary>
	/// Класс Child (наследник класса Person).
	/// </summary>
	public class Child : PersonBase
	{
		/// <summary>
		/// Поле отца.
		/// </summary>
		private Adult _father;

		/// <summary>
		/// Поле матери.
		/// </summary>
		private Adult _mother;

		/// <summary>
		/// Поле школы.
		/// </summary>
		private string _school;

		/// <summary>
		/// Максимальный возраст.
		/// </summary>
		public override int MaxAge { get; } = 17;

		/// <summary>
		/// Свойство для получения доступа к полю _father.
		/// </summary>
		public Adult Father
		{
			get { return _father; }
			set
			{
				if (value is null || value.Gender == Gender.Male)
				{
					_father = value;
				}
				else
				{
					throw new ArgumentException
						("Отец должен быть мужского пола");
				}
			}
		}

		/// <summary>
		/// Свойство для получения доступа к полю _mother.
		/// </summary>
		public Adult Mother
		{
			get { return _mother; }
			set
			{
				if (value is null || value.Gender == Gender.Female)
				{
					_mother = value;
				}
				else
				{
					throw new ArgumentException
						("Мать должна быть женского пола");
				}
			}
		}

		/// <summary>
		/// Свойство для получения доступа к полю _school.
		/// </summary>
		public string School
		{
			get { return _school; }
			set
			{
				_school = value;
				if (value == null || value == "")
				{
					_school = "Не ходит в школу";
				}
			}
		}

        /// <summary>
        /// Конструктор Child.
        /// </summary>
        public Child() : this("Неизвестно", "Неизвестно", 0, Gender.Male,
			null, null, "")
		{ }

		/// <summary>
		/// Конструктор класса Child.
		/// </summary>
		/// <param name="firstName">Имя.</param>
		/// <param name="lastName">Фамилия.</param>
		/// <param name="age">Возраст.</param>
		/// <param name="gender">Пол.</param>
		/// <param name="father">Отец.</param>
		/// <param name="mother">Мать.</param>
		/// <param name="school">Школа.</param>
		public Child(string firstName, string lastName, int age,
					 Gender gender, Adult father,
					 Adult mother, string school)
			: base(firstName, lastName, age, gender)
		{
			Father = father;
			Mother = mother;
			School = school;
		}

        /// <summary>
        /// Возвращает информацию о человеке в виде строки. 
        /// </summary>
        /// <returns>Информация о человеке в виде строки.</returns>
        public override string GetInfo()
		{
			string father = "нет отца";
			string mother = "нет матери";
			if (Father != null)
			{
				father = Father.FirstName + " " + Father.LastName;
			}
			if (Mother != null)
			{
				mother = Mother.FirstName + " " + Mother.LastName;
			}

			return base.GetInfo() + $", Отец: {father}, Мать: {mother}, Школа: {School}\n";
		}

        /// <summary>
        /// Жалобы на школу.
        /// </summary>
        /// <returns>Строка жалоб.</returns>
        public string ComplainAboutSchool()
		{
			return "Не любит ходить в школу";
		}
	}
}
