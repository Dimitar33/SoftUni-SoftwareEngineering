using System;

namespace _09.ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();

            while (personInfo[0] != "End")
            {
                var citizen = new Citizen(personInfo[0], personInfo[1], personInfo[2]);
                IPerson person = citizen;
                IResident resident = citizen;

                // Console.WriteLine(((IPerson)citizen).GetName()); (also works)
                // Console.WriteLine(((IResident)citizen).GetName());

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());


                personInfo = Console.ReadLine().Split();
            }
        }
    }
}
