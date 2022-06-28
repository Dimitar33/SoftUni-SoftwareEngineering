using Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Data;
using Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Models;
using Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Controllers
{

    [ApiController]
    [Route("Search")]
    public class SearchController : ControllerBase
    {
        private readonly AppDbContext data;

        public SearchController(AppDbContext db)
        {
            data = db;
        }

        [HttpGet("{id}")]
        public IQueryable<Problem> Search(string id)
        {
            IQueryable<Problem> probQuery = data.Problems.AsQueryable();

            if (!string.IsNullOrWhiteSpace(id))
            {
                probQuery = probQuery.Where(x => x.Description.Contains(id) ||
                                                 x.Cars.Select(x => x.Make).Contains(id));
            }

            return probQuery;


            // --- returning only the cars ---

            //var ads = probQuery.Select(x => x.Cars.Select(c => new CarViewModel
            //{
            //    Make = c.Make,
            //    Color = c.Color,
            //    Registration = c.Registration
            //}));


        }
    }
}
