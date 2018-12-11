﻿namespace EtAlii.Ubigia.Windows.Diagnostics.SpaceBrowser
{
    using EtAlii.Ubigia.Api.Fabric;
    using EtAlii.Ubigia.Api.Functional;
    using EtAlii.Ubigia.Api.Logical;
    using EtAlii.Ubigia.Api.Transport;
    using EtAlii.xTechnology.Diagnostics;
    using EtAlii.xTechnology.Logging;

    public interface IDocumentFactory
    {
        IDocumentViewModel Create(
            IGraphSLScriptContext scriptContext,
            IGraphQLQueryContext queryContext,
            ILogicalContext logicalContext,
            IFabricContext fabricContext,
            IDataConnection connection,
            IDiagnosticsConfiguration diagnostics, 
            ILogger logger, 
            ILogFactory logFactory, 
            IJournalViewModel journal,
            IGraphContextFactory graphContextFactory);
    }
}
