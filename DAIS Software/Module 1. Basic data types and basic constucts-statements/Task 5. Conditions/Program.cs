namespace Task_5._Conditions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var word = "cat";

            if (word == "dog")
            {
                Console.WriteLine("its a dog");
            }
            else if (word == "donkey")
            {
                Console.WriteLine("its a donkey");
            }
            else if (word == "cat")
            {
                Console.WriteLine("its a cat");
            }
            else
            {
                Console.WriteLine("not an animal");
            }


            switch (word)
            {
                case "dog":
                    Console.WriteLine("dog");
                    break;

                case "donkey":
                    Console.WriteLine("donkey");
                    break;

                case "cat":
                    Console.WriteLine("cat");
                    break;

                default:
                    Console.WriteLine("fish");
                    break;
            }

        }
    }
}