using LB1_library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB1_library
{
    /// <summary>
    /// PersonList.
    /// </summary>
    public class PersonList
    {
        public List<Person> List = new List<Person>();

        /// <summary>
        /// Добавляет элемент типа Person в список.
        /// </summary>
        /// <param name="element">Элемент типа Person для добавления в список.</param>
        public void AddElement(Person element)
        {
            List.Add(element);
        }

        /// <summary>
        /// Удаляет элемент типа Person из списка.
        /// </summary>
        /// <param name="element">Элемент типа Person для удаления из списка.</param>
        public void DeleteElement(Person element)
        {
            List.Remove(element);
        }

        /// <summary>
        /// Удаление элемент типа Person из списка по индексу.
        /// </summary>
        /// <param name="index">Индекс элемента типа Person для удаления из списка.</param>
        public void DeleteElementByIndex(int index)
        {
            List.RemoveAt(index);
        }

        /// <summary>
        /// Поиск элемента типа Person из списка по индексу. 
        /// </summary>
        /// <param name="index">Индекс элемента типа Person для поиска.</param>
        /// <returns></returns>
        public Person SearchElementByIndex(int index)
        {
            return List[index];
        }

        /// <summary>
        /// Ищет индекс указанного элемента типа Person в списке List и выводит его на консоль.
        /// Если элемент не найден, выводит сообщение об этом.
        /// </summary>
        /// <param name="element">Элемент типа Person для поиска в списке.</param>
        public void SearchIndex(Person element)
        {
            int index = List.IndexOf(element);

            if (index != -1)
            {
                Console.WriteLine($"Индекс {element}: {index}");
            }
            else
            {
                Console.WriteLine($"Число {element} не найдено в списке.");
            }
        }

        /// <summary>
        /// Удаление всех элемент типа Person из списка. 
        /// </summary>
        public void DeleteAllElement()
        {
            //List.RemoveAt(List.Count - 1);
            List.Clear();
        }

        /// <summary>
        /// Количество элементов типа Person в списке.
        /// </summary>
        /// <returns>Количество элементов типа Person в списке.</returns>
        public int CountElement()
        {
            return List.Count;
        }

        /// <summary>
        /// Возвращает стрку списка персон, содержащее информацию о каждом элементе.
        /// </summary>
        /// <returns>Строка содержащая списка персон.</returns>
        public string GetPersonList()
        {
            string result = "";

            foreach (Person person in List)
            {
                result += person.GetPersonInfo();
            }
            return result;
        }
    }
}
