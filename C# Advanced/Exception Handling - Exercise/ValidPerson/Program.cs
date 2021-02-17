using System;
using System.Collections.Generic;

namespace ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {


            //Person pesho = new Person("Pesho", "Peshev", 24);
            //Person noName = new Person(string.Empty, "Peshev", 24);
            //Person NoLastName = new Person("Pesho", null, 24);
            //Person negativeAge = new Person("Pesho", "Kolev", -1);
            //Person tooOld = new Person("Pesho", "Peshev", 241);

            //for (int i = 0; i < 5; i++)
            //{
            //    try
            //    {
            //        string[] info = Console.ReadLine().Split();

            //        Person person = new Person(info[0], info[1], int.Parse(info[2]));
            //    }
            //    catch (ArgumentNullException ex)
            //    {

            //        Console.WriteLine(ex.Message);
            //    }
            //    catch (ArgumentOutOfRangeException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }

            //}

            try
            {
                Student student = new Student("Pesh3o", "pehso@mail");
                Console.WriteLine(student.Name);
            }
            catch (InvalidPersonNameException ex)
            {

                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
