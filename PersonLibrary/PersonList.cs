using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// PersonList.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Список объектов типа Person.
        /// </summary>
        private List<Person> _list = new List<Person>();

        /// <summary>
        /// Добавляет элемент типа Person в список.
        /// </summary>
        /// <param name="element">Элемент типа Person для добавления в список.</param>
        public void AddElement(Person element)
        {
            _list.Add(element);
        }

        /// <summary>
        /// Удаляет элемент типа Person из списка.
        /// </summary>
        /// <param name="element">Элемент типа Person для удаления из списка.</param>
        public void DeleteElement(Person element)
        {
            _list.Remove(element);
        }

        /// <summary>
        /// Удаление элемент типа Person из списка по индексу.
        /// </summary>
        /// <param name="index">Индекс элемента типа Person для удаления из списка.</param>
        public void DeleteElementByIndex(int index)
        {
            _list.RemoveAt(index);
        }

        /// <summary>
        /// Поиск элемента типа Person из списка по индексу. 
        /// </summary>
        /// <param name="index">Индекс элемента типа Person для поиска.</param>
        /// <returns></returns>
        public Person SearchElementByIndex(int index)
        {
            return _list[index];
        }

        /// <summary>
        /// Ищет индекс указанного элемента типа Person в списке List и выводит его на консоль.
        /// Если элемент не найден, выводит сообщение об этом.
        /// </summary>
        /// <param name="element">Элемент типа Person для поиска в списке.</param>
        public void SearchIndex(Person element)
        {
            int index = _list.IndexOf(element);

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
            _list.Clear();
        }

        /// <summary>
        /// Количество элементов типа Person в списке.
        /// </summary>
        /// <returns>Количество элементов типа Person в списке.</returns>
        public int CountElement()
        {
            return _list.Count;
        }

        /// <summary>
        /// Возвращает стрку списка персон, содержащее информацию о каждом элементе.
        /// </summary>
        /// <returns>Строка содержащая списка персон.</returns>
        public string GetPersonList()
        {
            string result = "";

            foreach (Person person in _list)
            {
                result += person.GetPersonInfo();
            }
            return result;
        }
    }
}

