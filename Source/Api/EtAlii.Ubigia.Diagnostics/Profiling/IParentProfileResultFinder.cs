// Copyright (c) Peter Vrenken. All rights reserved. See the license in https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Diagnostics.Profiling
{
    public interface IParentProfileResultFinder
    {
        ProfilingResult Find(IProfiler profiler);
    }
}