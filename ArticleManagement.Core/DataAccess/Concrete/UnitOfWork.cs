using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleManagement.Core.DataAccess.Abstract;
using ArticleManagement.Data.Databases;
using ArticleManagement.Domain;

namespace ArticleManagement.Core.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _dispose;
        private readonly ProjectContext _projectContext;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public void Dispose() => Dispose(true);

        public int Commit() => _projectContext.SaveChanges();

        public Task<int> CommitAsync() => _projectContext.SaveChangesAsync();

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories.Keys.Contains(typeof(T)))
                return _repositories[typeof(T)] as IRepository<T>;

            IRepository<T> repository = new EfRepository<T>(_projectContext);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        private void Dispose(bool disposing)
        {
            if (!_dispose)
            {
                if (disposing)
                    _projectContext.Dispose();
            }
            _dispose = true;
            GC.SuppressFinalize(this);
        }
    }
}