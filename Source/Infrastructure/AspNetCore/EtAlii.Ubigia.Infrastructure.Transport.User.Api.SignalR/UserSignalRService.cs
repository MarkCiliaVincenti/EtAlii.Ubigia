﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Infrastructure.Transport.User.Api.SignalR
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using EtAlii.Ubigia.Infrastructure.Transport.SignalR;
    using EtAlii.Ubigia.Serialization;
    using EtAlii.xTechnology.Hosting;
	using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.SignalR;

	public class UserSignalRService : INetworkService
    {
        /// <inheritdoc />
        public Status Status { get; }

        /// <inheritdoc />
        public ServiceConfiguration Configuration { get; }

        public UserSignalRService(ServiceConfiguration configuration, Status status)
        {
            Configuration = configuration;
            Status = status;
        }

        [SuppressMessage(
            category: "Sonar Code Smell",
            checkId: "S4792:Configuring loggers is security-sensitive",
            Justification = "Safe to do so here.")]
        public void ConfigureServices(IServiceCollection services, IServiceProvider globalServices)
        {
            var infrastructure = globalServices.GetService<IInfrastructureService>()!.Infrastructure;

	        services
		        .AddSingleton(infrastructure.Spaces)
		        .AddSingleton(infrastructure.Accounts)
		        .AddSingleton(infrastructure.Roots)
		        .AddSingleton(infrastructure.Entries)
		        .AddSingleton(infrastructure.Properties)
		        .AddSingleton(infrastructure.Content)
		        .AddSingleton(infrastructure.ContentDefinition)

		        .AddSignalRInfrastructureAuthentication(infrastructure)
		        .AddInfrastructureSerialization()

		        .AddRouting()
		        .AddCors()
		        .AddSignalR(options =>
		        {
                    options.AddFilter(new CorrelationServiceHubFilter(infrastructure.ContextCorrelator));

                    // SonarQube: Make sure that this logger's configuration is safe.
                    // As we only add the logging services this ought to be safe. It is when and how they are configured that matters.
			        if (Debugger.IsAttached)
			        {
				        options.EnableDetailedErrors = true;
			        }
		        })
		        .AddHubOptions<ContentHub>(options =>
		        {
			        const long maximumReceiveMessageSizeInMegaByte = 1024 * 1024 * 2;
			        options.MaximumReceiveMessageSize = maximumReceiveMessageSizeInMegaByte;
		        })
		        .AddNewtonsoftJsonProtocol(options => SerializerFactory.Configure(options.PayloadSerializerSettings));
        }

        public void ConfigureApplication(IApplicationBuilder application, IWebHostEnvironment environment)
        {
            // var hostString = new HostStringBuilder().Build(Configuration.Section, IPAddress.Any);

	        application
                // .UseCors(builder =>
                // {
                //     builder
                //         .AllowAnyHeader()
                //         .AllowAnyMethod()
                //         .WithOrigins($"https://{Configuration.IpAddress}");
                // })
		        .UseRouting()
		        .UseEndpoints(endPoints =>
		        {
			        endPoints.MapHub<AuthenticationHub>(SignalRHub.Authentication);

			        endPoints.MapHub<AccountHub>(SignalRHub.Account);
			        endPoints.MapHub<SpaceHub>(SignalRHub.Space);

			        endPoints.MapHub<RootHub>(SignalRHub.Root);
			        endPoints.MapHub<EntryHub>(SignalRHub.Entry);
			        endPoints.MapHub<PropertiesHub>(SignalRHub.Property);
			        endPoints.MapHub<ContentHub>(SignalRHub.Content);
			        endPoints.MapHub<ContentDefinitionHub>(SignalRHub.ContentDefinition);
		        });
        }
    }
}
