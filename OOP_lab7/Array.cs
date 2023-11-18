using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OOP_lab7.Interfaces;
using System.Xml.Serialization;
using Newtonsoft.Json; // тут нужно установить пакет Newtonsoft.Json

namespace OOP_lab7
{ // Возьмите за основу лаб3 и сделайте из нее обобщенный тип
  // Наследуйте в обобщенном классе интерфейс
    public partial class MyArray<T> : IArray<T> where T : new() // ограничение на обобщение(должен иметь открытый констуктор без параметров)
    {
        public T[] array;
        public readonly Date date;
        public readonly Owner owner;
        public List<List<T>> nestedCollection; //в который вложите обобщённую коллекцию

        // подклассы

        public class Owner
        {
            public int ID { get; }
            public string Author { get; }
            public string Organization { get; }

            public Owner(int id, string author, string organization)
            {
                this.ID = id;
                this.Author = author;
                this.Organization = organization;
            }
        }
        public class Date
        {
            public DateTime Time { get; }

            public Date()
            {
                Time = DateTime.Now;
            }
        }

        // конструкторы

        public MyArray()
        {
            this.array = new T[] { };
            this.date = new Date();
            this.owner = new Owner(0, "", "");
            this.nestedCollection = new List<List<T>>();
        }

        public MyArray(T[] arr, int id = 0, string author = "", string organisation = "")
        {
            array = arr;
            this.date = new Date();
            this.owner = new Owner(id, author, organisation);
            this.nestedCollection = new List<List<T>>();
        }


        ////////////////////////////// МЕТОДЫ IARRAY<T> ////////////////////////////////////


        public void Show()
        {
            string result = "{\t";
            foreach (T item in this.array)
                result += $"{item}\t";
            result += "}";
            Console.WriteLine(result);
        }

        public void Add(T elem)
        {
            this.array = this.array.Append(elem).ToArray(); // добавление и преобразование коолекции в массив
        }

        public void Remove(int index)
        {
            try
            {
                if (index >= this.array.Length || index < 0)
                    throw new Exception($"Index out of range (0, {this.array.Length - 1})");
                this.array = this.array.Where((el, i) => i != index).ToArray(); // какие элементы сохранить 
            }
            catch (Exception e)
            {
                Console.WriteLine($"RangeOutException: {e.Message}!");
            }
            finally
            {
                Console.WriteLine("Обработка исключения завершена");
            }
        }

        public void FindByPredicate(Predicate<T> predicate)
        {
            try
            {
                List<T> foundItems = new List<T>();
                foreach (T item in this.array)
                {
                    if (predicate(item))
                    {
                        foundItems.Add(item);
                    }
                }

                if (foundItems.Count > 0)
                {
                    Console.WriteLine("Найденные элементы:");
                    Console.Write("{\t");
                    foreach (T item in foundItems)
                    {
                        Console.Write(item + "\t");
                    }
                    Console.Write("}");
                }
                else
                {
                    Console.WriteLine("Элементы, удовлетворяющие предикату, не найдены.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при выполнении поиска по предикату: {ex.Message}");
            }
        }

        public void AddToNestedCollection(List<T> nestedElem)
        {
            nestedCollection.Add(nestedElem);
        }

        public void RemoveFromNestedCollection(int nestedIndex)
        {
            try
            {
                if (nestedIndex >= nestedCollection.Count || nestedIndex < 0)
                    throw new Exception($"Nested index out of range (0, {nestedCollection.Count - 1})");
                nestedCollection.RemoveAt(nestedIndex);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Nested range exception: {e.Message}!");
            }
            finally
            {
                Console.WriteLine("Обработка исключения завершена");
            }
        }

        // Сохранение коллекции в текстовый файл
        public void SaveToTextFile(string filePath)
        {
            try
            {
                string[] lines = new string[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    lines[i] = array[i].ToString();
                }

                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Коллекция успешно сохранена в текстовый файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении в текстовый файл: {ex.Message}");
            }
        }

        // Загрузка коллекции из текстового файла
        public void LoadFromTextFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    array = new T[lines.Length];
                    for (int i = 0; i < lines.Length; i++)
                    {
                        array[i] = (T)Convert.ChangeType(lines[i], typeof(T));
                    }
                    Console.WriteLine("Коллекция успешно загружена из текстового файла.");
                }
                else
                {
                    Console.WriteLine("Файл не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке из текстового файла: {ex.Message}");
            }
        }

        public void SaveToXmlFile(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T[]));
                using (TextWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, array);
                }
                Console.WriteLine("Коллекция успешно сохранена в XML-файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении в XML-файл: {ex.Message}");
            }
        }

        public void LoadFromXmlFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T[]));
                    using (TextReader reader = new StreamReader(filePath))
                    {
                        array = (T[])serializer.Deserialize(reader);
                    }
                    Console.WriteLine("Коллекция успешно загружена из XML-файла.");
                }
                else
                {
                    Console.WriteLine("Файл не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке из XML-файла: {ex.Message}");
            }
        }
        public void SaveToJsonFile(string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(array);
                File.WriteAllText(filePath, json);
                Console.WriteLine("Коллекция успешно сохранена в JSON-файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении в JSON-файл: {ex.Message}");
            }
        }

        public void LoadFromJsonFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    array = JsonConvert.DeserializeObject<T[]>(json);
                    Console.WriteLine("Коллекция успешно загружена из JSON-файла.");
                }
                else
                {
                    Console.WriteLine("Файл не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке из JSON-файла: {ex.Message}");
            }
        }
    }
}