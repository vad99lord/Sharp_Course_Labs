using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    
    class Circle : GeometricFigure,IPrint 
    {
        private double rad;
        public double Rad { get => rad; set => rad = value; }
        public Circle(double radius) {
            Rad = radius;
        }
        public override string ToString()
        {
            return "Circle, radius = " + Rad + ", area = " + calcArea();
        }
        public override double calcArea()
        {
            return Math.PI * Rad * Rad;
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
