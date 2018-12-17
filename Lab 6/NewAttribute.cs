using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    //только для свойств класса, нельзя применять несколько NewAttribute,
    //не наследуется от класса с атрибутами
    [AttributeUsage(AttributeTargets.Property,
        AllowMultiple = false,
        Inherited = false)]
    class NewAttribute : Attribute
    {
        public NewAttribute() {
            AutoImplement();
        }
        public NewAttribute(string DescriptionParam)
        {
            Description = DescriptionParam;
        }
        private void AutoImplement() {
            Description = "Property is auto implemented";
        }
        public string Description { get; set; }
    }
}
