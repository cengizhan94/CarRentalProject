using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Core.DataAccess.EntityFramework;
using Color = Entities.Concrete.Color;

namespace DataAccess.Abstract
{
    public interface IColorDal : IEntityRepository<Color> {}
}
