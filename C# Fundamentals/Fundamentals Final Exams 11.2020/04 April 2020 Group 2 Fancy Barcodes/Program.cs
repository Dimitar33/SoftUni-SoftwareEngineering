using System;
using System.Text.RegularExpressions;

namespace _04_April_2020_Group_2_Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string regex = @"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+";

            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();

                var match = Regex.Match(data, regex);

                if (match.Success)
                {
                    var productGroup = Regex.Matches(data, @"\d");
                    string num = string.Empty;

                    foreach (var item in productGroup)
                    {
                        num += item;
                    }
                    if (num == string.Empty)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {num}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }
        }
    }
}
