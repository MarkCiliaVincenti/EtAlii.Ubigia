﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Infrastructure.Hosting.TrayIconHost
{
	using System.Windows;
    using EtAlii.xTechnology.Hosting;
	using EtAlii.xTechnology.Hosting.Diagnostics;
	using Microsoft.Extensions.Configuration;

	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
        private async void OnApplicationStartup(object sender, StartupEventArgs e)
        {
	        var details = await new ConfigurationDetailsParser()
                .Parse("settings.json")
                .ConfigureAwait(true);

	        var configurationRoot = new ConfigurationBuilder()
		        .AddConfigurationDetails(details)
		        .Build();

	        var hostOptions = new HostOptionsBuilder()
		        .Build(configurationRoot, details)
                .UseTrayIconHost(this,
                    "Icon-Logo-White-Shaded.ico",
                    "Icon-Logo-Black.ico",
                    "Icon-Logo-Red.ico")
		        .UseHostDiagnostics();

            TrayIconHost.Start(hostOptions);
        }
    }
}
