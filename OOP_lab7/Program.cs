using System;
using System.Collections.Generic;

namespace OOP_lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArray<int> arrayInt = new MyArray<int>(new[] { 1, 2, 3, 4, 5, 6, 7 }, author: "ssjjitt", organisation: "BSTU");
            MyArray<double> arrayDouble = new MyArray<double>(new[] { 1.1, 2.2, 3.3, 4.4, 5, 6.6  });


            Console.WriteLine("\n-----------------------------------------------------------------------------------\n");
            Console.WriteLine("Целочисленная коллекция: ");
            arrayInt.Show();
            Console.WriteLine("Коллекция с плавающей точкой: ");
            arrayDouble.Show();
            Console.WriteLine("\n-----------------------------------------------------------------------------------\n");

            int number = ReadIntegerFromConsole();
            arrayInt.Add(number);
            double dnumber = ReadDoubleFromConsole();
            arrayDouble.Add(dnumber);


            Console.WriteLine("\n-----------------------------------------------------------------------------------\n");
            Console.WriteLine("Целочисленная коллекция: ");
            arrayInt.Show();
            Console.WriteLine("Коллекция с плавающей точкой: ");
            arrayDouble.Show();
            Console.WriteLine("\n-----------------------------------------------------------------------------------\n");


            number = ReadIntegerFromConsole();
            arrayInt.Remove(number);
            arrayDouble.Remove(number);


            Console.WriteLine("\n-----------------------------------------------------------------------------------\n");
            Console.WriteLine("\nЦелочисленная коллекция: ");
            arrayInt.Show();
            Console.WriteLine("Коллекция с плавающей точкой: ");
            arrayDouble.Show();
            Console.WriteLine("\n-----------------------------------------------------------------------------------\n");


            Console.WriteLine("Поиск по предикату: ");
            arrayInt.FindByPredicate(x => x > 2); // лямбда-выражение
            Console.WriteLine("\n-----------------------------------------------------------------------------------\n");


            List<int> nestedCollection = new List<int> { 6, 7, 8 };
            arrayInt.AddToNestedCollection(nestedCollection);
            Console.WriteLine("Вложенная коллекция:");
            Console.Write("{\t");
            foreach (List<int> nestedElem in arrayInt.nestedCollection)
            {
                foreach (int elem in nestedElem)
                {
                    Console.Write(elem + "\t");
                }
            }
            Console.Write("}\n");
            Console.WriteLine("\n-----------------------------------------------------------------------------------\n");


            MyArray<GeometricFigure> arrayClass = new MyArray<GeometricFigure>(
                new GeometricFigure[] { new GeometricFigure(12, 32), new GeometricFigure(4, 14) });
            arrayClass.Add(new GeometricFigure(6, 2));


            Console.WriteLine("Работа с txt-файлом");
            arrayInt.SaveToTextFile(@"E:\уник\c\OOP_lab7\collectionForSave.txt");
            MyArray<int> collection = new MyArray<int>();
            collection.LoadFromTextFile(@"E:\уник\c\OOP_lab7\collectionForRead.txt");
            collection.Show();
            Console.WriteLine("\n-----------------------------------------------------------------------------------\n");

            Console.WriteLine("Работа с xml-файлом");
            arrayInt.SaveToXmlFile(@"E:\уник\c\OOP_lab7\collectionForSave.xml");
            MyArray<int> collection2 = new MyArray<int>();
            collection2.LoadFromXmlFile(@"E:\уник\c\OOP_lab7\collectionForRead.xml");
            collection2.Show();
            Console.WriteLine("\n-----------------------------------------------------------------------------------\n");

            Console.WriteLine("Работа с json-файлом");
            arrayInt.SaveToJsonFile(@"E:\уник\c\OOP_lab7\collectionForSave.json");
            MyArray<int> collection3 = new MyArray<int>();
            collection3.LoadFromJsonFile(@"E:\уник\c\OOP_lab7\collectionForRead.json");
            collection3.Show();
            Console.WriteLine("\n-----------------------------------------------------------------------------------\n");

        }
        static int ReadIntegerFromConsole()
        {
            int number = 0;
            try
            {
                bool isValidInput = false;
                do
                {
                    Console.WriteLine("Введите целое число:");
                    string input = Console.ReadLine();
                    isValidInput = int.TryParse(input, out number);
                    if (!isValidInput)
                    {
                        Console.WriteLine("Неправильный формат числа. Попробуйте снова.");
                    }

                } while (!isValidInput);
            }
            catch (FormatException)
            {
                throw new InvalidNumberInputException("Неправильный формат числа. Введите целое число.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            return number;
        }

        static double ReadDoubleFromConsole()
        {
            double dnumber = 0;
            try
            {
                bool isValidInput = false;
                do
                {
                    Console.WriteLine("Введите число с плавающей точкой:");
                    string input = Console.ReadLine();
                    isValidInput = double.TryParse(input, out dnumber);
                    if (!isValidInput)
                    {
                        Console.WriteLine("Неправильный формат числа. Попробуйте снова.");
                    }

                } while (!isValidInput);
            }
            catch (FormatException)
            {
                throw new InvalidNumberInputException("Неправильный формат числа. Введите число с плавающей точкой.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            return dnumber;
        }
    }
}