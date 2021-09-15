using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtusREST_Cars.Models
{
   public interface ICarRepository
    {

        List<Car> GetAllCars();

        Car GetCarByGuid(int id);

        void AddCar(Car car);

        void DeleteCar(int id);

        void UpdateCar(Car car);

    }
}
