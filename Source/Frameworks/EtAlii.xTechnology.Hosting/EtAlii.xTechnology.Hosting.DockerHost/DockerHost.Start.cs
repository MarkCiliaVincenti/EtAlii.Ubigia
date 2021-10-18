// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.xTechnology.Hosting
{
    using System;
    using System.Threading.Tasks;
    using EtAlii.xTechnology.Diagnostics;
    using EtAlii.xTechnology.MicroContainer;
    using Serilog;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class DockerHost
    {
        private static readonly ILogger _log = Log.ForContext<DockerHost>();

        public static async Task Start(HostOptions options)
        {
            // We want to start logging as soon as possible. This means not waiting until the ASP.NET Core hosting subsystem has started.
            DiagnosticsOptions.Initialize(options.EntryAssembly, options.ConfigurationRoot);

            var arguments = Environment.GetCommandLineArgs();
            for (var i = 0; i < arguments.Length; i++)
            {
                if (arguments[i] == "-d" && i + 1 < arguments.Length)
                {
                    var delay = int.Parse(arguments[i + 1]);
                    await Task
                        .Delay(delay)
                        .ConfigureAwait(false);
                }
            }

            _log.Information("Starting Ubigia infrastructure");

            var host = Factory.Create<IHost>(options);

            // Start hosting both the infrastructure and the storage.
            await host
                .Start()
                .ConfigureAwait(false);

            var dockerDialog = new DockerDialog(host);
            dockerDialog.Start();
        }
    }
}
