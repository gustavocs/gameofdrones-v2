﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GameOfDrones.Data
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        TEntity Add(TEntity obj);
        TEntity Update(TEntity obj);
        TEntity Update(int id, TEntity obj);
        void Remove(TEntity obj);
        void Dispose();

    }
}