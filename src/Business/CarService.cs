using System.Collections.Generic;
using netCoreWorkshop.Entities;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using netCoreWorkshop.Data;

namespace netCoreWorkshop.Business
{
    public class CarService : ICarService
    {
        private readonly DBContext _context;
        private readonly ILogger<CarService> _logger;

        public CarService(DBContext context, ILogger<CarService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Car GetOneCar(int id)
        {
            var article = _context.Cars.SingleOrDefault(m => m.Id == id);
            return article;
        }
        public List<Car> GetAllCars() => _context.Cars.ToList();
        public Car AddCar(Car car)
        {
            _logger.LogDebug("Starting save");
            var newCar = new Car { Model = car.Model, Brand=car.Brand, Price=car.Price};
            _context.Cars.Add(newCar);
            _context.SaveChanges();
            _logger.LogDebug("Finished save");
            return newCar;
        }

        public Car UpdateCar(Car car)
        {
            Car currentCar = GetOneCar(car.Id);
            if (currentCar != null)
            {
                currentCar.Model = car.Model;
                currentCar.Brand = car.Brand;
                currentCar.Price = car.Price;
            }
            else
                return null;
            _context.SaveChanges();
            return currentCar;
        }

        public void DeleteCar(int id)
        {
            Car car = GetOneCar(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }
    }
}
