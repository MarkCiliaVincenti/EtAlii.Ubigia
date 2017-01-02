﻿namespace EtAlii.Ubigia.Api.Fabric
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Transport;

    internal class EntryContext : IEntryContext
    {
        private readonly IDataConnection _connection;

        internal EntryContext(IDataConnection connection)
        {
            _connection = connection;
            _connection.Entries.Notifications.Prepared += OnPrepared;
            _connection.Entries.Notifications.Stored += OnStored;
        }

        public async Task<IEditableEntry> Prepare()
        {
            return await _connection.Entries.Data.Prepare();
        }

        public async Task<IReadOnlyEntry> Change(IEditableEntry entry, ExecutionScope scope)
        {
            return await _connection.Entries.Data.Change(entry, scope);
        }

        public async Task<IReadOnlyEntry> Get(Root root, ExecutionScope scope)
        {
            return await _connection.Entries.Data.Get(root, scope, EntryRelation.All);
        }

        public async Task<IReadOnlyEntry> Get(Identifier identifier, ExecutionScope scope)
        {
            return await _connection.Entries.Data.Get(identifier, scope, EntryRelation.All);
        }

        public async Task<IEnumerable<IReadOnlyEntry>> Get(IEnumerable<Identifier> identifiers, ExecutionScope scope)
        {
            return await _connection.Entries.Data.Get(identifiers, scope, EntryRelation.All);
        }

        public async Task<IEnumerable<IReadOnlyEntry>> GetRelated(Identifier identifier, EntryRelation relations, ExecutionScope scope)
        {
            return await _connection.Entries.Data.GetRelated(identifier, relations, scope, EntryRelation.All);
        }


        public event Action<Identifier> Prepared = delegate { };
        public event Action<Identifier> Stored = delegate { };

        private void OnPrepared(Identifier identifier)
        {
            Prepared(identifier);
        }

        private void OnStored(Identifier identifier)
        {
            Stored(identifier);
        }
    }
}
