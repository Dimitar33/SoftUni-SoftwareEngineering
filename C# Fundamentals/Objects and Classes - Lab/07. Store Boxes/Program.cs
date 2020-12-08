using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();

            List<Box> boxes = new List<Box>();

            Box box = new Box();

            while (data[0] != "end")
            {
                box = new Box();

                box.serialNumber = int.Parse( data[0]);
                box.name = data[1];
                box.quantity = int.Parse( data[2]);
                box.price = double.Parse( data[3]);

                boxes.Add(box);

                data = Console.ReadLine().Split();

            }
            boxes = boxes.OrderBy(c => c.quantity * c.price).ToList();
            boxes.Reverse();
            foreach (Box item in boxes)
            {
                Console.WriteLine(item.serialNumber);
                Console.WriteLine($"-- {item.name} - ${item.price:f2}: {item.quantity}");
                Console.WriteLine($"-- ${(item.price * item.quantity):f2}");
                
            }
        }

        class Box
        {
            public int serialNumber { get; set; }
            public string name { get; set; }
            public int quantity { get; set; }
            public double price { get; set; }
        }
    }
}
