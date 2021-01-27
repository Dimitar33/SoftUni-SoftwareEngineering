using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Hero wizard = new Wizard("Bartuk", 55);

            Console.WriteLine(wizard);
        }
    }
}
