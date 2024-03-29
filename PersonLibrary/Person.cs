using System;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PersonLibrary
{
    /// <summary>
    /// Person. 
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Поле FirstName.
        /// </summary>
        private string _firstName;

        /// <summary>
        /// Поле LastName. 
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Поле Age. 
        /// </summary>
        private int _age;

        /// <summary>
        /// Минимальный возраст.
        /// </summary>
        public const int MinAge = 0;

        /// <summary>
        /// Максимальный возраст.
        /// </summary>
        public const int MaxAge = 100;

        /// <summary>
        /// Поле Gender. 
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Поле FirstName. 
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = IsSingleLanguage(value);
            }
        }

        /// <summary>
        /// Поле LastName. 
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (IsLanguageSame(_firstName, value) == true)
                {
                    _lastName =IsSingleLanguage(value);
                }
                else
                {
					throw new ArgumentException
						("Имя и фамилия должны быть написаны" +
						" на одном языке и не содержать символов");
				}
            }
        }

        /// <summary> 
        /// Поле Age.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (value >= MinAge && value <= MaxAge)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentException
						($"Возраст должен находиться в пределах " +
                        $"от {MinAge} года до {MaxAge} лет");
                }
            }
        }

        /// <summary>
        /// Поле Gender.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Конструктор класса Person.
        /// </summary>
        /// <param name="firstName">Имя человека.</param>
        /// <param name="lastName">Фамилия человека.</param>
        /// <param name="age">Возраст человека.</param>
        /// <param name="gender">Пол человека.</param>
        public Person(string firstName, string lastName, int age, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }

		/// <summary>
		/// Конструктор класса по умолчанию.
		/// </summary>
		public Person() : this("Вася", "Пупкин", 1, Gender.Male)
		{ }

		/// <summary>
		/// Возвращает информацию о человеке в виде строки. 
		/// </summary>
		/// <returns>Информация о человеке в виде строки.</returns>
		public string GetPersonInfo()
        {
            return $"Имя: {FirstName}, Фмилия: {LastName}," +
                   $" Возраст: {Age}, Пол:{Gender}\n";
        }

        //TODO: RSDN+
        /// <summary>
        /// Патерн русского языка.
        /// </summary>
        private const string _russianPattern = @"(^[а-яА-Я]+-?[а-яА-Я]+$)";

        //TODO: RSDN+
        /// <summary>
        /// Патерн английского языка.
        /// </summary>
        private const string _englishPattern = @"(^[a-zA-Z]+-?[a-zA-Z]+$)";

		/// <summary>
		/// Метод проверки правильности написания имени и фамилии и преобразования.
		/// </summary>
		/// <param name="word">Строка.</param>
		/// <returns>Преобразованная строка.</returns>
		/// <exception cref="Exception">Исключение.</exception>
		private string IsSingleLanguage(string word)
        {
			if (Regex.IsMatch(word, _russianPattern) ||
				Regex.IsMatch(word, _englishPattern))
			{
				TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
				return textInfo.ToTitleCase(word);
			}
			else
			{
				throw new ArgumentException("Имя и фамилия должны " +
					"содержать только русские или английские символы");
			}
		}

        /// <summary>
        /// Проверяет, соответствует ли язык имени и фамилии одному и тому же алфавиту.
        /// </summary>
        /// <param name="firstName">Имя для проверки.</param>
        /// <param name="lastName">Фамилия для проверки.</param>
        /// <returns>Значение true, если имя и фамилия соответствуют одному алфавиту; 
        /// в противном случае — значение false.</returns>
        public bool IsLanguageSame(string firstName, string lastName)
        {
            return (Regex.IsMatch(firstName, _russianPattern) && 
                    Regex.IsMatch(lastName, _russianPattern)) || 
                   (Regex.IsMatch(firstName, _englishPattern) &&
                    Regex.IsMatch(lastName, _englishPattern));
        }
    }
}