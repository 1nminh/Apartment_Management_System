using System;
using System.Linq;
using System.Linq.Expressions;

namespace Library.IBLL
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        //IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicated, params Expression<Func<T, object>>[] includes);

        T Get(params object[] keys);
        //T Get(object keys);
        T Get(Expression<Func<T, bool>> predicated, params Expression<Func<T, object>>[] includes);
        //T Get(Expression<Func<T, bool>>[] predicated, params Expression<Func<T, object>>[] includes);

        void Create(T entity);

        void Update(T entity);

        void Delete(params object[] keys);

        void Save();
    }
}
