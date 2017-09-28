using System;
using System.Collections.Generic;

namespace GameOfDrones.Data
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        TEntity GetById<TProperty>(int id, params Func<TEntity, TProperty>[] properties);
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity obj);
        TEntity Update(TEntity obj);
        TEntity Update(int id, TEntity obj);
        void Remove(TEntity obj);
        void Dispose();

    }
}