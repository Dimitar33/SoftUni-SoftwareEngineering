
namespace Task_1._Static_class
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine(Mathematics.Abs(2.33m));
            Console.WriteLine(Mathematics.BigMul(2, 3));
            Console.WriteLine(Mathematics.Ceiling(2.33));
            Console.WriteLine(Mathematics.Floor(2.33));
            Console.WriteLine(Mathematics.Exp(2.33));
            Console.WriteLine(Mathematics.Max(2.33, 3.12));
            Console.WriteLine(Mathematics.Min(2.33, 3.12));
            Console.WriteLine(Mathematics.Round(2.33));
            Console.WriteLine(Mathematics.Sin(2.33));
            Console.WriteLine(Mathematics.Cos(2.33));
            Console.WriteLine(Mathematics.Tan(2.33));


        }
    }     
    public static class Mathematics
    {
        static double E = 2.7182818284590451;

        static double PI = 3.1415926535897931;

        public static decimal Abs(decimal value)
        {
            if (value < 0)
            {
                value *= -1;
            }
            return value;
        }

        //Produces the full product of two 32-bit numbers. 

        public static long BigMul(int a, int b)
        {
            return a * b;
        }

        //Returns the smallest integral value that is greater than or equal to the specified 

        //     decimal number. 

        public static double Ceiling(double d)
        {
            return Math.Ceiling(d);
        }

        //Returns the largest integer less than or equal to the specified decimal number. 

        public static double Floor(double d)
        {
            return Math.Floor(d);
        }

        //Returns e raised to the specified power. 

        public static double Exp(double d)
        {
            return Math.Pow(d, 2);
        }

        // Returns the larger/smaller of two double-precision floating-point numbers.


        public static double Max(double val1, double val2)
        {
            return Math.Max(val1, val2);
        }

        public static double Min(double val1, double val2)
        {
            return Math.Min(val1, val2);
        }

        // Rounds a decimal value to the nearest integral value. 

        public static double Round(double a)
        {
            return Math.Round(a);
        }

        // Returns the sine of the specified angle. 

        public static double Sin(double a)
        {
            return Math.Sin(a);
        }

        // Returns the cosine of the specified angle. 

        public static double Cos(double d)
        {
            return Math.Cos(d);
        }

        // Returns the tangent of the specified angle. 

        public static double Tan(double a)
        {
            return Math.Tan(a);
        }

    }


}
