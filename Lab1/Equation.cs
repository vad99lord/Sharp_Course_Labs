using System;

namespace Lab1
{
    public class Equation
    {
        private double a;
        private double b;
        private double c;
        private double[] roots;
        public double[] Roots { get => roots; set => roots = value; }
        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double C { get => c; set => c = value; }

        public Equation()
        {
            Console.WriteLine("Введите коэффицента a, b, c: ");
            A = setNum();
            B = setNum();
            C = setNum();
            Roots = null;
            Console.Write("Введеное уравнение: ");
            Console.WriteLine("{0}x^2+{1}x+{2}", A, B, C);
        }
        public void printRoots()
        {
            if (Roots != null)
            {
                Console.WriteLine("Корни уравнения: ");
                Console.WriteLine("[{0}]", string.Join(", ", Roots));
            }
        }
        public bool solve()
        {
            if (A == 0)
            {
                Console.WriteLine("Уравнение не квадратное.");
                return false;
            }
            double D = B * B - 4 * A * C;
            if (D > 0)
            {
                double x1, x2;
                x1 = (-B + Math.Sqrt(D)) / (2 * A);
                x2 = (-B - Math.Sqrt(D)) / (2 * A);
                Roots = new double[] { x1, x2 };
            }
            else
                if (D == 0)
            {
                double x = -B / (2 * A);
                Roots = new double[] { x };
            }
            else
            {
                Console.WriteLine("Нет корней");
                return false;
            }
            return true;
        }
        private double setNum()
        {
            string strNum;
            double dest;
            bool isValid = false;
            do
            {
                strNum = Console.ReadLine();
                isValid = double.TryParse(strNum, out dest);
                if (!isValid)
                {
                    Console.WriteLine("Ошибка ввода коэффицента, повторите: ");
                }
            }
            while (!isValid);
            return dest;
        }

    }
}
