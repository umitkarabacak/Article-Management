using System;
using System.Threading.Tasks;

namespace ArticleManagement.Business.Abstract
{
    public interface ICacheProvider
    {
        Task<T> Set<T>(string key, T value);

        Task<T> Set<T>(string key, T value, TimeSpan timeout);

        Task<T> Get<T>(string key);

        Task<bool> IsInCache(string key);

        Task Delete(string key);
    }
}