﻿using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface ICarImageService
    {
        IResult Add(IFormFile formFile,CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult UpDate(IFormFile formFile,CarImage carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<CarImage> GetByCarImageId(int imageId);

    }
}
