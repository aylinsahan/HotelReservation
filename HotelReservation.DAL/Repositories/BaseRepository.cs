using HotelReservation.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace HotelReservation.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext DbContext;
        public DbSet<TEntity> DbSet { get; }
      
        public BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            DbSet.Remove(entity);
            SaveChanges();
        }
    

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return DbContext.Set<TEntity>().Where(filter);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            SaveChanges();
        }
        public void DeleteAll()
        {
            DbSet.RemoveRange(DbSet);
            SaveChanges();
        }
    }
}
