﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Functional.Traversal.Tests
{
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Logical;
    using Xunit;

    public class ScriptProcessorLogicalRemoveTests : IClassFixture<TraversalUnitTestContext>
    {
        private readonly TraversalUnitTestContext _testContext;
        private readonly IScriptParser _parser;

        public ScriptProcessorLogicalRemoveTests(TraversalUnitTestContext testContext)
        {
            _testContext = testContext;
            _parser = new TestScriptParserFactory().Create(testContext.ClientConfiguration);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Logical_Remove_1()
        {
            // Arrange.
            var functionalScope = new ExecutionScope(false);
            using var logicalContext = await _testContext.Logical
                .CreateLogicalContext(true)
                .ConfigureAwait(false);
            var root = await logicalContext.Roots
                .Get("Person")
                .ConfigureAwait(false);
            var entry = await logicalContext.Nodes
                .SelectSingle(GraphPath.Create(root.Identifier), functionalScope)
                .ConfigureAwait(false);
            await _testContext.Logical
                .CreateHierarchy(logicalContext, (IEditableEntry)entry, "LastName", "SurName")
                .ConfigureAwait(false);
            var selectQuery = "<= /Person/LastName/";
            var selectScript = _parser.Parse(selectQuery).Script;
            var processor = _testContext.CreateScriptProcessor(logicalContext);
            var lastSequence = await processor.Process(selectScript);
            dynamic beforeResult = await lastSequence.Output.SingleOrDefaultAsync();
            var removeScript = _parser.Parse("/Person/LastName -= SurName").Script;

            // Act.
            lastSequence = await processor.Process(removeScript);
            await lastSequence.Output.ToArray();
            lastSequence = await processor.Process(selectScript);
            dynamic afterResult = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(beforeResult);
            Assert.NotEqual(Identifier.Empty, ((Node)beforeResult).Id);
            Assert.Null(afterResult);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Logical_Remove_2()
        {
            // Arrange.
            var functionalScope = new ExecutionScope(false);
            using var logicalContext = await _testContext.Logical
                .CreateLogicalContext(true)
                .ConfigureAwait(false);
            var root = await logicalContext.Roots
                .Get("Person")
                .ConfigureAwait(false);
            var entry = await logicalContext.Nodes
                .SelectSingle(GraphPath.Create(root.Identifier), functionalScope)
                .ConfigureAwait(false);
            await _testContext.Logical
                .CreateHierarchy(logicalContext, (IEditableEntry)entry, "LastName", "SurName")
                .ConfigureAwait(false);
            var selectQuery = "<= /Person/LastName/";
            var selectScript = _parser.Parse(selectQuery).Script;
            var processor = _testContext.CreateScriptProcessor(logicalContext);
            var lastSequence = await processor.Process(selectScript);
            dynamic beforeResult = await lastSequence.Output.SingleOrDefaultAsync();

            // Act.
            var removeScript = _parser.Parse("/Person/LastName -= /SurName").Script;
            lastSequence = await processor.Process(removeScript);
            await lastSequence.Output.ToArray();
            lastSequence = await processor.Process(selectScript);
            dynamic afterResult = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(beforeResult);
            Assert.NotEqual(Identifier.Empty, ((Node)beforeResult).Id);
            Assert.Null(afterResult);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Logical_Remove_With_Variable_1()
        {
            // Arrange.
            var functionalScope = new ExecutionScope(false);
            using var logicalContext = await _testContext.Logical
                .CreateLogicalContext(true)
                .ConfigureAwait(false);
            var root = await logicalContext.Roots
                .Get("Person")
                .ConfigureAwait(false);
            var entry = await logicalContext.Nodes
                .SelectSingle(GraphPath.Create(root.Identifier), functionalScope)
                .ConfigureAwait(false);
            await _testContext.Logical
                .CreateHierarchy(logicalContext, (IEditableEntry)entry, "LastName", "SurName")
                .ConfigureAwait(false);
            var selectQuery = "<= /Person/LastName/";
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new FunctionalScope();
            var processor = _testContext.CreateScriptProcessor(logicalContext, scope);
            var lastSequence = await processor.Process(selectScript);
            dynamic beforeResult = await lastSequence.Output.SingleOrDefaultAsync();

            // Act.
            var removeScript = _parser.Parse("/Person/LastName -= $var").Script;
            scope.Variables["var"] = new ScopeVariable("SurName", "Variable");
            lastSequence = await processor.Process(removeScript);
            await lastSequence.Output.ToArray();
            lastSequence = await processor.Process(selectScript);
            dynamic afterResult = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(beforeResult);
            Assert.NotEqual(Identifier.Empty, ((Node)beforeResult).Id);
            Assert.Null(afterResult);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Logical_Remove_With_Variable_2()
        {
            // Arrange.
            var functionalScope = new ExecutionScope(false);
            using var logicalContext = await _testContext.Logical
                .CreateLogicalContext(true)
                .ConfigureAwait(false);
            var root = await logicalContext.Roots
                .Get("Person")
                .ConfigureAwait(false);
            var entry = await logicalContext.Nodes
                .SelectSingle(GraphPath.Create(root.Identifier), functionalScope)
                .ConfigureAwait(false);
            await _testContext.Logical
                .CreateHierarchy(logicalContext, (IEditableEntry)entry, "LastName", "SurName")
                .ConfigureAwait(false);
            var selectQuery = "<= /Person/LastName/";
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new FunctionalScope();
            var processor = _testContext.CreateScriptProcessor(logicalContext, scope);
            var lastSequence = await processor.Process(selectScript);
            dynamic beforeResult = await lastSequence.Output.SingleOrDefaultAsync();

            // Act.
            var removeScript = _parser.Parse("$var <= \"SurName\"\r\n/Person/LastName -= $var").Script;
            scope.Variables["var"] = new ScopeVariable("SurName", "Variable");
            lastSequence = await processor.Process(removeScript);
            await lastSequence.Output.ToArray();
            lastSequence = await processor.Process(selectScript);
            dynamic afterResult = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(beforeResult);
            Assert.NotEqual(Identifier.Empty, ((Node)beforeResult).Id);
            Assert.Null(afterResult);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Logical_Remove_With_Variable_3()
        {
            // Arrange.
            var functionalScope = new ExecutionScope(false);
            using var logicalContext = await _testContext.Logical
                .CreateLogicalContext(true)
                .ConfigureAwait(false);
            var root = await logicalContext.Roots
                .Get("Person")
                .ConfigureAwait(false);
            var entry = await logicalContext.Nodes
                .SelectSingle(GraphPath.Create(root.Identifier), functionalScope)
                .ConfigureAwait(false);
            await _testContext.Logical.CreateHierarchy(logicalContext, (IEditableEntry)entry, "LastName", "SurName").ConfigureAwait(false);
            var selectQuery = "<= /Person/LastName/";
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new FunctionalScope();
            var processor = _testContext.CreateScriptProcessor(logicalContext, scope);
            var lastSequence = await processor.Process(selectScript);
            dynamic beforeResult = await lastSequence.Output.SingleOrDefaultAsync();

            // Act.
            var removeScript = _parser.Parse("$var <= /Person/LastName/SurName\r\n/Person/LastName -= $var").Script;
            scope.Variables["var"] = new ScopeVariable("SurName", "Variable");
            lastSequence = await processor.Process(removeScript);
            await lastSequence.Output.ToArray();
            lastSequence = await processor.Process(selectScript);
            dynamic afterResult = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(beforeResult);
            Assert.NotEqual(Identifier.Empty, ((Node)beforeResult).Id);
            Assert.Null(afterResult);
        }
    }
}
