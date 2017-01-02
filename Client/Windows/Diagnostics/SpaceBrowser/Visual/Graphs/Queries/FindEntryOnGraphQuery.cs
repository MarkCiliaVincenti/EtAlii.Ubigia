﻿
namespace EtAlii.Ubigia.Client.Windows.Diagnostics
{
    using EtAlii.Ubigia.Api;
    using EtAlii.Ubigia.Api.Fabric;
    using EtAlii.xTechnology.Workflow;

    public class FindEntryOnGraphQuery : QueryBase<FindEntryOnGraphQueryHandler, IReadOnlyEntry>
    {
        public Identifier Identifier { get; private set; }

        public FindEntryOnGraphQuery(Identifier identifier)
        {
            Identifier = identifier;
        }

        public FindEntryOnGraphQuery(Relation relation)
        {
            Identifier = relation.Id;
        }
    }
}
