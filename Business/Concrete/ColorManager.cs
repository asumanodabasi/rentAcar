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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetCarsByColorId(int colorId)
        {
            var result = _colorDal.GetAll(c => c.ColorId == colorId);
            return new SuccessDataResult<List<Color>>(result, Messages.GetCarColor);
        }
    }
}
