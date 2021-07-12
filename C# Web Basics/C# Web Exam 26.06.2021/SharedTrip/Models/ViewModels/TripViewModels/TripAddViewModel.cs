using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Models.ViewModels.TripViewModels
{
    public class TripAddViewModel
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string ImagePath { get; set; }
        public int Seats { get; set; }
        public string Description { get; set; }

    }
}
