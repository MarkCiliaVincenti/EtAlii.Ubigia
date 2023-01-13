﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Infrastructure.Logical;

using System.Threading.Tasks;

public interface ILogicalContentSet
{
    Task<Content> Get(Identifier identifier);
    Task<ContentPart> Get(Identifier identifier, ulong contentPartId);
    Task Store(in Identifier identifier, ContentPart contentPart);
    Task Store(in Identifier identifier, Content content);
}
