using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Equation e = new Equation();
            if (e.solve())
            {
                e.printRoots();
            }
            Console.ReadLine();
        }
    }
}
