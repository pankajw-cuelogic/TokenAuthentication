using System;
using System.Runtime.Caching;

namespace Authentication
{
    /// <summary>
    /// To Add/Get Token in memory cache
    /// </summary>
    internal class TokenCacheWrapper
    {
        private static ObjectCache cache = MemoryCache.Default;
        
        /// <summary>
        /// Reason : To add token in cache
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="token"></param>
        /// <param name="minutes"></param>
        public void AddToken(string cacheKey, object token, int minutes)
        {
            cache.Remove(cacheKey);
            if (token != null)
            {
                cache.Add(cacheKey, token, DateTime.Now.AddMinutes(minutes));
            }
        }

        /// <summary>
        /// Reason : To get token from cache by cache key
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public object GetToken(string cacheKey)
        {
            return cache.Get(cacheKey);
        }
    }
}
