using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Robot : IDs
    {
        public Robot(string model, string id)
        {
            Id = id;
            Model = model;
        }

        public string Id { get; set; }

        public string Model { get; set; }
    }
}
