// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Functional.Traversal;

using Moppet.Lapa;

internal interface IFloatValueParser
{
    LpsParser Parser { get; }
    string Id { get; }

    float Parse(LpNode node);
    bool CanParse(LpNode node);
}
