using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        bool Success { get; }     //işlem başarılı mı? true or false
        string Message { get; }  // işlemin durumu için bilgi mesajı ver.
    }
}
