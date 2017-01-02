namespace EtAlii.Servus.Api.Diagnostics.Profiling
{
    using EtAlii.Servus.Api.Functional;
    using EtAlii.xTechnology.MicroContainer;

    public class ProfilingScriptProcessorExtension : IScriptProcessorExtension
    {
        private readonly IProfiler _profiler;

        public ProfilingScriptProcessorExtension(IProfiler profiler)
        {
            _profiler = profiler;
        }

        public void Initialize(Container container)
        {
            container.Register<IProfiler>(() => _profiler);
            container.RegisterDecorator(typeof(IScriptProcessor), typeof(ProfilingScriptProcessor));
            //container.RegisterDecorator(typeof(ISequenceProcessor), typeof(ProfilingSequenceProcessor));

            //container.RegisterDecorator(typeof(IOperatorsProcessor2), typeof(ProfilingOperatorsProcessor));
            //container.RegisterDecorator(typeof(ISubjectsProcessor2), typeof(ProfilingSubjectsProcessor));
            //container.RegisterDecorator(typeof(ICommentProcessor2), typeof(ProfilingCommentProcessor));

            container.RegisterDecorator(typeof(IPathSubjectProcessor), typeof(ProfilingPathSubjectProcessor));
            container.RegisterDecorator(typeof(IPathSubjectToGraphPathConverter), typeof(ProfilingPathSubjectToGraphPathConverter));
            container.RegisterDecorator(typeof(IPathProcessor), typeof(ProfilingPathProcessor));

            container.RegisterDecorator(typeof(IEntriesToDynamicNodesConverter), typeof(ProfilingEntriesToDynamicNodesConverter));

            container.RegisterDecorator(typeof(IPathSubjectForOutputConverter), typeof(ProfilingPathSubjectForOutputConverter));
            //container.RegisterDecorator(typeof(IPathSubjectForFunctionAssignmentOperationConverter2), typeof(ProfilingPathSubjectForFunctionAssignmentOperationConverter));
            //container.RegisterDecorator(typeof(IPathSubjectForPathAddOperationConverter2), typeof(ProfilingPathSubjectForPathAddOperationConverter));
            //container.RegisterDecorator(typeof(IPathSubjectForPathAssignmentOperationConverter2), typeof(ProfilingPathSubjectForPathAssignmentOperationConverter));
            //container.RegisterDecorator(typeof(IPathSubjectForPathRemoveOperationConverter2), typeof(ProfilingPathSubjectForPathRemoveOperationConverter));
            //container.RegisterDecorator(typeof(IPathSubjectForVariableAddOperationConverter2), typeof(ProfilingPathSubjectForVariableAddOperationConverter));
            //container.RegisterDecorator(typeof(IPathSubjectForVariableAssignmentOperationConverter2), typeof(ProfilingPathSubjectForVariableAssignmentOperationConverter));
        }
    }
}