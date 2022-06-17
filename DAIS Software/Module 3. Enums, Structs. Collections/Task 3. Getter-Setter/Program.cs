namespace Task_3._Getter_Setter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coffe = new Coffe(- 3, 5, "strong");

            coffe.Grams = 3;
            coffe.Price = 6;
            coffe.Strenght = "weak";


            var coffe1 = coffe;
            coffe1.Grams = 31;
            coffe1.Price = 21;
            coffe1.Strenght = "mega strong";
        }

        public class Coffe
        {
            private int _grams;
            private double _price;
            private string _strenght;
            public Coffe(int grams, double price, string strenght)
            {
                _grams = grams;
                _price = price;
                _strenght = strenght;
            }

            public int Grams
            {
                get
                {
                    Console.WriteLine($"Grams {_grams}");
                    return this._grams;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Value can not be negative");
                    }
                    Console.WriteLine($"Grams before {_grams}");
                    value = _grams;
                    Console.WriteLine($"Grams after {_grams}");
                }
            }
            public double Price
            {
                get
                {
                    Console.WriteLine($"Price {_price}");
                    return _price;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Value can not be negative");
                    }
                    Console.WriteLine($"Price before {_price}");
                    value = _price;
                    Console.WriteLine($"Price after {_price}");
                }
            }
            public string Strenght
            {
                get
                {
                    Console.WriteLine($"Grams {_strenght}");
                    return _strenght;
                }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("Incorect strenght input");
                    }
                    _strenght = value;
                }
            }
        }
    }
}