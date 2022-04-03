// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.xTechnology.Hosting.Tests.Local
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public class System2HostTestContextNetCoreTests : IClassFixture<UnitTestContext<System2RestHostTestContext>>
    {
        private readonly UnitTestContext<System2RestHostTestContext> _context;

        public System2HostTestContextNetCoreTests(UnitTestContext<System2RestHostTestContext> context)
        {
            _context = context;
        }

        [Fact]
        public async Task System2HostTestContextNetCore_User_Api_Get_1()
        {
            // Arrange.
            var port = _context.Host.Ports[TestPort.RestUserApi];
            var path = _context.Host.Paths[TestPath.RestUserApi];

            // Act.
            using var client = _context.Host.CreateClient();
            var result = await client.GetAsync($"https://localhost:{port}{path}/data").ConfigureAwait(false);

            // Assert.
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            var content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.StartsWith("UserController_", content);
        }

        [Fact]
        public async Task System2HostTestContextNetCore_User_Api_Get_2()
        {
            // Arrange.
            var port = _context.Host.Ports[TestPort.RestUserApi];
            var path = _context.Host.Paths[TestPath.RestUserApi];
            var tick = Environment.TickCount;

            // Act.
            using var client = _context.Host.CreateClient();
            var result = await client.GetAsync($"https://localhost:{port}{path}/data/GetComplex?postfix={tick}").ConfigureAwait(false);

            // Assert.
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            var content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.StartsWith($"UserController_{tick}", content);
        }
    }
}
