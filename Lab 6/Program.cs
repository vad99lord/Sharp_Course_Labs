using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    delegate int ThreeNumsDelegate(int num1, int num2, int num3);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Work with Reflection-------");
            int num1 = 7, num2 = 4, num3 = 15;
            Console.WriteLine("Values of numbers: {0}, {1}, {2}", num1, num2, num3);
            Console.WriteLine("Using method without Func< >");
            //Передача метода-делегата
            ThreeNumsMethod("Max value with delegate: ", num1, num2, num3, Max);
            //Передача лямюда-выражения
            ThreeNumsMethod("Max value with lambda: ", num1, num2, num3,
                (int x, int y, int z) =>
                {
                    return Math.Max(Math.Max(x, y), z);
                }
            );
            
            Console.WriteLine("Using method with Func< >");
            //Передача метода-делегата
            ThreeNumsMethod("Min value with delegate: ", num1, num2, num3, Min);
            //Передача лямюда-выражения
            ThreeNumsMethod("Min value with lambda: ", num1, num2, num3,
                (int x, int y, int z) =>
                {
                    return Math.Min(Math.Min(x, y), z);
                }
            );

            Console.WriteLine("\n\n------Work with Reflection-------");
            TypeInfo();
            AttributeInfo();
            InvokeMemberInfo();
            Console.ReadLine();
        }
        static int Min(int p1, int p2, int p3)
        { 
            return Math.Min(Math.Min(p1, p2), p3);
        }

        static int Max(int p1, int p2, int p3)
        {
            return Math.Max(Math.Max(p1, p2), p3);
        }
        static void ThreeNumsMethod(string str, int i1, int i2, int i3, Func<int, int, int, int> threeNumsParam)
        {
            int Result = threeNumsParam(i1, i2, i3);
            Console.WriteLine(str + Result.ToString());
        }
        static void TypeInfo()
        {
            MyClass obj = new MyClass();
            Type t = obj.GetType();
           
            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nПоля данных (public):");
            foreach (var x in t.GetFields())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nForInspection реализует IComparable -> " +
            t.GetInterfaces().Contains(typeof(IComparable))
            );
        }
        static void AttributeInfo()
        {
            Type t = typeof(MyClass);
            Console.WriteLine("\nСвойства, помеченные атрибутом:");
            foreach (var x in t.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(NewAttribute), out attrObj))
                {
                    NewAttribute attr = attrObj as NewAttribute;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }
        }
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;

            //Поиск атрибутов с заданным типом
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }

            return Result;
        }
        static void InvokeMemberInfo()
        {
            Type t = typeof(MyClass);
            Console.WriteLine("\nВызов метода:");

            //MyClass fi = new MyClass();
            MyClass fi = (MyClass) t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] {"MyStringggg", 999 });

            //Параметры вызова метода
            object[] parameters = new object[] { 678, fi.MyProperty };
            //Вызов метода
            object Result = t.InvokeMember("MyMethod", BindingFlags.InvokeMethod, null, fi, parameters);
            Console.WriteLine("Max = {0}", Result);
        }
    }

}
