using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                    new Car {Id=1,ColorId=1, BrandId=1, DailyPrice=1500, Description="powerful engine", ModelYear=2010 },
                    new Car {Id=2,ColorId=1, BrandId=7, DailyPrice=2500, Description="powerful brake", ModelYear=2015 } ,
                    new Car {Id=3,ColorId=2, BrandId=5, DailyPrice=4500, Description="fuel saving and strong traction", ModelYear=2020 },
                    new Car {Id=4,ColorId=3, BrandId=1, DailyPrice=2500, Description="powerful engine", ModelYear=2015 },
                    new Car {Id=5,ColorId=5, BrandId=6, DailyPrice=1000, Description="eye-catching color", ModelYear=2009 },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //LINQ
            Car carToDelete = _cars.SingleOrDefault(c => c.ModelYear < 2010);
            _cars.Remove(carToDelete);

        }

        public void UpDate(Car car)
        {
            Car carUpDate = _cars.SingleOrDefault(c => c.ModelYear < 2010);
            carUpDate.ModelYear = car.ModelYear;
            carUpDate.Description = car.Description;
            carUpDate.DailyPrice = car.DailyPrice;
            carUpDate.BrandId = car.BrandId;
            carUpDate.ColorId = car.ColorId;

        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int ID)
        {
            return _cars.Where(c => c.Id == ID).ToList();
        }

        public List<Car> Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetAll(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        List<Car> IEntityRepository<Car>.GetAll(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        Car IEntityRepository<Car>.GetById(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
