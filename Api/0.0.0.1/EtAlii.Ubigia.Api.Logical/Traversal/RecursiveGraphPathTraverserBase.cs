namespace EtAlii.Ubigia.Api.Logical
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal abstract class RecursiveGraphPathTraverserBase  
    {
        public void Configure(TraversalParameters parameters)
        {
            parameters.Input.SubscribeAsync(
                    onError: e => parameters.Output.OnError(e),
                    onNext: async start =>
                    {
//                        var task = Task.Run(async () =>
//                        {
                            if (start == Identifier.Empty)
                            {
                                throw new GraphTraversalException("Recursive traversal cannot be done at the root of a graph");
                            }

                            var results = await TraverseRecursive(start, parameters.Context, parameters.Scope);
                            foreach (var result in results.Distinct())
                            {
                                parameters.Output.OnNext(result);
                            }
//                        });
//                        task.Wait();
                    },
                    onCompleted: () => parameters.Output.OnCompleted());
        }

        public async Task<IEnumerable<Identifier>> Traverse(GraphPathPart part, Identifier start, ITraversalContext context, ExecutionScope scope)
        {
            if (start == Identifier.Empty)
            {
                throw new GraphTraversalException("Recursive traversal cannot be done at the root of a graph");
            }

            var result = await TraverseRecursive(start, context, scope);
            return result.Distinct();
        }

        protected abstract Task<IEnumerable<Identifier>> GetNextRecursion(
            Identifier start, 
            ITraversalContext context,
            ExecutionScope scope); 

        private async Task<IEnumerable<Identifier>> TraverseRecursive(
            Identifier start, 
            ITraversalContext context,
            ExecutionScope scope) 
        {
            var result = new List<Identifier>();
            result.Add(start);
            var subItems = (await GetNextRecursion(start, context, scope))
                .ToArray();

            foreach (var subItem in subItems)
            {
                var subResults = await TraverseRecursive(subItem, context, scope);
                result.AddRange(subResults);
            }
            return result;
        }
    }
}