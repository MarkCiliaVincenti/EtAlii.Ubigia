namespace EtAlii.Ubigia.Api.Functional
{
    using System.Threading.Tasks;

    internal class ValueSetter : IValueSetter
    {
        private readonly IPropertiesValueSetter _propertiesValueSetter;
        private readonly IPathValueSetter _pathValueSetter;

        public ValueSetter(IPropertiesValueSetter propertiesValueSetter, IPathValueSetter pathValueSetter)
        {
            _propertiesValueSetter = propertiesValueSetter;
            _pathValueSetter = pathValueSetter;
        }
        public async Task<Value> Set(string valueName, object value, Annotation annotation, QueryExecutionScope executionScope, Structure structure)
        {
            if (annotation == null)
            {
                // No traversal, just set a property.
                return await _propertiesValueSetter.Set(valueName, structure, value, executionScope);
            }
            if (annotation.Path != null)
            {
                // @value(\#LastName) traversal set, i.e. a path to another node.
                return await _pathValueSetter.Set(valueName, (string) value, structure, annotation.Path, executionScope);
            }
            // @value() traversal set, i.e. no path but the node itself.
            return new Value(valueName, structure.Node.Type);
        }
    }
}