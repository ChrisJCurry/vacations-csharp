using System;
using System.Collections.Generic;
using System.Data;
using Models;
using Dapper;

namespace Repositories
{
    public class TripsRepository
    {

        public readonly IDbConnection _db;

        public TripsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Trip> GetAll()
        {
            string sql = "SELECT * FROM trips;";
            return (_db.Query<Trip>(sql));
        }

        internal Trip Get(int id)
        {
            string sql = "SELECT * FROM trips WHERE id = @id;";
            return (_db.QueryFirstOrDefault<Trip>(sql, new { id }));
        }

        internal Trip Create(Trip trip)
        {
            string sql = @"
            INSERT INTO trips
            (cost, lengthInDays, location, airline, layovers)
            VALUES
            (@Cost, @LengthInDays, @Location, @Airline, @Layovers);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, trip);
            trip.Id = id;
            return trip;
        }

        internal object Edit(Trip trip)
        {
            string sql = @"
            UPDATE trips
            SET
                cost = @Cost,
                lengthInDays = @LengthInDays,
                location = @Location,
                airline = @Airline,
                layovers = @Layovers
            WHERE id = @Id;
            SELECT * FROM trips WHERE id = @Id;";
            return (_db.QueryFirstOrDefault<Trip>(sql, trip));
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM trips WHERE id = @Id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}