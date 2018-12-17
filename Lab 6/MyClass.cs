using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class MyClass : IComparable
    {
        
        public string myField = string.Empty;

        public MyClass()
        {
        }

        public MyClass(string str, int num) {
            MyProperty = num;
            MyString = str;
        }
        public MyClass(string str)
        {
            myField = str;
        }
        public MyClass(int num) {
            MyAutoImplementedProperty = num;
        }

        public int MyMethod(int parameter1, int parameter2)
        {
            Console.WriteLine("First Parameter {0}, second parameter {1}", parameter1, parameter2);
            return Math.Max(parameter1, parameter2);
        }
        public void PrintNumber() {
            Console.WriteLine(MyProperty);
        }
        public void PrintString() {
            Console.WriteLine(MyString);
        }

        [NewAttribute()]
        public int MyAutoImplementedProperty { get; set; }

        private int myPropertyVar;

        [NewAttribute(Description = "This is my and only my Property")]
        public int MyProperty
        {
            get { return myPropertyVar; }
            set { myPropertyVar = value; }
        }
        private string myStringVar;

        [NewAttribute("This is my and only my String")]
        public string MyString
        {
            get { return myStringVar; }
            set { myStringVar = value; }
        }
        public int CompareTo(object obj)
        {
            return 0;
        }
    }
}
