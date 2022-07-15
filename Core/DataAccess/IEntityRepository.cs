using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities.Abstract;

namespace Core.DataAccess.EntityFramework
{
    public interface IEntityRepository<T> where T : class, IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
       public void Add(T entity);
       public void Delete(T entity);
       public void Update(T entity);
    }
}
