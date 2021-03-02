﻿namespace EtAlii.Ubigia.Api.Functional.Context
{
    using System.Threading.Tasks;

    internal interface IFragmentProcessor<in TFragment>
        where TFragment: Fragment
    {
        Task Process(
            TFragment fragment,
            ExecutionPlanResultSink executionPlanResultSink,
            SchemaExecutionScope executionScope);

    }
}
