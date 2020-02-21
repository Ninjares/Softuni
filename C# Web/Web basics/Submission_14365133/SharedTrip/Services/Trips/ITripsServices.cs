using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services.Trips
{
    public interface ITripsServices
    {
        void Create(string startpoint, string endpoint, string departutretime, string imagepath, int seats, string description);
        IEnumerable<TripInfo> GetAllTripInfo();
        TripDetails GetTripDetails(string tripId);
        bool ValidDepartureTime(string departuretime);
        bool TripExists(string TripId);
        bool JoinTrip(string tripId, string userId);
    }
}
