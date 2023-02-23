﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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

        [SecuredOperation("car.add,admim")]
        [ValidationAspect(typeof(CarValidator))]
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

        public IDataResult <List<Car>> GetAll()
        {
            var result= _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(result,Messages.CarListed);
        }

        public IDataResult <List<CarDetailDto>> GetCarDetail()
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
