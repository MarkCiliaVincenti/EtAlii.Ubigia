﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.xTechnology.Hosting.Tests.Infrastructure.User.Api.NetCore
{
    using System;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class UserSignalRService : INetworkService
    {
        public ServiceConfiguration Configuration { get; }

        public UserSignalRService(ServiceConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureApplication(IApplicationBuilder application, IWebHostEnvironment environment)
        {
            application
                // .UseCors(builder =>
                // {
                //     builder
                //         .AllowAnyHeader()
                //         .AllowAnyMethod()
                //         .WithOrigins($"https://{Configuration.IpAddress}");
                // })
                .UseRouting()
                .UseEndpoints(endpoints => endpoints.MapHub<UserHub>($"{nameof(UserHub)}"));
        }

        public void ConfigureServices(IServiceCollection services, IServiceProvider globalServices)
        {
            services
                .AddRouting()
                .AddCors()
                .AddSignalR(options =>
                {
                    options.EnableDetailedErrors = Debugger.IsAttached;
                })
                .AddJsonProtocol();
        }

    }
}
