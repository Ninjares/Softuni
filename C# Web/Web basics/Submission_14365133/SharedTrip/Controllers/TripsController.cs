using SharedTrip.Services.Trips;
using SharedTrip.ViewModels.Trips;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private ITripsServices TripsSevices { get; set; }
        public TripsController(ITripsServices services)
        {
            TripsSevices = services;
        }
        [HttpGet("/Trips/Add")]
        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn()) return Redirect("/");
            return this.View();
        }
        [HttpPost("/Trips/Add")]
        public HttpResponse Add(AddTripModel trip)
        {
            if (trip.Seats < 2 || trip.Seats > 6 || trip.Description.Length > 80)
            {
                return Redirect("/Trips/Add");
            }
            if (!TripsSevices.ValidDepartureTime(trip.DepartureTime))
            {
                return Redirect("/Trips/Add");
            }
            TripsSevices.Create(trip.StartPoint, trip.EndPoint, trip.DepartureTime, trip.ImagePath, trip.Seats, trip.Description);
            return Redirect("/");
        }
        [HttpGet("/Trips/All")]
        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn()) return Redirect("/");
            var tripsmodel = new AllTripsViewModel()
            {
                Trips = TripsSevices.GetAllTripInfo()
            };
            return this.View(tripsmodel);
        }
        [HttpGet("/Trips/Details")]
        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn()) return Redirect("/");
            if (!TripsSevices.TripExists(tripId)) return Redirect("/Trips/All");
            var model = TripsSevices.GetTripDetails(tripId);
            return this.View(model);
        }
        [HttpGet("/Trips/AddUserToTrip")]
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn()) return Redirect("/");
            if (!TripsSevices.TripExists(tripId)) return Redirect("/Trips/All");
            if(!TripsSevices.JoinTrip(tripId, User)) return Redirect("/Trips/Details?tripId="+tripId);
            return Redirect("/");
        }
    }
}
