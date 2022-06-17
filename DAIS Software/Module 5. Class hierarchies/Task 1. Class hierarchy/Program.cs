namespace Task_1._Class_hierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coffee cofe = new Coffee("late", true, 221);

            List<Beverage> beverages = new List<Beverage>();

            beverages.Add(cofe);
            beverages.Add(new Tea("Musalski", false, 44));
            beverages.Add(new Espresso("Ess", false, 55));

            foreach (var item in beverages)
            {
                Console.WriteLine(item.GetServingTemperature());
            }

        }

        public abstract class Beverage
        {
            public Beverage(string name, bool isFairTrade, int servingTemp)
            {
                Name = name;
                IsFairTrade = isFairTrade;
                Temp = servingTemp;
            }

            public string Name { get; set; }

            public bool IsFairTrade { get; set; }

            public int Temp { get; set; }

            virtual public int GetServingTemperature()
            {
                return Temp;
            }
        }

        public class Coffee : Beverage
        {
            public Coffee(string name, bool isFairTrade, int temp)
            : base(name, isFairTrade, temp) { }

            override public int GetServingTemperature()
            {
                return Temp;
            }
        }

        public class Espresso : Coffee
        {
            public Espresso(string name, bool isFairTrade, int temp)
                : base(name, isFairTrade, temp)
            {
            }

            override public int GetServingTemperature()
            {
                return Temp;
            }
        }

        sealed class Tea : Beverage
        {
            public Tea(string name, bool isFairTrade, int servingTemp)
                : base(name, isFairTrade, servingTemp)
            {
            }

            override public int GetServingTemperature()
            {
                return Temp;
            }
        }
    }
}