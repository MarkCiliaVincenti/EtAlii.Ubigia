﻿namespace EtAlii.Servus.Api.Functional
{
    using System;
    using System.Linq;
    using EtAlii.Servus.Api.Fabric;
    using EtAlii.Servus.Api.Logical;
    using EtAlii.Servus.Api.Transport;

    public class DataContextConfiguration : IDataContextConfiguration
    {
        public ILogicalContext LogicalContext { get { return _logicalContext; } }
        private ILogicalContext _logicalContext;

        public IDataContextExtension[] Extensions { get { return _extensions; } }
        private IDataContextExtension[] _extensions;

        public IFunctionHandlersProvider FunctionHandlersProvider { get { return _functionHandlersProvider; } }
        private IFunctionHandlersProvider _functionHandlersProvider;

        public DataContextConfiguration()
        {
            _extensions = new IDataContextExtension[0];
            _functionHandlersProvider = Functional.FunctionHandlersProvider.Empty;
        }

        public IDataContextConfiguration Use(ILogicalContext logicalContext)
        {
            _logicalContext = logicalContext;
            return this;
        }

        public IDataContextConfiguration Use(IFunctionHandlersProvider functionHandlersProvider)
        {
            _functionHandlersProvider = functionHandlersProvider;
            return this;
        }

        public IDataContextConfiguration Use(IDataContextExtension[] extensions)
        {
            if (extensions == null)
            {
                throw new ArgumentException("extensions");
            }

            _extensions = extensions
                .Concat(_extensions)
                .Distinct()
                .ToArray();
            return this;
        }

        public IDataContextConfiguration Use(IDataConnection dataConnection)
        {
            var fabricContextConfiguration = new FabricContextConfiguration()
                .Use(dataConnection);
            var fabricContext = new FabricContextFactory().Create(fabricContextConfiguration);

            var logicalContextConfiguration = new LogicalContextConfiguration()
                .Use(fabricContext);
            var logicalContext = new LogicalContextFactory().Create(logicalContextConfiguration);

            return this.Use(logicalContext);
        }
    }
}