using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserVerifyService
    {
        IDataResult<UserVerify> Add(string mail);
        IResult Delete(UserVerify userVerify);
        IResult Update(UserVerify userVerify);
        IDataResult<List<UserVerify>> GetAll();
        IDataResult<UserVerify> GetByUserId(int userId);
        UserVerify GetByVerifyToken(string verifyToken);
        IDataResult<UserVerify> GetById(int id);
        IResult Verify(string verifyToken);
    }
}
