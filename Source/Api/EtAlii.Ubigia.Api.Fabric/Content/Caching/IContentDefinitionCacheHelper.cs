﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license in https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Fabric
{
    internal interface IContentDefinitionCacheHelper
    {
        ContentDefinition Get(in Identifier identifier);
        void Store(in Identifier identifier, ContentDefinition definition);
    }
}