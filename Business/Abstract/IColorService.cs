using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IColorService
    {
        IDataResult<List<Color>>GetCarsByColorId(int colorId);
        IDataResult<List<Color>> GetAll();
    }
}
