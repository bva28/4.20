﻿using PersonLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace LB1
{
    /// <summary>
    /// Program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Создает экземпляр класса Person, с вводом данных через консоль.
        /// </summary>
        /// <returns>Экземпляр класса Person.</returns>
        public static Person CreatePersonFromConsole()
        {
            Person person = new Person("Ф", "Ф", 0, Gender.Male);

            List<Action> actions = new List<Action>()
            {
                () =>
                {
                    Console.WriteLine("FirstName:");
                    person.FirstName = Console.ReadLine();
                },
                () =>
                {
                    Console.WriteLine("LastName:");
                    person.LastName = Console.ReadLine();
                },
                () =>
                {
                    Console.Write("Введите возраст: ");
                    person.Age = Convert.ToInt32(Console.ReadLine());

                },
                () =>
                {
                    Console.WriteLine("Ввдите пол:\n 0 - Мужской;\n 1 - Женский");
                    int genderByte = Convert.ToInt32(Console.ReadLine());

                    switch (genderByte)
                    {
                        case 0:
                            person.Gender = Gender.Female;
                            break;
                        case 1:
                            person.Gender = Gender.Male;
                            break;
                        default:
                            throw new ArgumentException
                            ("Некорректный ввод пола.\n" +
                            "Ввдите пол:\n 0 - Мужской;\n 1 - Женский");
                    }
                }
            };

            foreach (Action action in actions)
            {
                ActionHandler(action);
            }

            return person;
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
        /// Генерирует случайное экземпляр типа Person
        /// </summary>
        /// <returns>Экземпляр класса Person.</returns>
        public static Person GetRandomPerson()
        {
            Console.WriteLine();
            Random random = new Random();

            string[] maleFirstNames = { "Егор", "Сергей", "Юрий", "Александр", "Николай" };
            string[] femaleFirstNames = { "Дарья", "Софья", "Екатерина", "Мария", "Виктория" };
            //TODO: RSDN
            string[] _lastName = { "Андреев", "Гаврилов", "Ельцин", "Захаров", "Исаев" };

            int rndGender = random.Next(0, Enum.GetNames(typeof(Gender)).Length);

            int rndMaleFirstNames = random.Next(0, maleFirstNames.Length);
            int rndFemaleFirstNames = random.Next(0, femaleFirstNames.Length);
            int rndLastName = random.Next(0, _lastName.Length);
            
            string firstName = "";
            string lastName = "";
            Gender gender = Gender.Female;
            switch (rndGender)
            {
                case 0:
                    firstName = maleFirstNames[rndMaleFirstNames];
                    lastName = _lastName[rndLastName];
                    gender = (Gender)rndGender;
                    break;

                case 1:
                    firstName = maleFirstNames[rndMaleFirstNames];
                    lastName = _lastName[rndLastName] + "а";
                    gender = (Gender)rndGender;
                    break;
            }

            //TODO: duplication
            int age = random.Next(0, 100);
            
            return new Person(firstName, lastName, age, gender);
        }

        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Person person1 = new Person("Андрей", "Пупкин", 20, Gender.Male);
            Person person2 = new Person("Егор", "Киселев", 25, Gender.Male);
            Person person3 = new Person("Кирилл", "Строгий", 30, Gender.Male);

            Person person4 = new Person("Даша", "Лазарева", 30, Gender.Female);
            Person person5 = new Person("Катя", "Пушкарян", 30, Gender.Female);
            Person person6 = new Person("Маша", "Золотых", 30, Gender.Female);
            Person person7 = new Person("Лиза", "Дятлова", 35, Gender.Female);

            PersonList personList1 = new PersonList();
            PersonList personList2 = new PersonList();

            personList1.AddElement(person1);
            personList1.AddElement(person2);
            personList1.AddElement(person3);

            personList2.AddElement(person4);
            personList2.AddElement(person5);
            personList2.AddElement(person6);

            Console.ReadKey();
            Console.WriteLine($"Список №1\n{personList1.GetPersonList()}");
            Console.ReadKey();
            Console.WriteLine($"Список №2\n{personList2.GetPersonList()}");

            Console.ReadKey();
            personList1.AddElement(person7);
            Console.WriteLine($"Список №1 после добавленя нового человека\n" +
                $"{personList1.GetPersonList()}");

            Console.ReadKey();
            personList2.AddElement(personList1.SearchElementByIndex(1));
            Console.WriteLine($"Список №1 после копирования\n{personList1.GetPersonList()}");
            Console.WriteLine($"Список №2 после копирования\n{personList2.GetPersonList()}");

            Console.ReadKey();
            personList1.DeleteElementByIndex(1);
            Console.WriteLine($"Список №1 после удаления\n{personList1.GetPersonList()}");
            Console.WriteLine($"Список №2 после удаления\n{personList2.GetPersonList()}");

            Console.ReadKey();
            personList2.DeleteAllElement();
            Console.WriteLine($"Список №2 после очистки\n{personList2.GetPersonList()}");

            Console.ReadKey();
            Person person8 = CreatePersonFromConsole();
            Console.WriteLine($"{person8.GetPersonInfo()}");


            Console.ReadKey();
            Person person9 = GetRandomPerson();
            Console.WriteLine($"{person9.GetPersonInfo()}");
        }
    }
}