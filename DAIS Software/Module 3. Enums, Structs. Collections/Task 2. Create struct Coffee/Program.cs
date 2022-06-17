namespace Task_2._Create_struct_Coffee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coffe = new Coffe(12, 2, "strong");

            Console.WriteLine($"Coffe before {coffe.Grams} {coffe.Price} {coffe.Strenght}");

            var coffe1 = coffe;
            coffe1.Grams = 31;
            coffe1.Price = 21;
            coffe1.Strenght = "mega strong";

            Console.WriteLine($"Coffe1 {coffe1.Grams} {coffe1.Price} {coffe1.Strenght}");
            Console.WriteLine($"Coffe after {coffe.Grams} {coffe.Price} {coffe.Strenght}");

        }
    }

    internal struct Coffe
    {
        public Coffe(int grams, double price, string strenght)
        {
            Grams = grams;
            Price = price;
            Strenght = strenght;
        }

        public int Grams { get; set; }
        public double Price{get; set; }
        public string Strenght { get; set; }
    }
}