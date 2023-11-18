using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab7
{
    public class GeometricFigure
    {
        private double height;
        private double width;
        public double square;

        protected static int objCount = 0;

        public int ObjCount
        {
            get => objCount;
        }

        public double Height
        {
            get => height;
            set
            {
                try
                {
                    if (value >= 0) height = value;
                    else throw new Exception("Height can't be less than 0");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ErrorValueException: {e.Message}!");
                }
            }
        }

        public double Width
        {
            get => width;
            set
            {
                try
                {
                    if (value >= 0) width = value;
                    else throw new Exception("Width can't be less than 0");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ErrorValueException: {e.Message}!");
                }
            }
        }

        public GeometricFigure()
        {
            objCount++;
        }

        public GeometricFigure(double height = 0, double width = 0)
        {
            this.Height = height;
            this.Width = width;
            objCount++;
        }


        // methods

        public virtual string getClassName()
        {
            return "GeometricFigure";
        }


        // override methods

        public override string ToString()
        {
            return $"Height: {this.Height}\nWidth: {this.Width}";
        }

        public override bool Equals(object obj)
        {
            GeometricFigure tmp = obj as GeometricFigure;
            if (this.Width == tmp.Width && this.Height == tmp.Height)
                return true;
            return false;
        }
    }
}