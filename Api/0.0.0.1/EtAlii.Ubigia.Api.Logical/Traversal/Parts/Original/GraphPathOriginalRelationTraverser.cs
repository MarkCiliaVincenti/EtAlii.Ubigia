namespace EtAlii.Ubigia.Api.Logical
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class GraphPathOriginalRelationTraverser : IGraphPathOriginalRelationTraverser
    {
        public GraphPathOriginalRelationTraverser()
        {
        }


        public void Configure(TraversalParameters parameters)
        {
            parameters.Input.Subscribe(
                    onError: e => parameters.Output.OnError(e),
                    onNext: start =>
                    {
                        var task = Task.Run(async () =>
                        {
                            Relation downDate;
                            Identifier previousResult;
                            Identifier result = start;
                            do
                            {
                                previousResult = result;
                                downDate = (await parameters.Context.Entries.Get(previousResult, parameters.Scope)).Downdate;
                                result = downDate.Id;
                            }
                            while (downDate != Relation.None);

                            parameters.Output.OnNext(previousResult);
                        });
                        task.Wait();
                    },
                    onCompleted: () => parameters.Output.OnCompleted());

        }

        public async Task<IEnumerable<Identifier>> Traverse(GraphPathPart part, Identifier start, ITraversalContext context, ExecutionScope scope)
        {
            Relation downDate;
            Identifier previousResult;
            Identifier result = start;
            do
            {
                previousResult = result;
                downDate = (await context.Entries.Get(previousResult, scope)).Downdate;
                result = downDate.Id;
            }
            while (downDate != Relation.None);

            return new Identifier[] { previousResult };
        }
    }
}