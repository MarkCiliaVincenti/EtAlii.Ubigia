// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Functional.Traversal
{
    using EtAlii.Ubigia.Diagnostics.Profiling;

    internal interface IProfilingScriptProcessor : IScriptProcessor
    {
        IProfiler Profiler { get; }
    }
}
