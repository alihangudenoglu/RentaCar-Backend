using Core.Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService:IEntityRepositoryService<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
