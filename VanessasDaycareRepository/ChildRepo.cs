using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanessasDaycare.Data;

namespace VanessasDaycareRepository
{
    //all Crud Operations are performed with in each specific REPO!
    public class ChildRepo
    {
        //The first CODE is my FAKE database
        private readonly List<Child> _childDatabase = new List<Child>();


        //CREATE!!!!!!
        public bool AddChildToDataBase(Child child)
        {
            _childDatabase.Add(child);
            return true;
        }

        //READ GET ALL
        public List<Child> GetChildren()
        {
            return _childDatabase;
        }

        public Child GetChildByName(string name)
        {
            foreach (var child in _childDatabase)
            {
                if (child.Name == name)
                {
                    return child;
                }
            }
            return null;
        }



        public bool UpdateChildInfo(string name, Child childData)
        {
            Child oldChildData = GetChildByName(name);


            if (oldChildData == null)
            {
                return false;
            }
            else
            {
                oldChildData.Name = childData.Name;
                oldChildData.Age = childData.Age;
                oldChildData.AllergyType = childData.AllergyType;
                return true;
            }

        }

        public bool RemoveChild(string name)
        {
            foreach (var child in _childDatabase)
            {
                if (child.Name == name)
                {
                    _childDatabase.Remove(child);
                    return true;
                }
            }
            return false;
        }
    }
}
