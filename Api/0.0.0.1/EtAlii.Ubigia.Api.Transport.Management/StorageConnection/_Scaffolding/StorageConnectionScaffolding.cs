﻿namespace EtAlii.Ubigia.Api.Transport.Management
{
    using EtAlii.Ubigia.Api.Transport;
    using EtAlii.xTechnology.MicroContainer;

    internal class StorageConnectionScaffolding : IScaffolding
    {
        private readonly IStorageConnectionConfiguration _configuration;

        public StorageConnectionScaffolding(IStorageConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Register(Container container)
        {
            container.Register(() => _configuration.Transport);
            container.Register(() => _configuration);

            container.Register<IAuthenticationManagementContext, AuthenticationManagementContext>();
            container.Register<IStorageContext, StorageContext>();
            container.Register<IAccountContext, AccountContext>();
            container.Register<ISpaceContext, SpaceContext>();
        }
    }
}
