﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// ReSharper disable All

using System.Threading.Channels;

namespace Microsoft.AspNetCore.Sockets.Features
{
    public interface IConnectionTransportFeature
    {
        Channel<byte[]> Transport { get; set; }

        TransferMode TransportCapabilities { get; set; }
    }
}
