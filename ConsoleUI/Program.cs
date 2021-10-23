using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarGetAll();
            //CarAdd();
            //CarUpdate();
            //CarGetById();
            //BrandGetAll();
            //CarDetailsGetAll();
            //CarRental();
            //AddUser();

        }

        private static void AddUser()
        {
            //User user = new User { FirstName = "ege", LastName = "demir", Email = "ege@gmail.com", Password = "12345" };
            //UserManager userManager = new UserManager(new EfUserDal());
            //Console.WriteLine(userManager.Add(user).Message);
        }

        private static void CarRental()
        {
            Rental rental = new Rental { CarId = 22, CustomerId = 2,RentDate=DateTime.Now};
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.Add(rental).Message);
        }

        private static void CarDetailsGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(
                    "carId:" + car.CarId +
                    "carname:" + car.CarName +
                    "Brandname:" + car.BrandName +
                    "Colorname:" + car.ColorName +
                    "DailyPrice:" + car.DailyPrice



                    );
            }
        }

        private static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Id + "-" + brand.Name);
            }
        }

        private static void CarGetById()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car();
            car = carManager.GetById(3).Data;

            Console.WriteLine(
               "Id:" + car.Id +
               "BrandId:" + car.BrandId +
               "ColorId:" + car.ColorId +
               "ModelYear:" + car.ModelYear +
               "DailyPrice:" + car.DailyPrice +
               "Description:" + car.Description);
        }

        private static void CarUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car
            {
                Id = 3,
                BrandId = 2,
                ColorId = 2,
                DailyPrice = 2,
                ModelYear = 2,
                Description = "yeni deneme2"

            };
            carManager.Update(car);
            CarGetAll();
        }

        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car
            {
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 100,
                ModelYear = 2000,
                Description = "yeni deneme"
            };
            carManager.Add(car);
            CarGetAll();
        }

        private static void CarGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(
                    "Id:"+car.Id+
                    "BrandId:"+car.BrandId+
                    "ColorId:"+car.ColorId+
                    "ModelYear:"+ car.ModelYear+
                    "DailyPrice:"+ car.DailyPrice+
                    "Description:"+ car.Description


                    );
            }
        }
    }
}
