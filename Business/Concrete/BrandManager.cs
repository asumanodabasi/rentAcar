using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public  class BrandManager:IBrandService
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result=_brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(result);
        }

        IDataResult<List<Brand>> IBrandService.GetCarsByBrandId(int brandId)
        {
            var result = _brandDal.GetAll(b => b.BrandId == brandId);
            return new SuccessDataResult<List<Brand>>(result, Messages.GetCarByBrandId);
        }
    }

}
