﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Persistence
{
    public interface IStorageConfigurationSection
    {
        IStorageConfiguration ToStorageConfiguration();
    }
}
