using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public  class CarManager :ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)  //We made consturactor injection..!! ATTENTION
        {
            _carDal= carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

       //[CacheAspect]
        public IDataResult <List<Car>> GetAll()
        {
            var result= _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(result,Messages.CarListed);
        }

        public IResult GetByBrandId(int brandId)
        {
            var result = _carDal.GetAll(x=>x.BrandId==brandId);
            return new SuccessDataResult<List<Car>>(result,Messages.CarListed);
        }

        public IResult GetByColorId(int id)
        {

            var result = _carDal.GetAll(x=>x.ColorId==id);
            return new SuccessDataResult<List<Car>>(result,Messages.CarListed);
        }

        // [PerformanceAspect(4)]
        public IDataResult <List<CarDetailDto>> GetCarDetail(int carImageId)
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.UpDate(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
