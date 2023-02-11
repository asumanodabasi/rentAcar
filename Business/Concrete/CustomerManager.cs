using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;

using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if(_customerDal !=null)
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
            }
            else
            {
                return new ErrorDataResult<List<Customer>>(Messages.CustomerNot);
            }
        }

        public IDataResult<List<Customer>> GetById(int id)
        {
            var result = _customerDal.GetAll(c => c.UserId == id);
            return new SuccessDataResult<List<Customer>>(result,Messages.CustomerByIdListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult UpDate(Customer customer)
        {
            _customerDal.UpDate(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
