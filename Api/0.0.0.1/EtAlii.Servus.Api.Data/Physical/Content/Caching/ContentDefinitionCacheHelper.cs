﻿namespace EtAlii.Servus.Api.Data
{
    using EtAlii.Servus.Api;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class ContentDefinitionCacheHelper
    {
        private readonly ContentCacheProvider _cacheProvider;

        public ContentDefinitionCacheHelper(ContentCacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        public IReadOnlyContentDefinition Get(Identifier identifier)
        {
            ContentCacheEntry cacheEntry = null;
            _cacheProvider.Cache.TryGetValue(identifier, out cacheEntry);
            return cacheEntry != null ? cacheEntry.ContentDefinition : null;
        }

        public void Store(Identifier identifier, IReadOnlyContentDefinition definition)
        {
            ContentCacheEntry cacheEntry = null;
            if (!_cacheProvider.Cache.TryGetValue(identifier, out cacheEntry))
            {
                cacheEntry = new ContentCacheEntry();
                _cacheProvider.Cache[identifier] = cacheEntry;
            }
            cacheEntry.ContentDefinition = definition;
        }
    }
}
