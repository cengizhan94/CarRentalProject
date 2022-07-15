using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
    //Data her şey olabilir.
    public interface IDataResult<T> : IResult 
    {
          T Data { get; }
    }
}
