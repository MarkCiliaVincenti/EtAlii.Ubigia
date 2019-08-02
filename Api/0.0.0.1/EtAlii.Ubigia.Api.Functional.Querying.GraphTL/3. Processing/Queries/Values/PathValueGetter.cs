namespace EtAlii.Ubigia.Api.Functional
{
    using System.Linq;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Logical;

    internal class PathValueGetter : IPathValueGetter
    {
        private readonly IGraphSLScriptContext _scriptContext;
        private readonly IRelatedIdentityFinder _relatedIdentityFinder;

        public PathValueGetter(IGraphSLScriptContext scriptContext, IRelatedIdentityFinder relatedIdentityFinder)
        {
            _scriptContext = scriptContext;
            _relatedIdentityFinder = relatedIdentityFinder;
        }

        public async Task<Value> Get(string valueName, Structure structure, PathSubject path, SchemaExecutionScope executionScope)
        {
            var id = _relatedIdentityFinder.Find(structure);
            if (id != Identifier.Empty)
            {
                var parts = new PathSubjectPart[]
                        {new ParentPathSubjectPart(), new IdentifierPathSubjectPart(id)}.Concat(path.Parts)
                    .ToArray();
                path = new AbsolutePathSubject(parts);
                var script = new Script(new Sequence(new SequencePart[] {path}));

                var processResult = await _scriptContext.Process(script, executionScope.ScriptScope);
                var result = await processResult.Output.SingleOrDefaultAsync();
                if (result is IInternalNode valueNode)
                {
                    return new Value(valueName, valueNode.Type);
                }
            }

            return null;
        }
    }
}