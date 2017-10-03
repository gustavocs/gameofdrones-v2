using GameOfDrones.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Data
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected IDbContext Db;
        public RepositoryBase(IDbContext _db)
        {
            this.Db = _db;
        }
        public TEntity Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();

            return obj;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Db != null)
                {
                    this.Db.Dispose();
                    this.Db = null;
                }
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Db.Set<TEntity>().AsQueryable();

            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty))
                    .ToList();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Db.Set<TEntity>().Where(where);

            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty))
                    .ToList(); 
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public TEntity Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();

            return obj;
        }
        public TEntity Update(int id, TEntity obj)
        {
            var exists = Db.Set<TEntity>().Find(id);
            if (exists != null)
            {
                Db.Entry(obj).State = EntityState.Modified;
            }
            else
            {
                Add(obj);
            }
            Db.SaveChanges();

            return obj;
        }

    }
}
