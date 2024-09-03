using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetail(int carImageId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult GetByBrandId(int brandId);
        IResult GetByColorId(int id);
    }
}
