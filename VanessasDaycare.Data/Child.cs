using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanessasDaycare.Data.ENUMs;

namespace VanessasDaycare.Data
{
    //all objects will go in .Data class libary
    public class Child
    {

        public string Name { get; set; }

        public int Age { get; set; }

        public Allergies AllergyType { get; set; }

        public Child() { }
        public Child(string name, int age, Allergies allergies)
        {
            Name = name;
            Age = age;
            AllergyType = allergies;
        }

    }

}
