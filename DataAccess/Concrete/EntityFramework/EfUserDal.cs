using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentAcarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context=new RentAcarContext())
            {
                var result = from o in context.OperationClaims
                             join u in context.UserOperationClaims
                             on o.Id equals u.OperationClaimId
                             where u.UserId == user.Id
                             select new OperationClaim { Id = o.Id, Name = o.Name };
                return result.ToList();           
            }
        }
    }
}
