using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
   public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)    
        {
            //Kullanıcı isterse başarılı olan işleme mesaj da gönderebilir.
        }
        public ErrorResult() : base(false)     
        {
            //Kullanıcı isterse başarılı olan işleme mesaj göndermeden de devam edebilir.
        }
    }
}
