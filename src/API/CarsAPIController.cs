using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using netCoreWorkshop.Entities;

namespace netCoreWorkshop.API
{
    [Route("/api/cars")]
    [ApiController]
    public class CarsApiController : ControllerBase
    {

        private readonly ICarService carsService;
        public CarsApiController(ICarService carsService)
        {
            this.carsService = carsService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article = carsService.GetOneCar(id);
            
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpGet]
        public IActionResult Get() => Ok(carsService.GetAllCars());

        [HttpPost]
        public IActionResult Create([FromBody]Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCar = new Car { Model = car.Model, Brand= car.Brand, Price=car.Price};

            newCar = carsService.AddCar(newCar);

            return CreatedAtAction(nameof(Create), new { id = newCar.Id }, newCar);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentCar = carsService.GetOneCar(id);

            if (currentCar == null)
            {
                return NotFound();
            }

            currentCar.Model = car.Model;
            currentCar.Brand = car.Brand;
            currentCar.Price = car.Price;
            currentCar = carsService.UpdateCar(currentCar);
            return Ok(currentCar);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var currentCar = carsService.GetOneCar(id);

            if (currentCar == null)
            {
                return NotFound();
            }

            carsService.DeleteCar(id);
            return NoContent();
        }
    }
}