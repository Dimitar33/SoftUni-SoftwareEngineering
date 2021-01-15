using System;
using System.Linq;

namespace _08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();

            string name = $"{personInfo[0]} {personInfo[1]}";       
            string adress = personInfo[2];
            string town = string.Join(" ", personInfo.Skip(3));

            Threeuple<string, string, string> person =
                new Threeuple<string, string, string>(name, adress, town);


            Console.WriteLine(person);

            string[] secondInput = Console.ReadLine().Split();

            string thirdPart = "";

            if (secondInput[2] == "drunk")
            {
                thirdPart = "True";
            }
            else
            {
                thirdPart = "False";
            }

            Threeuple<string, int, string> second =
                new Threeuple<string, int, string>
                (secondInput[0], int.Parse(secondInput[1]), thirdPart);


            Console.WriteLine(second);
            
            string[] nums = Console.ReadLine().Split();

           

            Threeuple<string, double, string> numbers =
                new Threeuple<string, double, string>
                (nums[0], double.Parse(nums[1]) , nums[2]);

            Console.WriteLine(numbers);
        }
    }
}
