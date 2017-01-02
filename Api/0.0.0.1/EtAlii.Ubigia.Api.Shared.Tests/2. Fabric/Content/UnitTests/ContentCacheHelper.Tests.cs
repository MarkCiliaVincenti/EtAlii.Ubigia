﻿namespace EtAlii.Ubigia.Api.Fabric.Tests
{
    using EtAlii.Ubigia.Api.Tests;
    using Xunit;

    
    public class ContentCacheHelper_Tests
    {
        [Fact, Trait("Category", TestAssembly.Category)]
        public void ContentCacheHelper_Create()
        {
            // Arrange.
            var cacheProvider = new ContentCacheProvider();

            // Act.
            var helper = new ContentCacheHelper(cacheProvider);

            // Assert.
            Assert.NotNull(helper);
        }
    }
}
