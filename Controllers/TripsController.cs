using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {

        private readonly TripsService _tripsService;

        public TripsController(TripsService tripsService)
        {
            _tripsService = tripsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Trip>> GetAll()
        {
            try
            {
                return Ok(_tripsService.GetAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Trip> Get(int id)
        {
            try
            {
                return Ok(_tripsService.Get(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Trip> Create([FromBody] Trip trip)
        {
            try
            {
                return Ok(_tripsService.Create(trip));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Trip> Edit(int id, [FromBody] Trip trip)
        {
            try
            {
                trip.Id = id;
                return Ok(_tripsService.Edit(trip));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Trip> Delete(int id)
        {
            try
            {
                return Ok(_tripsService.Delete(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}