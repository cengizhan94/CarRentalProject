    using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,RecapContext>,ICarDal 
    {
          public List<CarDetailDto> GetCarDetails()
          {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join r in context.Colors
                             on c.ColorId equals r.ColorId
                             select new CarDetailDto
                             {  
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = r.ColorName,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList();
            }
        }
    }
}
