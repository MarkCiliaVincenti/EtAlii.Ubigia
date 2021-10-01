// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.xTechnology.Hosting
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
    using System.Net.Http;
    using System.Threading.Tasks;
    using EtAlii.xTechnology.Diagnostics;
    using EtAlii.xTechnology.Hosting.Diagnostics;
    using Microsoft.Extensions.Configuration;

    public abstract class HostTestContextBase<THost> : IHostTestContext
		where THost: class, ITestHost
    {
	    private readonly Guid _uniqueId = Guid.Parse("827F11D6-4305-47C6-B42B-1271052FAC86");

        /// <inheritdoc />
        public IConfigurationRoot HostConfiguration { get; private set; }

        /// <inheritdoc />
        public IConfigurationRoot ClientConfiguration { get; private set; }

	    public THost Host { get; private set; }
        protected bool UseInProcessConnection { get; init; }

	    private readonly string _hostConfigurationFile;
        private readonly string _clientConfigurationFile;

        public ReadOnlyDictionary<string, string> Folders { get; private set; }
	    public ReadOnlyDictionary<string, string> Hosts { get; private set; }
	    public ReadOnlyDictionary<string, int> Ports { get; private set; }
	    public ReadOnlyDictionary<string, string> Paths { get; private set; }

	    protected HostTestContextBase(string hostConfigurationFile, string clientConfigurationFile)
	    {
		    _hostConfigurationFile = hostConfigurationFile;
            _clientConfigurationFile = clientConfigurationFile;

            Folders = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>());
		    Hosts = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>());
		    Ports = new ReadOnlyDictionary<string, int>(new Dictionary<string, int>());
		    Paths = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>());
	    }

        public virtual async Task Start(PortRange portRange)
	    {
		    // We want to start only one test hosting at the same time.
            if (UseInProcessConnection)
            {
                await StartInternal(portRange).ConfigureAwait(false);
            }
            else
            {
                using var _ = new SystemSafeExecutionScope(_uniqueId);
                await StartInternal(portRange).ConfigureAwait(false);
            }
	    }

	    private async Task StartInternal(PortRange portRange)
	    {
            // As we're testing with both a hosting environment and clients in the same process we need to use distinct configuration roots.

            var details = await new ConfigurationDetailsParser()
                .ParseForTesting(_hostConfigurationFile, portRange)
                .ConfigureAwait(false);
		    Folders = details.Folders;
		    Hosts = details.Hosts;
		    Ports = details.Ports;
		    Paths = details.Paths;

            HostConfiguration = new ConfigurationBuilder()
			    .AddConfigurationDetails(details)
                .AddConfiguration(DiagnosticsOptions.ConfigurationRoot) // For testing we'll override the configured logging et.
			    .Build();

            var hostOptions = new HostOptionsBuilder()
                .Build(HostConfiguration, details)
                .UseHostDiagnostics();

            ClientConfiguration = new ConfigurationBuilder()
                .AddJsonFile(_clientConfigurationFile)
                .AddConfiguration(DiagnosticsOptions.ConfigurationRoot) // For testing we'll override the configured logging et.
                .Build();

            Host = (THost)new HostFactory<THost>().Create(hostOptions, false);
		    await Host.Start().ConfigureAwait(false);
        }

	    public virtual async Task Stop()
	    {
		    await Host.Stop().ConfigureAwait(false);
		    Host = null;
	    }

        public HttpMessageHandler CreateHandler() => UseInProcessConnection
            ? Host.CreateHandler()
            : new HttpClientHandler();

        public HttpClient CreateClient() => UseInProcessConnection
            ? Host.CreateClient()
            : new HttpClient();
    }
}
