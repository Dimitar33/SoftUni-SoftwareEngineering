using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Animal animal = new Snake("asd");

            Console.WriteLine(animal.Name);
        }
    }
}