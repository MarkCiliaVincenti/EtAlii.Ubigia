﻿namespace EtAlii.Ubigia.Provisioning.Microsoft.Graph
{
    using EtAlii.Ubigia.Api.Functional;
    using EtAlii.Ubigia.Api.Transport.Management;
    using EtAlii.xTechnology.Logging;
    using EtAlii.xTechnology.MicroContainer;

    public class MicrosoftGraphProviderFactory : IProviderFactory
    {
        public IProvider Create(IProviderConfiguration configuration)
        {
            var container = new Container();

            container.Register<IProviderConfiguration>(() => configuration);
            container.Register<IDataContext>(() => configuration.SystemDataContext);
            container.Register<IManagementConnection>(() => configuration.ManagementConnection);
            container.Register<IProviderContext, ProviderContext>();
            container.Register<IProvider, MicrosoftGraphProvider>();

            container.Register<ISystemSettingsProvider, SystemSettingsProvider>();
            container.Register<ISystemSettingsGetter, SystemSettingsGetter>();
            container.Register<ISystemSettingsSetter, SystemSettingsSetter>();

            //container.Register<IDataContext>(() => configuration.);

            container.Register<IMailImporter, MailImporter>();
            container.Register<ICalendarImporter, CalendarImporter>();
            container.Register<IPeopleImporter, PeopleImporter>();
            container.Register<IOneDriveImporter, OneDriveImporter>();
            container.Register<IOneNoteImporter, OneNoteImporter>();

            container.Register<ILogger>(() => configuration.LogFactory.Create("Microsoft.Graph", "Provider"));

            return container.GetInstance<IProvider>();
        }
    }
}
