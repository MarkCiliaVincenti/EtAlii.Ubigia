namespace EtAlii.Ubigia.Api.Functional.Context
{
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Functional.Traversal;

    internal interface IPathStructureBuilder
    {
        Task Build(
            SchemaExecutionScope executionScope,
            FragmentMetadata fragmentMetadata,
            NodeAnnotation annotation,
            string structureName,
            Structure parent,
            PathSubject path);
    }
}
