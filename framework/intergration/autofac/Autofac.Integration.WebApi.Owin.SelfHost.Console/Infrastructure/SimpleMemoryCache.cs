using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace Autofac.Integration.WebApi.Owin.SelfHost.Console.Infrastructure
{
    public class SimpleMemoryCache<TItem> where TItem : class
    {
        private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public TItem GetOrCreate(object key, Func<TItem> createItem)
        {
            if (!_cache.TryGetValue(key, out TItem cacheEntry))
            {
                cacheEntry = createItem();

                _cache.Set(key, cacheEntry);
            }

            return cacheEntry;
        }
    }
}
