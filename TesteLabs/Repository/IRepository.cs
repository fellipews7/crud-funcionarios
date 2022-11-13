using System;
using System.Linq;
using System.Linq.Expressions;
namespace TesteLabs.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        Task<T> GetById(Expression<Func<T, bool>> predicate);
        void Add (T entity);
        void Update (T entity);
        void Delete (T entity);

    }
}
