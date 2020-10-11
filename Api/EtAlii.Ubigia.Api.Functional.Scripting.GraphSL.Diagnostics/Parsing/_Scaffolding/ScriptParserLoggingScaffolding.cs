﻿namespace EtAlii.Ubigia.Api.Functional.Scripting
{
    using EtAlii.xTechnology.Diagnostics;
    using EtAlii.xTechnology.MicroContainer;

    internal class ScriptParserLoggingScaffolding : IScaffolding
    {
        public void Register(Container container)
        {
            var diagnostics = container.GetInstance<IDiagnosticsConfiguration>();

            if (diagnostics.EnableLogging) // logging is enabled.
            {
                container.RegisterDecorator(typeof(IScriptParser), typeof(LoggingScriptParser));
            }

        }
    }
}
