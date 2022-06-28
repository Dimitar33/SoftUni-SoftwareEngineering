using Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Data;
using Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Models;
using Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Controllers
{
    [ApiController]
    [Route("Problems")]
    public class ProblemsController : ControllerBase
    {
        private readonly AppDbContext data;

        public ProblemsController(AppDbContext db)
        {
            data = db;
        }

        [HttpGet]
        public IEnumerable<Problem> Get()
        {
            return data.Problems.ToList();
        }

        [HttpPost]
        public Problem Post(ProblemViewModel problemModel)
        {

            var problerm = new Problem
            {
                Description = problemModel.Description,
                Date = DateTime.Now,
            };
            data.Problems.Add(problerm);
            data.SaveChanges();

            var car = data.Cars.FirstOrDefault(x => x.Registration == problemModel.Car.Registration);

            if (car == null)
            {
                car = CreateCar(problemModel.Car, problerm.Id);
            }

            problerm.Cars.Add(car);

            data.SaveChanges();

            return problerm;
        }

        [HttpPut("{id}")]
        public Problem Put(ProblemViewModel probModel, int id)
        {
            var problem = data.Problems.FirstOrDefault(x => x.Id == id);

            if (problem == null)
            {
                return null;
            }

            var car = data.Cars.FirstOrDefault(x => x.Registration == probModel.Car.Registration);

            if (car == null)
            {
                car = CreateCar(probModel.Car, problem.Id);
                problem.Cars.Add(car);
            }

            problem.Description = probModel.Description;

            data.SaveChanges();

            return problem;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var problem = data.Problems.FirstOrDefault(x => x.Id == id);

            if (problem == null)
            {
                return "No such problem";
            }

            data.Problems.Remove(problem);
            data.SaveChanges();

            return "Problem deleted successfully";
        }

        private Car CreateCar(CarViewModel carModel, int id)
        {
            var car = new Car
            {
                Make = carModel.Make,
                Color = carModel.Color,
                Registration = carModel.Registration,
                ProblemId = id
            };

            data.Cars.Add(car);
            data.SaveChanges();

            return car;
        }
    }
}
