using GameOfDrones.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Data
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class, IModel
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


        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public TEntity GetById<TProperty>(int id, params Func<TEntity, TProperty>[] properties)
        {
            var dbSet = Db.Set<TEntity>();
            properties.ToList()
                .ForEach(func =>
                  {
                      dbSet.Include(f => func);
                  }      
                );

            return dbSet.SingleOrDefault(t => t.Id == id);
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
