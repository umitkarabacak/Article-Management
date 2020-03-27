using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArticleManagement.Core.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null);

        Task<T> First(Expression<Func<T, bool>> predicate);

        Task<T> Find(int id);

        Task<T> Add(T t);

        void Update(T t);

        Task Remove(int id);

        IEnumerable<T> Include(string includeProperties = "", Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    }
}