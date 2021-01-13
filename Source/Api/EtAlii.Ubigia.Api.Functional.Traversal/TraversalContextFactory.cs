﻿namespace EtAlii.Ubigia.Api.Functional.Traversal
{
    using EtAlii.xTechnology.MicroContainer;
    using System;

    public class TraversalContextFactory : Factory<ITraversalContext, TraversalContextConfiguration, ITraversalContextExtension>
    {
        protected override IScaffolding[] CreateScaffoldings(TraversalContextConfiguration configuration)
        {
            // Let's ensure that the function handler configuration is in fact valid.
            var functionHandlersProvider = configuration.FunctionHandlersProvider;
            var functionHandlerValidator = new FunctionHandlerValidator();
            functionHandlerValidator.Validate(functionHandlersProvider);

            // Let's ensure that the root handler configuration is in fact valid.
            var rootHandlerMappersProvider = configuration.RootHandlerMappersProvider;
            var rootHandlerMapperValidator = new RootHandlerMapperValidator();
            rootHandlerMapperValidator.Validate(rootHandlerMappersProvider);

            if (configuration.ParserConfiguration == null)
            {
                throw new InvalidOperationException($"No {nameof(configuration.ParserConfiguration)} specified");
            }

            var parserConfiguration = configuration.ParserConfiguration;

            if (configuration.ProcessorConfiguration == null)
            {
                throw new InvalidOperationException($"No {nameof(configuration.ProcessorConfiguration)} specified");
            }

            var processorConfiguration = configuration.ProcessorConfiguration;

            return new IScaffolding[]
            {
                new TraversalContextScaffolding(configuration, parserConfiguration, processorConfiguration, functionHandlersProvider, rootHandlerMappersProvider),
            };
        }
    }
}
