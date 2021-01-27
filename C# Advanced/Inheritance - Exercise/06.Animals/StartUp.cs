
using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType = Console.ReadLine();


            List<Animal> animals = new List<Animal>();

            while (animalType != "Beast!")
            {

                string[] animalInfo = Console.ReadLine().Split();
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                if (age < 1)
                {
                    Console.WriteLine("Invalid input!");
                    animalType = Console.ReadLine();
                    continue;
                }
                if (gender != "Female" && gender != "Male")
                {
                    Console.WriteLine("Invalid input!");
                    animalType = Console.ReadLine();
                    continue;
                }

                switch (animalType)
                {
                    case "Dog":

                        Dog dog = new Dog(name, age , gender);
                        animals.Add(dog);

                        break;
                    case "Cat":

                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);

                        break;
                    case "Frog":

                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);

                        break;
                    case "Kittens":

                        Kitten kittens = new Kitten(name, age, gender);
                        animals.Add(kittens);

                        break;
                    case "Tomcat":

                        Tomcat tomkat = new Tomcat(name, age, gender);
                        animals.Add(tomkat);

                        break;                           

                    default:
                        break;
                     
                }

                animalType = Console.ReadLine();
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item.GetType().Name);
                Console.WriteLine($"{item.Name} {item.Age} {item.Gender}");
                Console.WriteLine(item.ProduceSound());
            }
        }
    }
}
