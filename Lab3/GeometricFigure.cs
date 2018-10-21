using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public abstract class GeometricFigure: IPrint, IComparable
    {
        public abstract double calcArea();

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
        public int CompareTo(object obj)
        {
            
            GeometricFigure figure = (GeometricFigure) obj;
            //Сравнение
            if (this.calcArea() < figure.calcArea()) return -1;
            else    if (this.calcArea() > figure.calcArea()) return 1;
                    else return 0; 
        }
    }
}
