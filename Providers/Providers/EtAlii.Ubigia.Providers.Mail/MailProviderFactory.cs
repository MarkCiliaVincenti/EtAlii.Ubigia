﻿namespace EtAlii.Ubigia.Provisioning.Mail
{
    using EtAlii.Ubigia.Api.Functional;
    using EtAlii.Ubigia.Api.Transport.Management;
    using EtAlii.xTechnology.Logging;

    public class MailProviderFactory : IProviderFactory
    {
        public IProvider Create(IProviderConfiguration configuration)
        {
            var container = new xTechnology.MicroContainer.Container();

            container.Register(() => configuration);
            container.Register(() => configuration.SystemDataContext);
            container.Register(() => configuration.ManagementConnection);
            container.Register<IProviderContext, ProviderContext>();
            container.Register<IProvider, MailProvider>();

            container.Register<IMailImporter, MailImporter>();

            container.Register(() => configuration.LogFactory.Create("Mail", "Provider"));

            return container.GetInstance<IProvider>();
        }
    }
}
