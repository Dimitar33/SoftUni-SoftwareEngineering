using System;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] personInfo = Console.ReadLine().Split();

            Tuple<string, string> person = new Tuple<string, string>
                (personInfo[0] + " " + personInfo[1], personInfo[2] );

            Console.WriteLine(person);

            string[] secondInput = Console.ReadLine().Split();

            Tuple<string, int> second = 
                new Tuple<string, int>(secondInput[0], int.Parse(secondInput[1]));


            Console.WriteLine(second);

            string[] nums = Console.ReadLine().Split();

            Tuple<int, double> numbers = 
                new Tuple<int, double>(int.Parse(nums[0]), double.Parse(nums[1]));

            Console.WriteLine(numbers);
        }
    }
}
