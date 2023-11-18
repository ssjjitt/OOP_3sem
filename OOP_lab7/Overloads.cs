using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab7
{
    public partial class MyArray<T>
    {
        public static MyArray<T> operator +(MyArray<T> arr1, MyArray<T> arr2)
        {
            return new MyArray<T>(arr1.array.Concat(arr2.array).ToArray());
        }

        public static MyArray<T> operator -(MyArray<T> arr1, MyArray<T> arr2)
        {
            decimal[] result = new decimal[Math.Max(arr1.array.Length, arr2.array.Length)];

            if (arr1.array.Length < arr2.array.Length)
            {
                for (int i = 0; i < arr1.array.Length; i++)
                    result[i] = Math.Abs(Convert.ToDecimal(arr1.array[i]) - Convert.ToDecimal(arr2.array[i]));
                for (int i = arr1.array.Length; i < arr2.array.Length; i++)
                    result[i] = Math.Abs(Convert.ToDecimal(arr2.array[i]));
            }
            else
            {
                for (int i = 0; i < arr2.array.Length; i++)
                    result[i] = Math.Abs(Convert.ToDecimal(arr1.array[i]) - Convert.ToDecimal(arr2.array[i]));
                for (int i = arr2.array.Length; i < arr1.array.Length; i++)
                    result[i] = Math.Abs(Convert.ToDecimal(arr1.array[i]));
            }

            return new MyArray<T>(result.Cast<T>().ToArray());
        }

        public static bool operator ==(MyArray<T> arr1, MyArray<T> arr2)
        {
            if (arr1.array.Length != arr2.array.Length) return false;
            else
                for (int i = 0; i < arr1.array.Length; i++)
                    if (!arr1.array[i].Equals(arr2.array[i]))
                        return false;

            return true;
        }

        public static bool operator !=(MyArray<T> arr1, MyArray<T> arr2)
        {
            if (arr1.array.Length != arr2.array.Length) return true;
            else
                for (int i = 0; i < arr1.array.Length; i++)
                    if (!arr1.array[i].Equals(arr2.array[i]))
                        return true;

            return false;
        }
        public static bool operator >(MyArray<T> arr, int element)
        {
            return Array.IndexOf(arr.array, element) != -1;
        }

        public static bool operator <(MyArray<T> arr, int element)
        {
            return Array.IndexOf(arr.array, element) != -1;
        }
    }
}