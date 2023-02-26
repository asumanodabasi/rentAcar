﻿using Core.Entities.Concrete;
using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService
    {
        User GetByMail(string mail);
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
    }
}
