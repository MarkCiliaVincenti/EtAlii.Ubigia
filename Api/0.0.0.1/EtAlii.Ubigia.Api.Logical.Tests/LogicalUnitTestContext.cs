﻿namespace EtAlii.Ubigia.Api.Logical.Tests
{
    using System.Threading.Tasks;
    using EtAlii.xTechnology.Diagnostics;
    using Ubigia.Tests;
    using Xunit;

    public class LogicalUnitTestContext : IAsyncLifetime
    {
        public ILogicalTestContext LogicalTestContext { get; private set; }
        public IDiagnosticsConfiguration Diagnostics { get; private set; }

        public FileComparer FileComparer { get; }
        public FolderComparer FolderComparer { get; }

        public LogicalUnitTestContext()
        {
            FileComparer = new FileComparer();
            FolderComparer = new FolderComparer(FileComparer);
        }

        public async Task InitializeAsync()
        {
            Diagnostics = TestDiagnostics.Create();
            LogicalTestContext = new LogicalTestContextFactory().Create();
            await LogicalTestContext.Start();
        }

        public async Task DisposeAsync()
        {
            await LogicalTestContext.Stop();
            LogicalTestContext = null;
            Diagnostics = null;
        }
    }
}