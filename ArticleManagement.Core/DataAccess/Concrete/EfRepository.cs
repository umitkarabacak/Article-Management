using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ArticleManagement.Core.DataAccess.Abstract;
using ArticleManagement.Data.Databases;
using ArticleManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagement.Core.DataAccess.Concrete
{
    public class EfRepository<TEntity> : IRepository<TEntity>
       where TEntity : BaseEntity
    {
        private readonly ProjectContext _projectContext;

        public EfRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? _projectContext.Set<TEntity>()
                : _projectContext.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> First(Expression<Func<TEntity, bool>> predicate)
        {
            return await _projectContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> Find(int id)
        {
            return await _projectContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Add(TEntity t)
        {
            return await _projectContext.Set<TEntity>().AddAsync(t) as TEntity;
        }

        public void Update(TEntity t)
        {
            _projectContext.Set<TEntity>().Attach(t);
            _projectContext.Entry(t).State = EntityState.Modified;
        }

        public async Task Remove(int id)
        {
            var t = await _projectContext.Set<TEntity>().FindAsync(id);

            if (t == null)
                throw new Exception("Custom Exception"); //Todo add NLog

            _projectContext.Set<TEntity>().Remove(t);
        }

        public IEnumerable<TEntity> Include(string includeProperties = "", Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _projectContext.Set<TEntity>();

            if (filter != null)
                query = query.Where(filter);

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Aggregate(query, (current, includeProperty)
                                                        => current.Include(includeProperty));

            return orderBy?.Invoke(query) ?? query;
        }
    }
}