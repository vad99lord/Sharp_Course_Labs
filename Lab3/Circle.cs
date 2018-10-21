using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    
    class Circle : GeometricFigure
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
       
    }
}
