﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Infrastructure.Fabric;

using System.Threading.Tasks;

public interface IContentDefinitionGetter
{
    Task<ContentDefinition> Get(Identifier identifier);
}
