﻿namespace EtAlii.Ubigia.Infrastructure.Hosting.ConsoleHost.AspNetCore
{
    using EtAlii.xTechnology.Hosting;
    using EtAlii.xTechnology.Hosting.ConsoleHost;
    using Microsoft.Extensions.Configuration;

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application. 
        /// </summary>
        public static void Main()
        {
            var applicationConfiguration = new ConfigurationBuilder()
                .AddJsonFile("settings.json", optional: true)
                //.AddXmlFile("app.config")
                .Build();

            var hostConfiguration = new HostConfigurationBuilder()
                .Build(applicationConfiguration)
                .UseConsoleHost();

            ConsoleHost.Start(hostConfiguration);
        }
    }
}
