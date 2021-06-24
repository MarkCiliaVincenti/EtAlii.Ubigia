// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Functional.Traversal
{
    using System;
    using System.Threading.Tasks;

    public interface ISequenceExecutionPlan
    {
        Task<IObservable<object>> Execute(ExecutionScope scope);
    }
}
