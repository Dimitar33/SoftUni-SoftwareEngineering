using System;
using System.Text.RegularExpressions;

namespace _4._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();

            from6To10Char(pass);
            noSimbols(pass);
            atLeast2Digits(pass);

            if (!from6To10Char(pass))
            {
                Console.WriteLine("Password must be between 6 and 10 characters ");
            }

            if (!noSimbols(pass))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!atLeast2Digits(pass))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
                    
            else if (atLeast2Digits(pass) && noSimbols(pass) && from6To10Char(pass))
            {
                Console.WriteLine("Password is valid");
            }

        }

        private static bool atLeast2Digits(string pass)
        {
            int count = 0;
            
            foreach (var item in pass)
            {
                if (char.IsDigit(item))
                {
                    count++;
                    if (count == 2)
                    {
                        return true;
                    }
                }
            }
            return false;

            
        }

        private static bool noSimbols(string pass)
        {
            foreach (var item in pass)
            {
                if (!char.IsLetterOrDigit(item))
                {

                    return false;

                }
            }
            return true;
        }

        private static bool from6To10Char(string pass)
        {
            if (pass.Length > 5 && pass.Length < 11)
            {
                return true;
            }
            return false;
        }
    }
}
