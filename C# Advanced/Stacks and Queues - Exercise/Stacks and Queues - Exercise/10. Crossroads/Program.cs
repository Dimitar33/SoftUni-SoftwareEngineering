using System;
using System.Collections.Generic;
using System.Linq;


namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int croslight = int.Parse(Console.ReadLine());
            int gratis = int.Parse(Console.ReadLine());
            string cmd = Console.ReadLine();
            string curentCar = "";
            int count = 0;
            
            Queue<string> cars = new Queue<string>();
            Queue<char> car = new Queue<char>();

            while (cmd != "END")
            {
                if (cmd == "green") // car count
                {
                    int green = croslight;
                    while (green > 0 && cars.Count > 0)
                    {
                        curentCar = cars.Peek();
                        car = new Queue<char>(cars.Dequeue());
                        count++;

                        while (car.Count > 0 && green > 0)
                        {
                            car.Dequeue();
                            green--;
                        }

                    }
                    int freeWindow = gratis;
                    while (freeWindow > 0 && car.Count > 0)
                    {                                   
                        car.Dequeue();
                        freeWindow--;
                    }
                    if (car.Count > 0)
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{curentCar} was hit at {car.Dequeue()}.");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    cars.Enqueue(cmd);
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{count} total cars passed the crossroads.");
        }
    }
}
