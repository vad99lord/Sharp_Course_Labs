using System;
namespace Lab3
{
    public class Square : Rectangle
    {

        public Square(double a) : base(a, a) { }
        public override string ToString()
        {
            return "Square, " + "a = "+ A+",area = "+calcArea();
        }
    }
}
