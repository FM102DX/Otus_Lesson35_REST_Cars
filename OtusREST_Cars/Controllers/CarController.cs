using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OtusREST_Cars.Models;

namespace OtusREST_Cars.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {

        ICarRepository _repo;

        public CarController(ICarRepository repo)
        {
            _repo = repo;
        }


        //https://localhost:44329/car
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _repo.GetAllCars();
        }


        //https://localhost:44329/car/1
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            Car car = _repo.GetCarByGuid(id);
            return car;
        }

        // POST <Controller>
        [HttpPost]
        //public Task<ActionResult<Car>> Post([FromBody] Car car)
        public ActionResult Post([FromBody] Car car)
        {
            _repo.AddCar(car);
            return CreatedAtAction(nameof(Post), new { id = car.Id });
        }

        // PUT <Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car car)
        {
            _repo.UpdateCar(car);
        }

        // DELETE <Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteCar(id);
        }
    }
}
