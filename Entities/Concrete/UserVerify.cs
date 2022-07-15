    using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserVerify : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EmailVerifyToken { get; set; }
        public bool EmailVerifyStatus { get; set; }
    }
}
