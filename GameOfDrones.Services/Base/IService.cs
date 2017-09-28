using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Services
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Remove(TEntity obj);
        TEntity Update(TEntity obj);
        TEntity Update(int id, TEntity obj);

    }
}
