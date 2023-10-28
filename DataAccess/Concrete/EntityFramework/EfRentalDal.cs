using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentAcarContext>, IRentalDal
    {
        public List<RentDetailDto> GetRentDetailDtos()
        {
            using (RentAcarContext context = new RentAcarContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars
                             on r.CarId equals car.Id
                             join b in context.Brands
                             on r.CarId equals b.BrandId 
                            
                             join c in context.Customers
                             on r.CustomerId equals c.UserId
                             select new RentDetailDto
                             {
                                 CarId = b.BrandName,
                                 CustomerId = c.FirstName + c.LastName,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate

                             };
                return result.ToList();
            }
        }
    }
}
