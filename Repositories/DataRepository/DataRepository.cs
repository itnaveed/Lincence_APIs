using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels;

namespace Repositories.DataRepository
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class
    {
        readonly Licence_APIsContext _context;
        internal DbSet<TEntity> dbSet;
        public DataRepository(Licence_APIsContext context)
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public TEntity Get(Guid id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }
       
        public IEnumerable<AllowedServicesVM> RawQuery(string entity)
        {
            return _context.ExecuteQuery<AllowedServicesVM>(entity).ToList();
           // return dbSet.FromSqlRaw<TEntity>(entity).ToList();
        }
        public IEnumerable<UserServicesVM> userServices(string entity)
        {
            return _context.ExecuteQuery<UserServicesVM>(entity).ToList();
            // return dbSet.FromSqlRaw<TEntity>(entity).ToList();
        }
        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> customQuery(string entity)
        {
            return dbSet.FromSqlRaw<TEntity>(entity).ToList();
        }
    }
}
