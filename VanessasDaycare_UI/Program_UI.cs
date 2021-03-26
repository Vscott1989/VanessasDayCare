using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanessasDaycare.Data;
using VanessasDaycare.Data.ENUMs;
using VanessasDaycareRepository;

namespace VanessasDaycare_UI
{
    public class Program_UI
    {
        //We need to ref.. VanessaDaycareRepository

        private readonly ChildRepo _childRepo = new ChildRepo();


        public void Run()
        {
            Seed();
            StartApplication();

        }

        private void StartApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Vanessa's Daycare\n" +
                                  "1. Enlist child to Daycare\n" +
                                  "2. View all Children\n" +
                                  "3. View child By name\n" +
                                  "4. Update child Info\n" +
                                  "5. Remove child from Daycare\n" +
                                  "----------------------------\n" +
                                  "6. Add Caregiver to Daycare\n" +
                                  "25. Close App.\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {

                    case "1":
                        EnlistChildToDaycare();
                        break;
                    case "2":
                        ViewAllChildren();
                        break;
                    case "3":
                        ViewChildByName();
                        break;
                    case "4":
                        UpdateChildInfo();
                        break;
                    case "5":
                        RemoveChildFromDaycare();
                        break;
                    case "25":
                        isRunning = false;
                        Console.WriteLine("Thank You, Press any key to continue...");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        private void RemoveChildFromDaycare()
        {
            Console.Clear();


            Console.WriteLine("Please input childs name");
            string userInputChildsNameForRemove = Console.ReadLine();

            bool isSuccessful = _childRepo.RemoveChild(userInputChildsNameForRemove);
            if (isSuccessful)
            {
                Console.WriteLine("Child was Removed");
            }
            else
            {
                Console.WriteLine("child was NOT Removed");
            }

            Console.ReadKey();
        }

        private void UpdateChildInfo()
        {
            Console.Clear();

            Console.WriteLine("Please input childs name");
            string userInputChildsNameForUpdate = Console.ReadLine();


            Child ChildData = new Child();
            int userInputAllergyValue;
            Console.WriteLine("Please Enter the Childs name:");
            string userInputChildName = Console.ReadLine();
            ChildData.Name = userInputChildName;

            Console.WriteLine("Please enter the Childs Age:");
            int userInputChildAge = int.Parse(Console.ReadLine());
            ChildData.Age = userInputChildAge;

            Console.WriteLine("Dose the child have Allergies? (y/n)");
            string userInputHaveAllergies = Console.ReadLine().ToLower();

            if (userInputHaveAllergies == "y")
            {
                Console.WriteLine("Which allergies dose the child have?\n" +
                    "1. Drug Allergy\n" +
                    "2. Food allergy\n" +
                    "3. Insect Allergy\n");

                userInputAllergyValue = int.Parse(Console.ReadLine());
                ChildData.AllergyType = (Allergies)userInputAllergyValue;




            }
            else
            {
                ChildData.AllergyType = Allergies.No_Allergies;
            }


          bool isSuccessful =  _childRepo.UpdateChildInfo(userInputChildsNameForUpdate,ChildData);
            if (isSuccessful)
            {
                Console.WriteLine("Child was Updated");
            }
            else
            {
                Console.WriteLine("child was NOT updated");
            }


            Console.ReadKey();
        }

        private void ViewChildByName()
        {
            Console.Clear();

            Console.WriteLine("Please insert Child Name:");
            string userInput = Console.ReadLine();
            Child child = _childRepo.GetChildByName(userInput);

            if (child == null)
            {
                Console.WriteLine($"the child with name : {userInput} Dose NOT exist");

            }
            else
            {
                DisplayChildInfo(child);
            }

            Console.ReadKey();
        }

        private void ViewAllChildren()
        {
            Console.Clear();

            List<Child> children = _childRepo.GetChildren();
            foreach (var child in children)
            {
                DisplayChildInfo(child);
            }
            

            Console.ReadKey();
        }
        private void DisplayChildInfo(Child child)
        {
                 Console.WriteLine($"Child Name: {child.Name}\n" +
                    $"Child age: {child.Age}\n" +
                    $"Allergies: {child.AllergyType}");
        }
        private void EnlistChildToDaycare()
        {
            Console.Clear();

            Child child = new Child();
            int userInputAllergyValue;
            Console.WriteLine("Please Enter the Childs name:");
            string userInputChildName = Console.ReadLine();
            child.Name = userInputChildName;

            Console.WriteLine("Please enter the Childs Age:");
            int userInputChildAge = int.Parse( Console.ReadLine());
            child.Age = userInputChildAge;

            Console.WriteLine("Dose the child have Allergies? (y/n)");
            string userInputHaveAllergies = Console.ReadLine().ToLower();

            if (userInputHaveAllergies == "y")
            {
                Console.WriteLine("Which allergies dose the child have?\n" +
                    "1. Drug Allergy\n" +
                    "2. Food allergy\n" +
                    "3. Insect Allergy\n");

                userInputAllergyValue = int.Parse(Console.ReadLine());
                child.AllergyType = (Allergies)userInputAllergyValue;




            }
            else
            {
                child.AllergyType = Allergies.No_Allergies;
            }

            _childRepo.AddChildToDataBase(child);

            Console.ReadKey();
        }

        private void Seed()
        {
            Child childA = new Child("Bob", 1, Allergies.Food_Allergy);
            Child childB = new Child("Yami", 5, Allergies.No_Allergies);
            Child childC = new Child("Nick", 2, Allergies.Insect_Allergy);

            _childRepo.AddChildToDataBase(childA);
            _childRepo.AddChildToDataBase(childB);
            _childRepo.AddChildToDataBase(childC);

        }
    }
}
