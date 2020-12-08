using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            var i =( Console.ReadLine());
            int intvalue ;
            double doubleType;
            bool boolType;
            char simbol;
            string dataType = "";



            while (i != "END")
            {

                
                if (int.TryParse(i, out intvalue))
                {
                   dataType = "integer";
                }
                else if (char.TryParse(i , out simbol))
                {
                    dataType = "character";
                }
                else if (double.TryParse(i, out doubleType))
                {
                    dataType = "floating point";
                }
                else if (bool.TryParse(i, out boolType))
                {
                    dataType = "boolean";
                }
                else
                {
                    dataType = "string";
                }
                Console.WriteLine($"{i} is {dataType} type");
                i = Console.ReadLine();
            }


        }
    }
}
