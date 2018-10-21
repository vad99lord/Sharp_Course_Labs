using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(3, 4);
            Circle circ = new Circle(4);
            Square square = new Square(5);
            Circle circ2 = new Circle(6);
            Rectangle rect2 = new Rectangle(5, 6);


            //ARRAYLIST
            Console.WriteLine("\nArrayList");
            ArrayList al = new ArrayList();
            al.Add(circ);
            al.Add(rect);
            al.Add(square);
            al.Add(rect2);
            al.Add(circ2);

            Console.WriteLine("\nArrayList - до сортировки");
            foreach (var figure in al)
                Console.WriteLine(figure);
            Console.WriteLine("\nArrayList - сортировка");
            al.Sort();
            foreach (var figure in al)
                Console.WriteLine(figure);


            //LIST
            Console.WriteLine("\nList<Figure>");
            List<GeometricFigure> fl = new List<GeometricFigure>();
            fl.Add(circ);
            fl.Add(rect);
            fl.Add(square);
            fl.Add(rect2);
            fl.Add(circ2);

            Console.WriteLine("\nПеред сортировкой:");
            foreach (var x in fl) Console.WriteLine(x);
            fl.Sort();
            Console.WriteLine("\nПосле сортировки:");
            foreach (var x in fl) Console.WriteLine(x);

            //MATRIX
            Console.WriteLine("\nМатрица");
            Matrix<GeometricFigure> matrix = new Matrix<GeometricFigure>(5, 5, 5, new FigureMatrixCheckEmpty());
            matrix[3,0, 0] = rect;
            matrix[1, 1,4] = square;
            matrix[2, 2,2] = circ;
            matrix[3, 2, 1] = circ2;
            matrix[0, 4, 3] = rect2;
            Console.WriteLine(matrix.ToString());

            //Stack
            Console.WriteLine("\nСтек");
            SimpleStack<GeometricFigure> stack = new SimpleStack<GeometricFigure>();
            stack.Push(rect);
            stack.Push(circ2);
            stack.Push(square);
            stack.Push(rect2);
            stack.Push(circ);
            while (stack.Count > 0)
            {
                GeometricFigure f = stack.Pop();
                Console.WriteLine(f);
            }
            Console.ReadLine();


        }
    }
}
