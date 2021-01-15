using System;

namespace GenericScale
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<string> asd = new EqualityScale<string>("asd", "as");

            Console.WriteLine( asd.AreEqual());
        }
    }
}
