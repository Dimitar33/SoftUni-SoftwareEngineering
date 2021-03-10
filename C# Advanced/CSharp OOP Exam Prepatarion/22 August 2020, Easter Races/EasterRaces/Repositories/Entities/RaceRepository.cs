﻿using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace> 
    {
        private List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Races => races.ToList();
        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return races;
        }

        public IRace GetByName(string name)
        {
            return races.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model);

        }
    }
}
