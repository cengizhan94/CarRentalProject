using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers.GuidHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserVerifyManager : IUserVerifyService
    {
        private IUserVerifyDal _userVerifyDal;
        private IUserService _userService;

        public UserVerifyManager(IUserVerifyDal userVerifyDal, IUserService userService)
        {
            _userVerifyDal = userVerifyDal;
            _userService = userService;
        }

        public IDataResult<UserVerify> Add(string mail)
        {
            var user = _userService.GetByMail(mail);
            UserVerify userVerify = new UserVerify
            {
                EmailVerifyStatus = false,
                EmailVerifyToken = GuidHelper.CreateGuid().ToString(),
                UserId = user.UserId,
            };

            _userVerifyDal.Add(userVerify);
            return new SuccessDataResult<UserVerify>(userVerify,Messages.SendingVerifyMail);
        }

        public IResult Delete(UserVerify userVerify)
        {
            _userVerifyDal.Delete(userVerify);
            return new SuccessResult();
        }

        public IResult Update(UserVerify userVerify)
        {
            _userVerifyDal.Update(userVerify);
            return new SuccessResult();
        }

        public IDataResult<List<UserVerify>> GetAll()
        {
            return new SuccessDataResult<List<UserVerify>>(_userVerifyDal.GetAll());
        }

        public IDataResult<UserVerify> GetByUserId(int userId)
        {
            return new SuccessDataResult<UserVerify>(_userVerifyDal.Get(u => u.UserId == userId));
        }

        public UserVerify GetByVerifyToken(string verifyToken)
        {
            return _userVerifyDal.Get(u => u.EmailVerifyToken == verifyToken);
        }

        public IDataResult<UserVerify> GetById(int id)
        {
            return new SuccessDataResult<UserVerify>(_userVerifyDal.Get(u => u.Id == id));
        }

        public IResult Verify(string verifyToken)
        {
            var userVerify = GetByVerifyToken(verifyToken);
            if (userVerify != null)
            {
                userVerify.EmailVerifyStatus = true;
                _userVerifyDal.Update(userVerify);
                return new SuccessResult();
            }

            return new ErrorResult();
        }
    }
}
