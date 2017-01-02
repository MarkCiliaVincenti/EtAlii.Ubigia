﻿namespace EtAlii.Servus.Infrastructure
{
    using EtAlii.Servus.Api;
    using EtAlii.xTechnology.Logging;
    using SimpleInjector;
    using SimpleInjector.Extensions;

    internal class InfrastructureLoggingScaffolding : IScaffolding
    {
        private readonly IDiagnosticsConfiguration _diagnostics;

        public InfrastructureLoggingScaffolding(IDiagnosticsConfiguration diagnostics)
        {
            _diagnostics = diagnostics;
        }

        public void Register(Container container)
        {
            container.Register<ILogFactory>(() => _diagnostics.CreateLogFactory(), Lifestyle.Singleton);
            container.Register<ILogger>(() => _diagnostics.CreateLogger(container.GetInstance<ILogFactory>()), Lifestyle.Transient);
            if (_diagnostics.EnableLogging) // logging is enabled.
            {
                container.RegisterDecorator(typeof(IEntryGetter), typeof(LoggingEntryGetterDecorator), Lifestyle.Singleton);
                container.RegisterDecorator(typeof(IEntryPreparer), typeof(LoggingEntryPreparerDecorator), Lifestyle.Singleton);
                container.RegisterDecorator(typeof(IEntryStorer), typeof(LoggingEntryStorerDecorator), Lifestyle.Singleton);
                container.RegisterDecorator(typeof(IEntryUpdater), typeof(LoggingEntryUpdaterDecorator), Lifestyle.Singleton);

                container.RegisterDecorator(typeof(IStorageRepository), typeof(LoggingStorageRepositoryDecorator), Lifestyle.Singleton);
            }
        }
    }
}