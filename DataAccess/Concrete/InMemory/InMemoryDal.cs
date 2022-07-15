using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
   public class InMemoryDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryDal()
        {
            _cars = new List<Car> { 
                
            //    new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=15000,Description="BMW",ModelYear=new DateTime(2020,1,1)},
            //    new Car{CarId=2,BrandId=2,ColorId=1,DailyPrice=14000,Description="Mercedes",ModelYear=new DateTime(2019,1,1)},
            //    new Car{CarId=3,BrandId=3,ColorId=2,DailyPrice=13000,Description="Ford",ModelYear=new DateTime(2018,1,1)},
            //    new Car{CarId=4,BrandId=4,ColorId=2,DailyPrice=12000,Description="MAN",ModelYear=new DateTime(2017,1,1)},

              };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RecapContext context = new RecapContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public List<Car> GetAllByCategoryId(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            
        }
    }
}
