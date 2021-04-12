using System;
using System.Collections.Generic;
using Models;
using Repositories;

namespace Services
{
    public class TripsService
    {

        private readonly TripsRepository _repo;

        public TripsService(TripsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Trip> GetAll()
        {
            return (_repo.GetAll());
        }

        internal Trip Get(int id)
        {
            return (_repo.Get(id));
        }

        internal Trip Create(Trip trip)
        {
            return (_repo.Create(trip));
        }

        internal object Edit(Trip trip)
        {
            Trip original = Get(trip.Id);

            original.LengthInDays = trip.LengthInDays > -1 ? trip.LengthInDays : original.LengthInDays;
            original.Location = trip.Location != null ? trip.Location : original.Location;
            original.Cost = trip.Cost > -1 ? trip.Cost : original.Cost;
            original.Airline = trip.Airline != null ? trip.Airline : original.Airline;
            original.Layovers = trip.Layovers > -1 ? trip.Layovers : original.Layovers;

            return (_repo.Edit(original));
        }

        internal Trip Delete(int id)
        {
            Trip original = Get(id);
            _repo.Delete(id);

            return original;
        }
    }
}