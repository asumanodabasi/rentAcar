using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {


            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetail();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else { Console.WriteLine(result.Message); }

         //   add();

        }

        private static void add()
        {
            CarManager carManager2 = new CarManager(new EfCarDal());
            List<Car> cars = new List<Car>
                {
                new Car{Id=4,CarName="Neww",Description="Yeni",ColorId=1,BrandId=5,DailyPrice=1000,ModelYear=2010}
                };
            carManager2.Add(cars[1]);
        }
    }
}
