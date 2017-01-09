﻿namespace EtAlii.Ubigia.Client.Windows.Diagnostics
{
    using EtAlii.Ubigia.Api.Fabric;
    using EtAlii.Ubigia.Api.Functional;
    using EtAlii.Ubigia.Api.Logical;
    using EtAlii.Ubigia.Api.Transport;
    using EtAlii.xTechnology.Diagnostics;
    using EtAlii.xTechnology.Logging;

    public class NewProfilingDocumentCommand : NewDocumentCommandBase, INewProfilingDocumentCommand
    {
        public NewProfilingDocumentCommand(
            IProfilingDocumentFactory factory,
            IDataContext dataContext, 
            ILogicalContext logicalContext, 
            IFabricContext fabricContext, 
            IDataConnection connection, 
            ILogger logger, 
            ILogFactory logFactory, 
            IDiagnosticsConfiguration diagnostics, 
            IJournal journal) 
            : base(dataContext, logicalContext, fabricContext, connection, logger, logFactory, diagnostics, journal)
        {
            DocumentFactory = factory;
            Header = "Profiling";
            Icon = @"\Images\Icons\Arrow.png";
            TitleFormat = "Profiler view {0}";
            InfoLine = "Create a profiling document";
            InfoTip1 = "Shows profiling details of all API access to a space";
            InfoTip2 = "Usefull for advanced query optimization";
        }
    }
}
