using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;

namespace Model
{
   public class Repository<Tentity>:
        IRepository<Tentity>,
        IRepositoryAsync<Tentity> where Tentity : class
    {
        protected dbContext _db;
        private DbSet<Tentity> _dbSet;
        public Repository(dbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Tentity>();
        }
      
        public virtual void Delete(object entity)
        {
            var data = _dbSet.Find(entity);
            Delete(data);
        }

        public virtual async Task<bool> DeleteAsync(params object[] keyValues)
        {
            return await DeleteAsync(CancellationToken.None, keyValues);
        }

        public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var entity = await FindAsync(cancellationToken, keyValues);
            if (entity == null) return false;
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
            return true;
        }

        public virtual Tentity Find(object Id)
        {
            return _dbSet.Find(Id);
        }

        public virtual Tentity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public virtual async Task<Tentity> FindAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        public virtual async Task<Tentity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return await _dbSet.FindAsync(cancellationToken, keyValues);
        }

        public virtual void Insert(Tentity entity)
        {
            _dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void InsertRange(IEnumerable<Tentity> entities)
        {
            foreach (var entity in entities)
                Insert(entity);
        }

        public IQueryable<Tentity> Queryable() => _dbSet;
      

        public IQueryable<Tentity> SelectQuery(string query, params object[] keyValues)
        {
            return _dbSet.SqlQuery(query, keyValues).AsQueryable();
        }

        public void Update(Tentity entity)
        {
             _dbSet.Attach(entity);
        }
    }
}
