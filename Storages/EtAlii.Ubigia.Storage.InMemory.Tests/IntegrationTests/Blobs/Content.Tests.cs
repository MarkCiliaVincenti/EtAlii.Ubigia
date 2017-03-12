﻿namespace EtAlii.Ubigia.Storage.InMemory.Tests.IntegrationTests
{
    using EtAlii.Ubigia.Api;
    using EtAlii.Ubigia.Storage;
    using EtAlii.Ubigia.Storage.Tests;
    using EtAlii.Ubigia.Tests;
    using Xunit;
    using System;

    
    public class Content_Tests : InMemoryStorageTestBase
    {
        [Fact]
        public void Content_Store()
        {
            // Arrange.
            var containerId = StorageTestHelper.CreateSimpleContainerIdentifier();
            var content = TestContent.Create();

            // Act.
            Storage.Blobs.Store(containerId, content);

            // Assert.
        }

        [Fact]
        public void Content_Store_And_Retrieve_Check_Parts()
        {
            // Arrange.
            var containerId = StorageTestHelper.CreateSimpleContainerIdentifier();
            var content = TestContent.Create();

            // Act.
            Storage.Blobs.Store(containerId, content);
            var retrievedContent = Storage.Blobs.Retrieve<Content>(containerId);

            // Assert.
            AssertData.AreEqual(content, retrievedContent, false);
        }

        [Fact]
        public void Content_Store_Twice()
        {
            // Arrange.
            var containerId = StorageTestHelper.CreateSimpleContainerIdentifier();
            var first = TestContent.Create();
            var second = TestContent.Create();
            Storage.Blobs.Store(containerId, first);

            // Act.
            var act = new Action(() =>
            {
                Storage.Blobs.Store(containerId, second);
            });

            // Assert.
            ExceptionAssert.Throws<BlobStorageException>(act);
        }

        [Fact]
        public void Content_Retrieve_None_Existing()
        {
            // Arrange.
            var containerId = StorageTestHelper.CreateSimpleContainerIdentifier();

            // Act.
            var content = Storage.Blobs.Retrieve<Content>(containerId);

            // Assert.
            Assert.Null(content);
        }
    }
}
