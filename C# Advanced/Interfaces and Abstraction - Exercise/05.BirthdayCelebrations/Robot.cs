using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Robot 
    {
        public Robot(string model, string id)
        {
            Ids = id;
            Model = model;
           
        }

        public string Ids { get; set; }

        public string Model { get; set; }
       
    }
}
