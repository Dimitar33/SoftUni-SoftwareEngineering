using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    class Box
    {
        private double length;

        private double width;

        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    Environment.Exit(0);
                }
                length = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    Environment.Exit(0);
                }
                width = value;
            }
        }
        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                    Environment.Exit(0);
                }
                height = value;
            }
        }

        public string SurfaceArea()
        {
            double result = length * width * 2 + length * height * 2 + width * height * 2;
            return $"{result:f2}";
        }

        public string LateralSurfaceArea()
        {         
            double result =  length * height * 2 + width * height * 2;
            return $"{result:f2}";
        }

        public string Volume()
        {
            double result = length * height * width;
            return $"{result:f2}";
        }
    }
}
