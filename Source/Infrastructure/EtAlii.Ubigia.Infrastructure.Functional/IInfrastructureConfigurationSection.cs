// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Infrastructure.Functional
{
    public interface IInfrastructureConfigurationSection
    {
        IInfrastructureConfiguration ToInfrastructureConfiguration();
    }
}