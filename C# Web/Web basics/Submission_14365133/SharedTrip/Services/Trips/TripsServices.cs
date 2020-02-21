using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedTrip.Services.Trips
{
    public class TripsServices : ITripsServices
    {
        private readonly string dateTimeFormat = "dd.MM.yyyy HH:mm";
        private readonly ApplicationDbContext db;
        public TripsServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string startpoint, string endpoint, string departutretime, string imagepath, int seats, string description)
        {
            var trip = new Trip()
            {
                StartPoint = startpoint,
                EndPoint = endpoint,
                ImagePath = imagepath,
                Seats = seats,
                Description = description,
                DepartureTime = DateTime.ParseExact(departutretime, dateTimeFormat, CultureInfo.InvariantCulture)
            };
            db.Trips.Add(trip);
            db.SaveChanges();
        }

        public IEnumerable<TripInfo> GetAllTripInfo()
        {
            var trips = db.Trips.Select(x => new TripInfo()
            {
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                Seats = x.Seats - db.UserTrips.Where(j => j.TripId == x.Id).Count(),
                TripId = x.Id,
                DepartureTime = x.DepartureTime.ToString(dateTimeFormat)
            }).ToArray();
            return trips;
        }

        public TripDetails GetTripDetails(string tripId)
        {
            var trip = db.Trips.FirstOrDefault(x => x.Id == tripId);
            var details = new TripDetails()
            {
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime.ToString(dateTimeFormat),
                Description = trip.Description,
                ImagePath = trip.ImagePath,
                Seats = trip.Seats - db.UserTrips.Where(x => x.TripId == tripId).Count(),
                TripId = trip.Id

            };
            return details;
        }

        public bool JoinTrip(string tripId, string userId)
        {
            var usertrip = new UserTrip()
            {
                TripId = tripId,
                UserId = userId
            };
            if (!db.UserTrips.Any(x => x.TripId == tripId && x.UserId == userId) &&
                 db.UserTrips.Where(x => x.TripId == tripId).Count() < db.Trips.Find(tripId).Seats)
            {
                db.UserTrips.Add(usertrip);
                db.SaveChanges();
                return true;
            }
            else return false;
        }

        public bool TripExists(string tripId)
        {
            return db.Trips.Any(x => x.Id == tripId);
        }

        public bool ValidDepartureTime(string departuretime)
        {
            DateTime placeholder = new DateTime();
            return DateTime.TryParseExact(departuretime, dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out placeholder);
        }
    }
}
