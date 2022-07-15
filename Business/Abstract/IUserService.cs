using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;


namespace Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int userId);
        void Add(User user);
        void Delete(User user);
        void Update(User user);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
