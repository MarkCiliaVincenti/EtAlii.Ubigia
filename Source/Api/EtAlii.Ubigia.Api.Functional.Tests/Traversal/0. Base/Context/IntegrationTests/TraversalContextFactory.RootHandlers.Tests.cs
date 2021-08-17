﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Functional.Traversal.Tests
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class TraversalContextFactoryRootHandlersTests : IClassFixture<TraversalUnitTestContext>
    {
        private readonly TraversalUnitTestContext _testContext;

        public TraversalContextFactoryRootHandlersTests(TraversalUnitTestContext testContext)
        {
            _testContext = testContext;
        }


        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task TraversalContextFactory_Create()
        {
            // Arrange.
            var options = await new FunctionalOptions(_testContext.ClientConfiguration)
                .UseTestParsing()
                .UseDataConnectionToNewSpace(_testContext, true)
                .ConfigureAwait(false);

            // Act.
            var scriptContext = new TraversalContextFactory().Create(options);

            // Assert.
            Assert.NotNull(scriptContext);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task TraversalContextFactory_Create_With_RootHandler_None()
        {
            // Arrange.
            var options = await new FunctionalOptions(_testContext.ClientConfiguration)
                .UseTestParsing()
                .UseDataConnectionToNewSpace(_testContext, true)
                .ConfigureAwait(false);

            // Act.
            var scriptContext = new TraversalContextFactory().Create(options);

            // Assert.
            Assert.NotNull(scriptContext);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task TraversalContextFactory_Create_With_RootHandler_Single()
        {
            // Arrange.
            var rootHandlerMappers = new IRootHandlerMapper[] { new TestRootHandlerMapper() };
            var rootHandlerMappersProvider = new RootHandlerMappersProvider(rootHandlerMappers);

            var options = await new FunctionalOptions(_testContext.ClientConfiguration)
                .UseTestParsing()
                .Use(rootHandlerMappersProvider)
                .UseDataConnectionToNewSpace(_testContext, true)
                .ConfigureAwait(false);

            // Act.
            var scriptContext = new TraversalContextFactory().Create(options);

            // Assert.
            Assert.NotNull(scriptContext);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task TraversalContextFactory_Create_With_RootHandler_Single_Invalid()
        {
            // Arrange.
            var rootHandlerMappers = new IRootHandlerMapper[] { new InvalidTestRootHandlerMapper() };
            var rootHandlerMappersProvider = new RootHandlerMappersProvider(rootHandlerMappers);

            var options = await new FunctionalOptions(_testContext.ClientConfiguration)
                .UseTestParsing()
                .Use(rootHandlerMappersProvider)
                .UseDataConnectionToNewSpace(_testContext, true)
                .ConfigureAwait(false);

            // Act.
            var act = new Action(() =>
            {
                new TraversalContextFactory().Create(options);
            });

            // Assert.
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task TraversalContextFactory_Create_With_RootHandler_Multiple()
        {
            // Arrange.
            var rootHandlerMappers = new IRootHandlerMapper[]
            {
                new TestRootHandlerMapper(),
                new TestRoot2HandlerMapper()
            };
            var rootHandlerMappersProvider = new RootHandlerMappersProvider(rootHandlerMappers);

            var options = await new FunctionalOptions(_testContext.ClientConfiguration)
                .UseTestParsing()
                .Use(rootHandlerMappersProvider)
                .UseDataConnectionToNewSpace(_testContext, true)
                .ConfigureAwait(false);

            // Act.
            var scriptContext = new TraversalContextFactory().Create(options);

            // Assert.
            Assert.NotNull(scriptContext);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task TraversalContextFactory_Create_With_RootHandler_Multiple_Invalid()
        {
            // Arrange.
            var rootHandlerMappers = new IRootHandlerMapper[]
            {
                new TestRootHandlerMapper(),
                new TestRootHandlerMapper()
            };
            var rootHandlerMappersProvider = new RootHandlerMappersProvider(rootHandlerMappers);

            var options = await new FunctionalOptions(_testContext.ClientConfiguration)
                .UseTestParsing()
                .Use(rootHandlerMappersProvider)
                .UseDataConnectionToNewSpace(_testContext, true)
                .ConfigureAwait(false);

            // Act.
            var act = new Action(() =>
            {
                new TraversalContextFactory().Create(options);
            });

            // Assert.
            Assert.Throws<InvalidOperationException>(act);
        }
    }
}
