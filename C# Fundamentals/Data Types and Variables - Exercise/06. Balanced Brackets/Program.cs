using Microsoft.VisualBasic;
using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int error = 0;
            int openingParanteses = 0;
            int closinParantheses = 0;
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();
                
                char parantheses;
                

                if (char.TryParse(str, out parantheses))
                {
                    char paran = char.Parse(str);

                    if (paran == 40 || paran == 41)
                    {

                        if (paran == 40 && openingParanteses - closinParantheses == 0)
                        {
                            openingParanteses++;
                            count++;
                            
                        }
                        else if (paran == 41 && openingParanteses - closinParantheses == 1)
                        {
                            closinParantheses++;
                            count++;

                        }
                        else
                        {
                            
                            error++;
                        }
                    }

                }

            }
            if (error == 0 && count % 2 ==0)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
