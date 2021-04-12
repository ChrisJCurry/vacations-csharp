using System;
using System.Collections.Generic;
using Models;
using Repositories;

namespace Services
{
    public class CruisesService
    {

        private readonly CruisesRepository _repo;

        public CruisesService(CruisesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Cruise> GetAll()
        {
            return (_repo.GetAll());
        }

        internal Cruise Get(int id)
        {
            return (_repo.Get(id));
        }

        internal Cruise Create(Cruise cruise)
        {
            return (_repo.Create(cruise));
        }

        internal object Edit(Cruise cruise)
        {
            Cruise original = Get(cruise.Id);

            original.LengthInDays = cruise.LengthInDays > -1 ? cruise.LengthInDays : original.LengthInDays;
            original.Location = cruise.Location != null ? cruise.Location : original.Location;
            original.Cost = cruise.Cost > -1 ? cruise.Cost : original.Cost;
            original.CruiseLiner = cruise.CruiseLiner != null ? cruise.CruiseLiner : original.CruiseLiner;
            original.Stops = cruise.Stops > -1 ? cruise.Stops : original.Stops;

            return (_repo.Edit(original));
        }

        internal Cruise Delete(int id)
        {
            Cruise original = Get(id);
            _repo.Delete(id);

            return original;
        }
    }
}