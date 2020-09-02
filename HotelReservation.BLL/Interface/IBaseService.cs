using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelReservation.BLL.Interface
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        TEntity Add(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        void SaveChange();

    }
}
