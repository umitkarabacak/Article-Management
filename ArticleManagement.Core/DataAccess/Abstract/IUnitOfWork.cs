using System;
using System.Threading.Tasks;
using ArticleManagement.Domain;

namespace ArticleManagement.Core.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        Task<int> CommitAsync();

        IRepository<T> Repository<T>() where T : BaseEntity;
    }
}