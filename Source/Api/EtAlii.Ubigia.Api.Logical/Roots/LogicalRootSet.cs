// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Logical
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Fabric;

    /// <summary>
    /// Facade that hides away complex logical Root operations.
    /// </summary>
    public class LogicalRootSet : ILogicalRootSet
    {
        private readonly IFabricContext _fabric;

        public LogicalRootSet(IFabricContext fabric)
        {
            _fabric = fabric;
        }

        public async Task<Root> Add(string name, RootType rootType)
        {
            return await _fabric.Roots
                .Add(name, rootType)
                .ConfigureAwait(false);
        }

        public async Task Remove(Guid id)
        {
            await _fabric.Roots.Remove(id).ConfigureAwait(false);
        }

        public async Task<Root> Change(Guid rootId, string rootName)
        {
            return await _fabric.Roots.Change(rootId, rootName).ConfigureAwait(false);
        }

        public async Task<Root> Get(string rootName)
        {
            return await _fabric.Roots.Get(rootName).ConfigureAwait(false);
        }

        public async Task<Root> Get(Guid rootId)
        {
            return await _fabric.Roots.Get(rootId).ConfigureAwait(false);
        }

        public IAsyncEnumerable<Root> GetAll()
        {
            return _fabric.Roots.GetAll();
        }
    }
}
