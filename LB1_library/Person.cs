﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace LB1_library
{
    /// <summary>
    /// Gender. 
    /// </summary>
    public enum Gender
    {
        Male,
        Female
    }

    /// <summary>
    /// Person. 
    /// </summary>
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private Gender gender;

        /// <summary>
        /// Поле FirstName. 
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set
            {
                ConvertRegister(value);
                if (IsSingleLanguage(value))
                {
                    throw new ArgumentException("Имя должно быть написано одним языком.");
                }

                firstName = ConvertRegister(value);
            }
        }

        /// <summary>
        /// Поле LastName. 
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (IsSingleLanguage(value))
                {
                    throw new ArgumentException("Фамилия должна быть написана одним языком.");
                }
                if (!IsNameLanguageMatched(FirstName, value))
                {
                    throw new ArgumentException("Язык фамилии должен совпадать с языком имени.");
                }

                lastName = ConvertRegister(value);
            }
        }

        /// <summary> 
        /// Поле Age.
        /// </summary>
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Возраст не может быть отрицательным");
                }

                if (value > 100)
                {
                    throw new ArgumentException("Бессмертен");
                }

                age = value;
            }
        }

        /// <summary>
        /// Поле Gender.
        /// </summary>
        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

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
        /// Возвращает информацию о человеке в виде строки. 
        /// </summary>
        /// <returns>Информация о человеке в виде строки.</returns>
        public string GetPersonInfo()
        {
            return $"Имя: {FirstName}, Фмилия: {LastName}," +
                   $"Возраст: {Age}, Пол:{Gender}\n";

        }

        /// <summary>
        /// Вывод информации о человеке в консоль, для проверки.
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"Name: {FirstName}");
            Console.WriteLine($"LastName: {LastName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Gender: {Gender}");
        }

        /// <summary>
        /// Проверяет, содержит ли слово только один язык (русский или английский).
        /// </summary>
        /// <param name="word">Слово для проверки.</param>
        /// <returns>Значение true, если слово содержит только один язык; 
        /// в противном случае — значение false.</returns>
        private bool IsSingleLanguage(string word)
        {
            bool hasRussian = Regex.IsMatch(word, @"[^а-яА-Я -]");
            bool hasEnglish = Regex.IsMatch(word, @"[^a-zA-Z -]");

            return (hasRussian && hasEnglish);
        }

        /// <summary>
        /// Проверяет, соответствует ли язык имени и фамилии одному и тому же алфавиту.
        /// </summary>
        /// <param name="firstName">Имя для проверки.</param>
        /// <param name="lastName">Фамилия для проверки.</param>
        /// <returns>Значение true, если имя и фамилия соответствуют одному алфавиту; 
        /// в противном случае — значение false.</returns>
        private bool IsNameLanguageMatched(string firstName, string lastName)
        {
            bool hasRussianFirstName = Regex.IsMatch(firstName, @"[^а-яА-Я -]");
            bool hasRussianLastName = Regex.IsMatch(lastName, @"[^а-яА-Я -]");

            bool hasEnglishFirstName = Regex.IsMatch(firstName, @"[^a-zA-Z -]");
            bool hasEnglishLastName = Regex.IsMatch(lastName, @"[^a-zA-Z -]");

            return (hasRussianFirstName && hasRussianLastName) ||
                (hasEnglishFirstName && hasEnglishLastName);
        }

        /// <summary>
        /// Преобразует регистр строки, 
        /// делая первую букву заглавной, а остальные - строчными.
        /// </summary>
        /// <param name="input">Входная строка для преобразования.</param>
        /// <returns>Преобразованная строка.</returns>
        public static string ConvertRegister(string input)
        {
            if (input.Contains('-') || input.Contains(' '))
            {
                string[] nameParts = input.Split('-', ' ');

                string result = "";

                foreach (string part in nameParts)
                {
                    if (!string.IsNullOrEmpty(part))
                    {
                        string lowerCase = part.ToLower();
                        result += char.ToUpper(lowerCase[0]) + lowerCase.Substring(1) + " ";
                    }
                }

                return result.TrimEnd();
            }
            else
            {
                string lowerCase = input.ToLower();
                return char.ToUpper(lowerCase[0]) + lowerCase.Substring(1);
            }
        }
    }
}