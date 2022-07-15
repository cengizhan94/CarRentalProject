using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using DataAccess.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Vlidation;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserVerifyValidator))]
        public void Add(User user)
        {
                _userDal.Add(user);
        }
        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public List<User> GetAll()
        {
            return new List<User>(_userDal.GetAll());
        }

        public User GetById(int userId)
        {
          
            return _userDal.Get(p => p.UserId == userId);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Update(User user)
        {
            _userDal.Update(user);

        }
    }
}
