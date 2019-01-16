﻿namespace EtAlii.Ubigia.Windows.Diagnostics.SpaceBrowser
{
    using EtAlii.Ubigia.Api.Fabric;
    using EtAlii.Ubigia.Api.Functional;
    using EtAlii.Ubigia.Api.Logical;
    using EtAlii.Ubigia.Api.Transport;
    using EtAlii.xTechnology.Diagnostics;
    using EtAlii.xTechnology.Logging;

    public class NewTemporalDocumentCommand : NewDocumentCommandBase, INewTemporalDocumentCommand
    {
        public NewTemporalDocumentCommand(IDocumentContext documentContext, ITemporalDocumentFactory factory) 
            : base(documentContext)
        {
            DocumentFactory = factory;
            Header = "Temporal";
            Icon = @"pack://siteoforigin:,,,/Images/Clock-01.png";
            TitleFormat = "Temporal view {0}";
            InfoLine = "Create a document to show information stored in a space temporal";
            InfoTip1 = "Useful for temporal analysis";
            InfoTip2 = null;
        }
    }
}
