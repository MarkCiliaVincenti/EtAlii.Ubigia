// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

[assembly: Xunit.AssemblyTrait("Transport", "SignalR")]

// ReSharper disable once CheckNamespace
namespace EtAlii.Ubigia.Api.Transport.Tests
{
    using EtAlii.xTechnology.Hosting;

    internal static class UnitTestSettings
    {
        public static readonly PortRange NetworkPortRange = new(UnitTestConstants.NetworkPortRangeStart + 14400, UnitTestConstants.NetworkPortRangeStart + 14599);
    }
}
