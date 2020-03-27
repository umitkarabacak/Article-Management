using System;
using System.Text;
using System.Threading.Tasks;
using ArticleManagement.Business.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ArticleManagement.Business.Concrete
{
    public class CacheProvider : ICacheProvider
    {
        private readonly IDistributedCache _distributedCache;
        private byte[] _arr;
        private string _text;

        public CacheProvider(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T> Set<T>(string key, T value)
        {
            _text = JsonConvert.SerializeObject(value);
            _arr = Encoding.UTF8.GetBytes(_text);
            await _distributedCache.SetAsync(key, _arr);

            return await Get<T>(key);
        }

        public async Task<T> Set<T>(string key, T value, TimeSpan timeout)
        {
            _text = JsonConvert.SerializeObject(value);
            _arr = Encoding.UTF8.GetBytes(_text);
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(timeout);
            await _distributedCache.SetAsync(key, _arr, options);

            return await Get<T>(key);
        }

        public async Task<T> Get<T>(string key)
        {
            _arr = await _distributedCache.GetAsync(key);
            _text = Encoding.UTF8.GetString(_arr);

            return JsonConvert.DeserializeObject<T>(_text);
        }

        public async Task Delete(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }

        public async Task<bool> IsInCache(string key)
        {
            return await _distributedCache.GetAsync(key) != null;
        }
    }
}
