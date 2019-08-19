﻿namespace EtAlii.Ubigia.Infrastructure.Transport.User.Portal.NetCore
{
    using EtAlii.Ubigia.Infrastructure.Transport.NetCore;
    using EtAlii.xTechnology.Hosting;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;

    public class UserPortalControllerService : NetCoreServiceBase
    {
        public UserPortalControllerService(IConfigurationSection configuration) : base(configuration)
        {
        }

        protected override void OnConfigureApplication(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseBranchWithServices(Port, AbsoluteUri.User.Portal.BaseUrl,
                services =>
                {
                    services
                    //    .AddSingleton<IAccountRepository>(infrastructure.Accounts)
                    //    .AddSingleton<ISpaceRepository>(infrastructure.Spaces)
                    //    .AddSingleton<IStorageRepository>(infrastructure.Storages)
                        .AddMvcForTypedController<UserPortalController>();
                },
                appBuilder =>
                {
                    appBuilder.UseMvc();
                    appBuilder.UseWelcomePage();
                });
        }
    }
}
