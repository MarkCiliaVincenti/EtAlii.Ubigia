﻿namespace EtAlii.Ubigia.Provisioning.Hosting
{
    using System.Configuration;
    using EtAlii.Ubigia.Provisioning.Hosting;
    using EtAlii.xTechnology.Hosting;
    using ConsoleHost = EtAlii.xTechnology.Hosting.ConsoleHost;

    public class Program
    {
        /// <summary>
        /// The main entry point for the application. 
        /// </summary>
        public static void Main()
        {
            var exeConfiguration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var configuration = new HostConfigurationBuilder()
                .Build(sectionName => exeConfiguration.GetSection(sectionName))
                .UseConsoleHost();

            ConsoleHost.Start(configuration);
        }
    }
}
