namespace EtAlii.Ubigia.Api.Functional
{
    using EtAlii.Ubigia.Api.Functional.Traversal;

    public interface ISchemaProcessorConfiguration : IConfiguration
    {
        ISchemaScope SchemaScope { get; }

        ITraversalScriptContext ScriptContext { get; }

        SchemaProcessorConfiguration Use(ISchemaScope scope);
        SchemaProcessorConfiguration Use(ITraversalScriptContext scriptContext);
    }
}
