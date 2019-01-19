namespace EtAlii.Ubigia.Api.Functional
{
    using System.Threading.Tasks;

    internal class AssignEmptyToFunctionOperatorSubProcessor : IAssignEmptyToFunctionOperatorSubProcessor
    {
        private readonly IFunctionContext _functionContext;
        private readonly IParameterSetFinder _parameterSetFinder;
        private readonly IFunctionHandlerFinder _functionHandlerFinder;
        private readonly IArgumentSetFinder _argumentSetFinder;

        public AssignEmptyToFunctionOperatorSubProcessor(
            IFunctionSubjectParameterConverterSelector parameterConverterSelector,
            IFunctionContext functionContext, 
            IParameterSetFinder parameterSetFinder, 
            IFunctionHandlerFinder functionHandlerFinder, 
            IArgumentSetFinder argumentSetFinder)
        {
            _functionContext = functionContext;
            _parameterSetFinder = parameterSetFinder;
            _functionHandlerFinder = functionHandlerFinder;
            _argumentSetFinder = argumentSetFinder;
        }

        public async Task Assign(OperatorParameters parameters)
        {
            var functionSubject = (FunctionSubject)parameters.LeftSubject;

            // Find matching argument set.
            var argumentSet = _argumentSetFinder.Find(functionSubject);
            // Find function handler.
            var functionHandler = _functionHandlerFinder.Find(functionSubject);
            // And one single parameter set with the exact same parameters.
            var parameterSet = _parameterSetFinder.Find(functionSubject, functionHandler, argumentSet);

            await functionHandler.Process(_functionContext, parameterSet, argumentSet, parameters.RightInput, parameters.Scope, parameters.Output, false);
        }
    }
}