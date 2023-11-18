using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab7
{
    public abstract class Shape<T>
    {
        public abstract T CalculateArea();
    }
    public class Circle : Shape<double>
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
    public class Square : Shape<int>
    {
        public int SideLength { get; set; }

        public override int CalculateArea()
        {
            return SideLength * SideLength;
        }
    }



    class Person<T>
    {
        public T Id { get; }
        public Person(T id)
        {
            Id = id;
        }
    }
    class IntPerson<T> : Person<int>
    {
        public T Code { get; set; }
        public IntPerson(int id, T code) : base(id)
        {
            Code = code;
        }
    }
}
