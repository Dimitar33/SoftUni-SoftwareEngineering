using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phonesInput = Console.ReadLine().Split();

            string[] sitesInput = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            for (int i = 0; i < phonesInput.Length; i++)           
            {
                try
                {
                    if (phonesInput[i].Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(phonesInput[i]));
                    }
                    else if (phonesInput[i].Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(phonesInput[i]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid number!");
                    }
                    
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }

            for (int i = 0; i < sitesInput.Length; i++)
           
            {
                try
                {

                    Console.WriteLine(smartphone.Browse(sitesInput[i]));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }

        }
    }
}
