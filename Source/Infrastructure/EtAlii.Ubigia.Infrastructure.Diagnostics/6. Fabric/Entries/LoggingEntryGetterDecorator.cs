﻿// ReSharper disable once CheckNamespace
namespace EtAlii.Ubigia.Infrastructure.Fabric.Diagnostics
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Serilog;

    internal class LoggingEntryGetterDecorator : IEntryGetter
    {
        private readonly ILogger _logger = Log.ForContext<IEntryGetter>();
        private readonly IEntryGetter _decoree;

        public LoggingEntryGetterDecorator(IEntryGetter decoree)
        {
            _decoree = decoree;
        }

        public IAsyncEnumerable<Entry> Get(IEnumerable<Identifier> identifiers, EntryRelation entryRelations)
        {
            return _decoree.Get(identifiers, entryRelations);
        }

        public Task<Entry> Get(Identifier identifier, EntryRelation entryRelations)
        {
            _logger.Verbose("Getting entry: {Identifier}", identifier.ToTimeString());

            return _decoree.Get(identifier, entryRelations);
        }


        public IAsyncEnumerable<Entry> GetRelated(Identifier identifier, EntryRelation entriesWithRelation, EntryRelation entryRelations)
        {
            _logger.Verbose("Getting entries for: {identifier}", identifier.ToTimeString());

            return _decoree.GetRelated(identifier, entriesWithRelation, entryRelations);
        }
    }
}
