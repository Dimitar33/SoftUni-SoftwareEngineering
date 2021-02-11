using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    class Clinic
    {
        public Clinic(int capacity)
        {
            Capacity = capacity;
            Pets = new List<Pet>();
        }

        public List<Pet> Pets { get; set; }

        public int Capacity { get; set; }

        public int Count { get => Pets.Count; }
        public void Add(Pet pet)
        {
            if (Pets.Count < Capacity)
            {
                Pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet petToRemove = Pets.FirstOrDefault(c => c.Name == name);

            if (petToRemove == null)
            {
                return false;
            }
            Pets.Remove(petToRemove);
            return true;
        }

        public Pet GetPet(string name , string owner)
        {
            Pet curentPet = Pets.FirstOrDefault(c => c.Name == name && c.Owner == owner);

            return curentPet;
        }

        public Pet GetOldestPet()
        {
            return Pets.OrderByDescending(c => c.Age).First();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (var item in Pets)
            {
                sb.AppendLine($"Pet {item.Name} with owner: {item.Owner}");
            }

            return sb.ToString().Trim();
        }
    }
}
