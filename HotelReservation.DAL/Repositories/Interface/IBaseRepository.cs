using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelReservation.DAL.Repositories.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        void SaveChanges();
        void DeleteAll();
    }
}
