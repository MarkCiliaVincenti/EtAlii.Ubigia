﻿namespace EtAlii.Ubigia.Infrastructure.Fabric
{
    using System;
    using System.Collections.Generic;
    using EtAlii.Ubigia.Api;

    public interface IItemRemover
    {
        void Remove<T>(IList<T> items, Guid itemId)
            where T : class, IIdentifiable;

        void Remove<T>(IList<T> items, T itemToRemove)
            where T : class, IIdentifiable;
    }
}