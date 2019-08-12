namespace EtAlii.Ubigia.Api.Functional.Diagnostics 
{
    using EtAlii.Ubigia.Api.Diagnostics.Profiling;

    internal interface IProfilingSchemaProcessor : ISchemaProcessor
    {
        IProfiler Profiler { get; }
    }
}