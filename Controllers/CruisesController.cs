using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CruisesController : ControllerBase
    {
        private readonly CruisesService _cruisesService;

        public CruisesController(CruisesService cruisesService)
        {
            _cruisesService = cruisesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cruise>> GetAll()
        {
            try
            {
                return Ok(_cruisesService.GetAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Cruise> Get(int id)
        {
            try
            {
                return Ok(_cruisesService.Get(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Cruise> Create([FromBody] Cruise cruise)
        {
            try
            {
                return Ok(_cruisesService.Create(cruise));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Cruise> Edit(int id, [FromBody] Cruise cruise)
        {
            try
            {
                cruise.Id = id;
                return Ok(_cruisesService.Edit(cruise));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Cruise> Delete(int id)
        {
            try
            {
                return Ok(_cruisesService.Delete(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}