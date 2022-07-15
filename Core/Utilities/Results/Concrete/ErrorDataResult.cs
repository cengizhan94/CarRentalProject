using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
            //Hem datayı hem mesajı hem de true yada false olan sonucu döndürür
        }
        public ErrorDataResult(T data, bool success) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        public ErrorDataResult() : base(default, true)
        {

        }
    }
}
