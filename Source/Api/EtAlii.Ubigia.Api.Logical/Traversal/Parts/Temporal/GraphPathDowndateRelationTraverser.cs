namespace EtAlii.Ubigia.Api.Logical
{
    using System.Collections.Generic;
    using System.Linq;

    internal class GraphPathDowndateRelationTraverser : IGraphPathDowndateRelationTraverser
    {
        public void Configure(TraversalParameters parameters)
        {
            parameters.Input.SubscribeAsync(
                    onError: e => parameters.Output.OnError(e),
                    onNext: async start =>
                    {
                        var results = parameters.Context.Entries
                            .GetRelated(start, EntryRelation.Downdate, parameters.Scope)
                            .Select(e => e.Id);
                        await foreach (var result in results)
                        {
                            parameters.Output.OnNext(result);
                        }
                    },
                    onCompleted: () => parameters.Output.OnCompleted());
        }

        public IAsyncEnumerable<Identifier> Traverse(GraphPathPart part, Identifier start, IPathTraversalContext context, ExecutionScope scope)
        {
            return context.Entries
                .GetRelated(start, EntryRelation.Downdate, scope)
                .Select(e => e.Id); 
        }
    }
}