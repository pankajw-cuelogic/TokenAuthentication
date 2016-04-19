using System;
using System.Runtime.Caching;

namespace Authentication
{
    /// <summary>
    /// To Add/Get Token in memory cache
    /// </summary>
    internal class TokenCacheWrapper
    {
        private static ObjectCache _cache = MemoryCache.Default;

        /// <summary>
        /// Reason : To add token in cache
        /// </summary>
        /// <param name="cacheKey">cacheKey</param>
        /// <param name="token">token</param>
        /// <param name="minutes">minutes</param>
        public void AddToken(string cacheKey, object token, int minutes)
        {
            _cache.Remove(cacheKey);
            if (token != null)
            {
                _cache.Add(cacheKey, token, DateTime.Now.AddMinutes(minutes));
            }
        }

        /// <summary>
        /// Reason : To get token from cache by cache key
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public object GetToken(string cacheKey)
        {
            return _cache.Get(cacheKey);
        }
    }
}
