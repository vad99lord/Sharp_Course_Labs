﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(3, 4);
            Circle circ = new Circle(4);
            Square square = new Square(5);
            rect.Print();
            circ.Print();
            square.Print();
            Console.ReadLine();
        }
    }
}
