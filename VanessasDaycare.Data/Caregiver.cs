using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanessasDaycare.Data
{
    public class Caregiver
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Child> Children { get; set; }
        public Room Classroom { get; set; }

        public Caregiver() { }
        public Caregiver(string name, Room classroom, List<Child> children)
        {
            Name = name;
            Classroom = classroom;
            Children = children;
        }

    }
}
