using System.Collections.Generic;
using gregslist.db;
using gregslist.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<House>> GetAll()
        {
            try
            {
                return Ok(Fakedb.Houses);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<House> GetOneById(string id)
        {
            try
            {
                House houseFound = Fakedb.Houses.Find(h => h.Id == id);
                if (houseFound == null)
                {
                    throw new System.Exception("Invalid Id");
                }
                else
                {
                    return Ok(houseFound);
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]

        public ActionResult<House> Create([FromBody] House newHouse)
        {
            try
            {
                Fakedb.Houses.Add(newHouse);
                return Ok(newHouse);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<House> DeleteHouse(string id)
        {
            try
            {
                House deletedHouse = Fakedb.Houses.Find(h => h.Id == id);
                if (deletedHouse == null)
                {
                    throw new System.Exception("House does not exist");
                }
                else
                {
                    Fakedb.Houses.Remove(deletedHouse);
                    return Ok("House was deleted");
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<House> EditHouse(string id, House editedHouse)
        {
            try
            {
                House currentHouse = Fakedb.Houses.Find(h => h.Id == id);
                currentHouse.Bedrooms = editedHouse.Bathrooms;
                currentHouse.Bathrooms = editedHouse.Bathrooms;
                currentHouse.Price = editedHouse.Price;
                currentHouse.Year = editedHouse.Year;
                currentHouse.Description = editedHouse.Description;
                return Ok(currentHouse);
            }  
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}