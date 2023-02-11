using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult UpDate(Customer customer);
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetById(int id);
    }
}
