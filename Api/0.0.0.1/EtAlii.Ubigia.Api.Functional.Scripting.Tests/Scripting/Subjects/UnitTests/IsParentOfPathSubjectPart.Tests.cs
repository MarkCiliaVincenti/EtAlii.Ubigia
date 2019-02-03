﻿namespace EtAlii.Ubigia.Api.Functional.Tests
{
    using System;
    using EtAlii.Ubigia.Api.Functional.Diagnostics.Scripting;
    using Xunit;


    public class ParentPathSubjectPartTests : IDisposable
    {
        private IScriptParser _parser;

        public ParentPathSubjectPartTests()
        {
            var diagnostics = TestDiagnostics.Create();
            var scriptParserConfiguration = new ScriptParserConfiguration()
                .Use(diagnostics);
            _parser = new ScriptParserFactory().Create(scriptParserConfiguration);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Cleanup
            if (disposing)
            {
                _parser = null;
            }
        }

        ~ParentPathSubjectPartTests()
        {
            Dispose(false);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public void ParentPathSubjectPart_ToString()
        {
            // Arrange.
            var part = new ParentPathSubjectPart();

            // Act.
            var result = part.ToString();

            // Assert.
            Assert.Equal("/", result);
        }
    }
}