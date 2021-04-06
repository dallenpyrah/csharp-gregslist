using System.Collections.Generic;
using gregslist.db;
using gregslist.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(Fakedb.Cars);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                Fakedb.Cars.Add(newCar);
                return Ok(newCar);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCarById(string id)
        {
            try
            {
                Car carFound = Fakedb.Cars.Find(c => c.Id == id);
                return Ok(carFound);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Car> DeleteCar(string id)
        {
            try
            {
                Car carToDelete = Fakedb.Cars.Find(c => c.Id == id);
                Fakedb.Cars.Remove(carToDelete);
                if (carToDelete == null)
                {
                    throw new System.Exception("This car does not exist");
                }
                else
                {
                    return Ok("Car deleted");
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Car> EditCar(string id, Car car)
        {
            try
            {
                Car carEdited = Fakedb.Cars.Find(c => c.Id == id);
                carEdited.Make = car.Make;
                carEdited.Model = car.Model;
                carEdited.Miles = car.Miles;
                carEdited.Year = car.Year;
                return Ok(carEdited);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


    }
}