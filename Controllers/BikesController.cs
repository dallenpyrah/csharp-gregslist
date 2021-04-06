using System.Collections.Generic;
using gregslist.db;
using gregslist.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregslist.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BikesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Bike>> GetAllBikes()
        {
            try
            {
                return Ok(Fakedb.Bikes);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Bike> GetBikeById(string id)
        {
            try
            {
                Bike foundBike = Fakedb.Bikes.Find(b => b.Id == id);
                return Ok(foundBike);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Bike> Create([FromBody] Bike newBike)
        {
            try
            {
                Fakedb.Bikes.Add(newBike);
                return Ok(newBike);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Bike> DeleteBike(string id)
        {
            try
            {
                Bike currentBike = Fakedb.Bikes.Find(b => b.Id == id);
                if (currentBike == null)
                {
                    throw new System.Exception("Bike does not exist");
                }
                else
                {
                    Fakedb.Bikes.Remove(currentBike);
                    return Ok("Bike was deleted");
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Bike> EditBike(string id, Bike editedBike)
        {
            try
            {
                Bike currentBike = Fakedb.Bikes.Find(b => b.Id == id);
                if (currentBike == null)
                {
                    throw new System.Exception("Can not find bike");
                } else {
                    currentBike.Brand = editedBike.Brand;
                    currentBike.Type = editedBike.Type;
                    currentBike.Weight = editedBike.Weight;
                    currentBike.Wheels = editedBike.Wheels;
                    return Ok(currentBike);
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}