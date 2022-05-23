﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Infrastructure.Transport
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Transport;
    using EtAlii.Ubigia.Infrastructure.Functional;

    internal class SystemEntryDataClient : SystemSpaceClientBase, IEntryDataClient
    {
        private readonly IInfrastructure _infrastructure;

        public SystemEntryDataClient(IInfrastructure infrastructure)
        {
            _infrastructure = infrastructure;
        }

        /// <inheritdoc />
        public async Task<IEditableEntry> Prepare()
        {
            var result = await _infrastructure.Entries
                .Prepare(Connection.Space.Id)
                .ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<IReadOnlyEntry> Change(IEditableEntry entry, ExecutionScope scope)
        {
            var result = await _infrastructure.Entries.Store(entry).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<IReadOnlyEntry> Get(Root root, ExecutionScope scope, EntryRelations entryRelations = EntryRelations.None)
        {
            var result = await _infrastructure.Entries
                .Get(root.Identifier)
                .ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<IReadOnlyEntry> Get(Identifier entryIdentifier, ExecutionScope scope, EntryRelations entryRelations = EntryRelations.None)
        {
            var result = await _infrastructure.Entries
                .Get(entryIdentifier, entryRelations)
                .ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public IAsyncEnumerable<IReadOnlyEntry> Get(IEnumerable<Identifier> entryIdentifiers, ExecutionScope scope, EntryRelations entryRelations = EntryRelations.None)
        {
            return _infrastructure.Entries.Get(entryIdentifiers, entryRelations);
        }

        /// <inheritdoc />
        public IAsyncEnumerable<IReadOnlyEntry> GetRelated(Identifier entryIdentifier, EntryRelations entriesWithRelation, ExecutionScope scope, EntryRelations entryRelations = EntryRelations.None)
        {
            return _infrastructure.Entries.GetRelated(entryIdentifier, entriesWithRelation, entryRelations);
        }
    }
}
