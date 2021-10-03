﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.xTechnology.Hosting.Tests.Infrastructure.Grpc
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class AuthenticationService : INetworkService
    {
        public Status Status { get; }
        public ServiceConfiguration Configuration { get; }

        public AuthenticationService(ServiceConfiguration configuration, Status status)
        {
            Configuration = configuration;
            Status = status;
        }

        public void ConfigureServices(IServiceCollection services, IServiceProvider globalServices) { }

        public void ConfigureApplication(IApplicationBuilder application, IWebHostEnvironment environment) { }
    }
}
