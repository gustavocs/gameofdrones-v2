using GameOfDrones.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Services
{
    public class ServiceBase<TEntity> : IService<TEntity>, IDisposable where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> _repository;
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public TEntity Add(TEntity obj)
        {
            return _repository.Add(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public TEntity Update(TEntity obj)
        {
            return _repository.Update(obj);
        }
        public TEntity Update(int id, TEntity obj)
        {
            return _repository.Update(id, obj);
        }
    }    
    
}
