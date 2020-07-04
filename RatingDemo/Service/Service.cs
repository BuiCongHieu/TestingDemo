using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepositoryAsync<TEntity> _repository;
        protected Service(IRepositoryAsync<TEntity> repository)
        {
            _repository = repository;
        }
        public virtual void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            return _repository.Find(keyValues);
        }

        public virtual Task<TEntity> FindAsync(params object[] keyValues)
        {
            return _repository.FindAsync(keyValues);
        }

        public virtual void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            _repository.InsertRange(entities);
        }

        public virtual IQueryable<TEntity> Queryable()
        {
            return _repository.Queryable();
        }

        public IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {
            return _repository.SelectQuery(query, parameters);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
