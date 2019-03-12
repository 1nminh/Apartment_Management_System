using Library.Data.Context;
using Library.IBLL;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Library.BLL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository()
        {
            this._dbContext = new DatabaseContext();
            this._dbSet = _dbContext.Set<T>();
        }

        public void Create(T entity)
        {
            this._dbContext.Entry<T>(entity).State = EntityState.Added;
            this.Save();
        }

        public void Delete(params object[] keys)
        {
            var result = this._dbSet.Find(keys);
            _dbContext.Entry<T>(result).State = EntityState.Deleted;
            this.Save();
        }

        public T Get(params object[] keys)
        {
            return this._dbSet.Find(keys);
        }

        //public IQueryable<T> Get(Expression<Func<T, bool>>[] predicated, params Expression<Func<T, object>>[] includes)
        public T Get(Expression<Func<T, bool>> predicated, params Expression<Func<T, object>>[] includes)
        {
            return this.GetAll(predicated, includes).FirstOrDefault(predicated);
        }

        public IQueryable<T> GetAll()
        {
            return this._dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicated, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> result = this._dbSet;
            foreach (var item in includes)
            {
                result = result.Include(item);
            }
            result = result.Where(predicated);
            return result;
        }

        public void Update(T entity)
        {
            this._dbContext.Entry<T>(entity).State = EntityState.Modified;
            this.Save();
            
            
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
