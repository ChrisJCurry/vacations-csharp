using System;
using System.Collections.Generic;
using System.Data;
using Models;
using Dapper;

namespace Repositories
{
    public class CruisesRepository
    {

        public readonly IDbConnection _db;

        public CruisesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Cruise> GetAll()
        {
            string sql = "SELECT * FROM cruises;";
            return (_db.Query<Cruise>(sql));
        }

        internal Cruise Get(int id)
        {
            string sql = "SELECT * FROM cruises WHERE id = @id;";
            return (_db.QueryFirstOrDefault<Cruise>(sql, new { id }));
        }

        internal Cruise Create(Cruise cruise)
        {
            string sql = @"
            INSERT INTO cruises
            (cost, lengthInDays, location, cruiseLiner, stops)
            VALUES
            (@Cost, @LengthInDays, @Location, @CruiseLiner, @Stops);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, cruise);
            cruise.Id = id;
            return cruise;
        }

        internal object Edit(Cruise cruise)
        {
            string sql = @"
            UPDATE cruises
            SET
                cost = @Cost,
                lengthInDays = @LengthInDays,
                location = @Location,
                cruiseLiner = @CruiseLiner,
                stops = @Stops
            WHERE id = @Id;
            SELECT * FROM cruises WHERE id = @Id;";
            return (_db.QueryFirstOrDefault<Cruise>(sql, cruise));
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM cruises WHERE id = @Id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}