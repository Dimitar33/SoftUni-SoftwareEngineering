namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Cake cake = new Cake("Parfe");

            System.Console.WriteLine(cake.Calories);
        }
    }
}