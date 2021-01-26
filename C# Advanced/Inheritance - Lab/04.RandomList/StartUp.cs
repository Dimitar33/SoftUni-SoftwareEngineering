using System;

namespace CustomRandomList
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("asd");
            list.Add("dsa");
            list.Add("zxc");
           

         

            Console.WriteLine(list.RandomString(list));
            Console.WriteLine(list.RandomString(list));
            Console.WriteLine(list.RandomString(list));
        }
    }
}
