using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab7.Interfaces
{
    interface IArray<T> // обобщенный интерфейс 
    {
        void Add(T elem);
        void Remove(int index);
        void Show();
    }
}