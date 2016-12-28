﻿namespace EtAlii.Servus.Api.Functional.Tests
{
    internal class TestRootHandlerMapper : IRootHandlerMapper
    {
        public string Name { get { return _name; } }
        private readonly string _name;

        public IRootHandler[] AllowedRootHandlers { get; }

        public TestRootHandlerMapper()
        {
            _name = "TestRoot";
            AllowedRootHandlers = new IRootHandler[0];
        }
    }
}
