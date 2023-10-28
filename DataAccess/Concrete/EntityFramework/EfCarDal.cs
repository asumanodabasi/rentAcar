using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentAcarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentAcarContext context=new RentAcarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.Id equals b.BrandId
                             join cl in context.Colors
                            on c.ColorId equals cl.ColorId

                             select new CarDetailDto {
                                 CarName = c.CarName, 
                                 BrandId = b.BrandName,
                                 ColorId=cl.ColorName, 
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear=c.ModelYear
                             };
                return result.ToList();
                  
                           }
            
        }
    }
}
