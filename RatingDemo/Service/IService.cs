using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IService<TEntity> where TEntity: class
    {
        TEntity Find(params object[] keyValues);
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<bool> DeleteAsync(params object[] keyValues);
        IQueryable<TEntity> Queryable();
    }
    
}
