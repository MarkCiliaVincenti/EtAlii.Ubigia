﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Infrastructure.Fabric
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEntrySet
    {
        IAsyncEnumerable<Entry> GetRelated(Identifier identifier, EntryRelations entriesWithRelation, EntryRelations entryRelations);
        Task<Entry> Get(Identifier identifier, EntryRelations entryRelations);
        IAsyncEnumerable<Entry> Get(IEnumerable<Identifier> identifiers, EntryRelations entryRelations);

        Entry Store(IEditableEntry entry);
        Entry Store(Entry entry);

        Entry Store(IEditableEntry entry, out IEnumerable<IComponent> storedComponents);
        Entry Store(Entry entry, out IEnumerable<IComponent> storedComponents);

        Task Update(Entry entry, IEnumerable<IComponent> changedComponents);
        Task Update(IEditableEntry entry, IEnumerable<IComponent> changedComponents);

    }
}