﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

// TODO: Rename this whole project to EtAlii.Ubigia.infrastructure.Fabric.InMemory
// And of course also the other persistence projects.
namespace EtAlii.Ubigia.Infrastructure.Transport.InMemory
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Persistence;
    using EtAlii.Ubigia.Persistence.InMemory;
    using EtAlii.xTechnology.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class StorageService : IStorageService
    {
        public Status Status { get; }
        public ServiceConfiguration Configuration { get; }
        public IStorage Storage { get; private set; }

        public StorageService(ServiceConfiguration configuration, Status status)
        {
            Configuration = configuration;
            Status = status;
        }

        public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private IStorage CreateStorage()
        {
            string name;
            name = Configuration.Section.GetValue<string>(nameof(name));
            if (name == null)
            {
                throw new InvalidOperationException($"Unable to start service {nameof(StorageService)}: {nameof(name)} not set in service configuration.");
            }

            string baseFolder;
            baseFolder = Configuration.Section.GetValue<string>(nameof(baseFolder));
            if (baseFolder == null)
            {
                throw new InvalidOperationException($"Unable to start service {nameof(StorageService)}: {nameof(baseFolder)} not set in service configuration.");
            }

            var storageOptions = new StorageOptions(Configuration.Root)
                .Use(name)
                .UseInMemoryStorage()
                .UseStorageDiagnostics();
            return new StorageFactory().Create(storageOptions);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Storage = CreateStorage();
            services.AddSingleton<IStorageService>(this);
            services.AddHostedService(_ => this);
        }
    }
}
