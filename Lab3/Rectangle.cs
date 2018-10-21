using System;

namespace Lab3
{
    public class Rectangle : GeometricFigure
    {
        private double a, b;
        public Rectangle(double a, double b) {
            A = a;
            B = b;
        }

        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }

        public override double calcArea()
        {
            return A * B;
        }
        public override string ToString()
        {
            return "Rectangle, a = " + A + ",b = " + B+",area = " + calcArea();
        }
    }
}
