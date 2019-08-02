﻿namespace EtAlii.Ubigia.Api.Functional.Tests
{
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Functional.Diagnostics.Scripting;
    using EtAlii.Ubigia.Api.Logical;
    using EtAlii.Ubigia.Api.Logical.Tests;
    using EtAlii.xTechnology.Diagnostics;
    using Microsoft.CSharp.RuntimeBinder;
    using Xunit;

    public class ScriptProcessorRootedPathQueryTemporalIntegrationTests : IClassFixture<LogicalUnitTestContext>, IAsyncLifetime
    {
        private readonly LogicalUnitTestContext _testContext;
        private IScriptParser _parser;
        private IDiagnosticsConfiguration _diagnostics;
        private ILogicalContext _logicalContext;

        public ScriptProcessorRootedPathQueryTemporalIntegrationTests(LogicalUnitTestContext testContext)
        {
            _testContext = testContext;
        }

        public async Task InitializeAsync()
        {
            _diagnostics = TestDiagnostics.Create();
            var scriptParserConfiguration = new ScriptParserConfiguration()
                .UseFunctionalDiagnostics(_diagnostics);
            _parser = new ScriptParserFactory().Create(scriptParserConfiguration);
            _logicalContext = await _testContext.LogicalTestContext.CreateLogicalContext(true);
        }

        public Task DisposeAsync()
        {
            _parser = null;
            _logicalContext.Dispose();
            _logicalContext = null;
            return Task.CompletedTask;
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_RootedPath_Temporal_Downdate_01()
        {
            // Arrange.
            var addQueries = new[]
            {
                "Person:+=Doe/John",
                "Person:Doe/John <= { NickName: 'Joe' }",
                "Person:Doe/John <= { NickName: 'John' }",
            };

            var addQuery = string.Join("\r\n", addQueries);
            var selectQuery = "Person:Doe/John{";

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;

            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .UseFunctionalDiagnostics(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            await lastSequence.Output.ToArray();
            lastSequence = await processor.Process(selectScript);
            dynamic person = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(person);
            Assert.Equal("Joe", person.NickName);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_RootedPath_Temporal_Downdate_02()
        {
            // Arrange.
            var addQueries = new[]
            {
                "Person:+=Doe/John",
                "Person:Doe/John <= { NickName: 'Joe' }",
                "Person:Doe/John <= { NickName: 'Johnny' }",
                "Person:Doe/John <= { NickName: 'John' }",
            };

            var addQuery = string.Join("\r\n", addQueries);
            var selectQuery = "Person:Doe/John{{";

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;

            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .UseFunctionalDiagnostics(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            await lastSequence.Output.ToArray();
            lastSequence = await processor.Process(selectScript);
            var history = await lastSequence.Output.ToArray();

            // Assert.
            Assert.NotNull(history);
            Assert.Equal(4, history.Length);
            dynamic personHistory = history[0];
            Assert.Equal("John", personHistory.NickName);
            personHistory = history[1];
            Assert.Equal("Johnny", personHistory.NickName);
            personHistory = history[2];
            Assert.Equal("Joe", personHistory.NickName);
            personHistory = history[3];
            Assert.Throws<RuntimeBinderException>(() => personHistory.NickName); // The first entry does not have a NickName assigned.
        }


        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_RootedPath_Temporal_Downdate_03()
        {
            // Arrange.
            var addQueries = new[]
            {
                "Person:+=Doe/John",
                "Person:Doe/John <= { NickName: 'Joe' }",
                "Person:Doe/John <= { NickName: 'Johnny' }",
                "Person:Doe/John <= { NickName: 'John' }",
            };

            var addQuery = string.Join("\r\n", addQueries);
            var selectQuery = "Person:Doe/John{";

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;

            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .UseFunctionalDiagnostics(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            await lastSequence.Output.ToArray();
            lastSequence = await processor.Process(selectScript);
            dynamic person = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(person);
            Assert.Equal("Johnny", person.NickName);
        }
    }
}