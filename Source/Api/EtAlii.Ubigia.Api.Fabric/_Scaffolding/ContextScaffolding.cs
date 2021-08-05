﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Fabric
{
    using EtAlii.xTechnology.MicroContainer;

    internal class ContextScaffolding : IScaffolding
    {
        private readonly IFabricContextOptions _options;

        public ContextScaffolding(IFabricContextOptions options)
        {
            _options = options;
        }

        public void Register(Container container)
        {
            container.Register<IFabricContext, FabricContext>();
            container.Register(() => _options);
            container.Register(() => _options.ConfigurationRoot);
            container.Register(() => _options.Connection);
        }
    }
}
