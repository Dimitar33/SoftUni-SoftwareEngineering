using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Models.ViewModels.TripViewModels;
using SharedTrip.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Models.ViewModels.UserViewModels
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext data;

        private readonly IValidator validator;

        public TripsController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse Add() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(TripAddViewModel model)
        {
            var errors = validator.ValidateTrip(model);

            if (errors.Count > 0 )
            {
                return Error(errors);
            }

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                Seats = model.Seats,
                DepartureTime = model.DepartureTime,
                Description = model.Description,
                ImagePath = model.ImagePath
            };

            data.Trips.Add(trip);
            data.SaveChanges();

            return View();
        }


        public HttpResponse All()
        {
            var trips = data.Trips.Select(x => new TripAllViewModel
            {
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime,
                Seats = x.Seats
            }).ToList();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Details(string Id)
        {
            var trip = data.Trips.Where(x => x.Id == Id)
                .Select(x => new TripDetailsViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    Seats = x.Seats,
                    Description = x.Description

                }).FirstOrDefault();

            if (trip == null)
            {
                return Error("No such trip");
            }

            return View(trip);
        }
    }
}
