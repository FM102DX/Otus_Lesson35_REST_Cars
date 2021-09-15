using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OtusREST_Cars.Models
{
    public class CarRepository: ICarRepository
    {

        public static ICarRepository GetCarRepositoryFilled()
        {
            return new CarRepository(true);
        }

        public static ICarRepository GetCarRepositoryEmpty()
        {
            return new CarRepository(false);
        } 

        private CarRepository(bool fillMe)
        {
            if (fillMe) FillRepository();
        }
        public List<Car> Items = new List<Car>();

        public List<Car> GetAllCars()
        {
            return Items;
        }

        public Car GetCarByGuid (int id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }

        public void  AddCar (Car car)
        {
            Debug.WriteLine($"Items has {Items.Count} cars");
            Debug.WriteLine($"Adding a car {car}");
            Items.Add(car);
            Debug.WriteLine($"Items has {Items.Count} cars");
        }

        public void DeleteCar(int id)
        {
            Items.RemoveAll(x => x.Id == id);
        }

        public void UpdateCar(Car car)
        {
            Car x = GetCarByGuid(car.Id);

            if (x == null) return;

            int i = Items.IndexOf(x);

            if (!(i >= 0)) return;
 
            Items[i] = car;
        }

        public void FillRepository()
        {
            Items.Add(new Car
            {

                 Id = 1,
                 CarColor = "Green",
                 Mark="Chevrolette",
                  YearOfProdiction=1985
            }) ;

            Items.Add(new Car
            {

                Id = 2,
                CarColor = "Black",
                Mark = "BMW",
                YearOfProdiction = 2005
            });
            Items.Add(new Car
            {

                Id = 3,
                CarColor = "White",
                Mark = "Volga",
                YearOfProdiction = 1975
            });
            Items.Add(new Car
            {
                Id = 4,
                CarColor = "Yellow",
                Mark = "Submarine",
                YearOfProdiction = 2000
            });

        }



        

    }
}
