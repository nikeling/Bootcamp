using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n---IF YOU WANT TO ENROLL THE ANIMAL IN THE ZOO SYSTEM, FILL IN THE REQUIRED INFORMATION---\n press 'a' for the aquatic animal, otherwise press any key");
            var i = Console.ReadLine();

            //IF-ELSE prints data for adding an animal depending on a pressed key

            if (i == "a")

            {   //creates an AquaticAnimal object and reads its entered data
                AquaticAnimal animal1 = new AquaticAnimal();
                Console.WriteLine("\nEnter animal's name:");
                animal1.Name = Console.ReadLine();
                Console.WriteLine("\nEnter animal's age:");
                animal1.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter animal's taxonomy:\nKingdom:");

                //creates Taxonomy object and reads its entered data
                Taxonomy taxonomy1 = new Taxonomy();
                taxonomy1.Kingdom = Console.ReadLine();
                Console.WriteLine("\nClass:");
                taxonomy1.Class = Console.ReadLine();
                Console.WriteLine("\nSpecies:");
                taxonomy1.Species = Console.ReadLine();
                //connects Taxonomy object with an animal
                animal1.Taxonomy = taxonomy1;

                //prints entered data
                Console.WriteLine($"\n--ENTERED DATA:\nName: {animal1.Name} \nAge: {animal1.Age}" +
                    $"\nKingdom: {taxonomy1.Kingdom} \nClass: {taxonomy1.Class} \nSpecies: {taxonomy1.Species}");

            } else

            {   //creates an LandAnimal object and reads its entered data
                LandAnimal animal1 = new LandAnimal();
                Console.WriteLine("\nWhat kind of vore is that animal (carnivore/herbivore/omnivore)?:");
                animal1.TypeOfVore = Console.ReadLine();
                Console.WriteLine("\nEnter animal's age:");
                animal1.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter animal's taxonomy:\nKingdom:");

                //creates Taxonomy object and reads its entered data
                Taxonomy taxonomy1 = new Taxonomy();
                taxonomy1.Kingdom = Console.ReadLine();
                Console.WriteLine("\nClass:");
                taxonomy1.Class = Console.ReadLine();
                Console.WriteLine("\nSpecies:");
                taxonomy1.Species = Console.ReadLine();
                //connects Taxonomy object with an animal
                animal1.Taxonomy = taxonomy1;

                //prints entered data
                Console.WriteLine($"\n--ENTERED DATA:\nName: {animal1.Name} \nAge: {animal1.Age}" +
                    $"\nKingdom: {taxonomy1.Kingdom} \nClass: {taxonomy1.Class} \nSpecies: {taxonomy1.Species}");

            }

            Console.WriteLine("\n---Animal's food---");
            //creates list
            List<Food> listOfFood = new List<Food>();
            
            var exit = "1";

            do
            {   //creates food object
                Food food = new Food();

                Console.WriteLine("Enter food's brand-name: ");
                food.BrandName = Console.ReadLine();

                Console.WriteLine("Enter food quantity (in kg) ");
                food.Quantity = int.Parse(Console.ReadLine());
                

                listOfFood.Add(food);

                Console.WriteLine("To finish, press 1. To continue, press any key.");
                exit = Console.ReadLine();

            }
            while (exit != "1");

            Console.WriteLine("\n---LIST OF FOOD---");

            foreach (var food in listOfFood)
            {
                Console.WriteLine($"Brand-name: {food.BrandName} \nQuantity(in kg): {food.Quantity}\n");
            }
            Console.ReadLine();




        }



    }
    }

