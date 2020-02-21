using System.Collections.Generic;
using netCoreWorkshop.Entities;

public interface ICarService
{
    Car GetOneCar(int id);
    List<Car> GetAllCars();
    Car AddCar(Car Car);
    Car UpdateCar(Car Car);
    void DeleteCar(int id);
}