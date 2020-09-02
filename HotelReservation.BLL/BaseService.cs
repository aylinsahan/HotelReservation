using HotelReservation.BLL.Interface;
using HotelReservation.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HotelReservation.BLL
{
    public abstract class BaseService<TRepository, TEntity> : IBaseService<TEntity>
        where TRepository : IBaseRepository<TEntity>
        where TEntity : class
    {
        protected readonly TRepository Repository;
        public BaseService(TRepository repository)
        {
            Repository = repository;
        }

        public TEntity Add(TEntity entity)
        {
            Repository.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }

        public TEntity GetById(int id)
        {
            return Repository.GetById(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return Repository.Get(filter);
        }

        public void SaveChange()
        {
            Repository.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
           Repository.Delete(entity);
        }
    }
}
