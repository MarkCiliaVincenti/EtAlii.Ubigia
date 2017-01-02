﻿namespace EtAlii.Ubigia.Api.Fabric
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRootContext
    {
        Task<Root> Add(string name);
        Task Remove(Guid id);
        Task<Root> Change(Guid rootId, string rootName);
        Task<Root> Get(string rootName);
        Task<Root> Get(Guid rootId);
        Task<IEnumerable<Root>> GetAll();

        event Action<Guid> Added;
        event Action<Guid> Changed;
        event Action<Guid> Removed;
    }
}
