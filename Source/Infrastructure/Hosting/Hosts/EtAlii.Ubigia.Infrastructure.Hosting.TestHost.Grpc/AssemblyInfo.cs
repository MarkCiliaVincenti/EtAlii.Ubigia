﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

[assembly: InternalsVisibleTo("EtAlii.Ubigia.Infrastructure.Hosting.Grpc.Tests")]

// This code is only used for testing. It should be refactored the moment our tests will run on non-windows environments.
[assembly:SupportedOSPlatform("windows")]

