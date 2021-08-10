// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Infrastructure.Hosting.TestHost.Rest
{
    using EtAlii.xTechnology.Diagnostics;
    using EtAlii.xTechnology.Hosting;
    using EtAlii.xTechnology.MicroContainer;
    using Microsoft.Extensions.Configuration;

    public class TestHostExtension : IHostExtension
    {
        private readonly IConfigurationRoot _configurationRoot;

        public TestHostExtension(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public void Register(Container container)
        {
            var options = _configurationRoot
                .GetSection("Infrastructure:Hosting:Diagnostics")
                .Get<DiagnosticsOptions>();

            var scaffoldings = new IScaffolding[]
            {
                new TestHostScaffolding(),
                new TestHostProfilingScaffolding(options),
                new TestHostLoggingScaffolding(options),
                new TestHostDebuggingScaffolding(options),
            };

            foreach (var scaffolding in scaffoldings)
            {
                scaffolding.Register(container);
            }
        }
    }
}
