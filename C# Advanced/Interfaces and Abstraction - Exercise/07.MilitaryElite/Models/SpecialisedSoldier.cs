﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps 
        { 
            get => corps;
            set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new Exception();
                }
                corps = value;
            }
        }
    }
}
