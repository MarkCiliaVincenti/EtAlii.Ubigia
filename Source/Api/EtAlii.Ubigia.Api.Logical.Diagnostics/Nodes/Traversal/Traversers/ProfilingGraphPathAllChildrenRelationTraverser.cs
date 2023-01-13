// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Logical.Diagnostics;

using System.Collections.Generic;
using System.Threading.Tasks;
using EtAlii.Ubigia.Diagnostics.Profiling;

public class ProfilingGraphPathAllChildrenRelationTraverser : IGraphPathAllChildrenRelationTraverser
{
    private readonly IGraphPathAllChildrenRelationTraverser _decoree;
    private readonly IProfiler _profiler;

    public ProfilingGraphPathAllChildrenRelationTraverser(IGraphPathAllChildrenRelationTraverser decoree, IProfiler profiler)
    {
        _decoree = decoree;
        _profiler = profiler.Create(ProfilingAspects.Logical.Traversers);
    }

    public void Configure(TraversalParameters parameters)
    {
        dynamic profile = _profiler.Begin("Configuring relation traversing: ALL CHILDREN");
        profile.Part = parameters.Part;

        _decoree.Configure(parameters);

        _profiler.End(profile);
    }

    public async IAsyncEnumerable<Identifier> Traverse(GraphPathPart part, Identifier start, IPathTraversalContext context, ExecutionScope scope)
    {
        dynamic profile = _profiler.Begin("Traversing relation: ALL CHILDREN");
        profile.Part = part;
        profile.Start = start;

        var result = _decoree
            .Traverse(part, start, context, scope)
            .ConfigureAwait(false);
        await foreach (var item in result)
        {
            yield return item;
        }
        _profiler.End(profile);
    }
}
