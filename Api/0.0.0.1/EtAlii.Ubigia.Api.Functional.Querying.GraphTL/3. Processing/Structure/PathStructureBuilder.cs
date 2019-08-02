namespace EtAlii.Ubigia.Api.Functional
{
    using System;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Logical;

    internal class PathStructureBuilder : IPathStructureBuilder
    {
        private readonly IGraphSLScriptContext _scriptContext;

        protected PathStructureBuilder(IGraphSLScriptContext scriptContext)
        {
            _scriptContext = scriptContext;
        }

        public async Task Build(
            SchemaExecutionScope executionScope, 
            FragmentMetadata fragmentMetadata,
            IObserver<Structure> fragmentOutput, 
            Annotation annotation, 
            string structureName, 
            Structure parent, 
            PathSubject path)
        {
            var script = new Script(new Sequence(new SequencePart[] {path}));
            var scriptResult = await _scriptContext.Process(script, executionScope.ScriptScope);

            switch (annotation?.Type)
            {
                case AnnotationType.Node:
                    if (await scriptResult.Output.SingleOrDefaultAsync() is IInternalNode lastOutput)
                    {
                        Build(lastOutput, fragmentOutput, structureName, fragmentMetadata, parent);
                    }

                    break;
                case AnnotationType.Nodes:
                case null: // We have a nested node.
                    scriptResult.Output
                        .OfType<IInternalNode>()
                        .Subscribe(
                            onError: fragmentOutput.OnError,
                            onNext: o => Build(o, fragmentOutput, structureName, fragmentMetadata, parent),
                            onCompleted: () => { });
                    break;
                case AnnotationType.Value:
                    break;
            }
        }

        private void Build(
            IInternalNode node, 
            IObserver<Structure> fragmentOutput, 
            string structureName, 
            FragmentMetadata fragmentMetadata,
            Structure parent)
        {
            var item = new Structure(structureName, node.Type, parent, node);
            fragmentMetadata.Items.Add(item);
            fragmentOutput.OnNext(item);
        }
    }
}