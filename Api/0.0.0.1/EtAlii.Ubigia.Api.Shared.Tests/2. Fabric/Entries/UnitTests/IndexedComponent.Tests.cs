﻿namespace EtAlii.Ubigia.Api.Fabric.Tests
{
    using EtAlii.Ubigia.Api.Tests;
    using Xunit;

    
    public class IndexedComponent_Tests
    {
        [Fact, Trait("Category", TestAssembly.Category)]
        public void IndexedComponent_Create()
        {
            // Arrange.

            // Act.
            var indexedComponent = new IndexedComponent();

            // Assert.
            Assert.NotNull(indexedComponent);
            Assert.Equal(Relation.None, indexedComponent.Relation);
        }
    }
}
