using System;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Enumerable.Range(1, 11).ToArray();

            Database.Database data = new Database.Database(nums);

            data.Remove();
            

            Console.WriteLine(data.Count);
        }
    }
}
