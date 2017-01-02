﻿namespace EtAlii.Ubigia.Api.Functional.Tests
{
    using System;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Diagnostics.Tests;
    using EtAlii.Ubigia.Api.Logical;
    using EtAlii.Ubigia.Api.Logical.Tests;
    using EtAlii.Ubigia.Api.Tests;
    using EtAlii.Ubigia.Tests;
    using EtAlii.xTechnology.Diagnostics;
    using Xunit;
    using TestAssembly = EtAlii.Ubigia.Api.Tests.TestAssembly;

    
    public class ScriptProcessor_Scripted_Add_Tests : IClassFixture<LogicalUnitTestContext>, IDisposable
    {
        private IScriptParser _parser;
        private IDiagnosticsConfiguration _diagnostics;
        private ILogicalContext _logicalContext;
        private readonly LogicalUnitTestContext _testContext;

        public ScriptProcessor_Scripted_Add_Tests(LogicalUnitTestContext testContext)
        {
            _testContext = testContext;
            var task = Task.Run(async () =>
            {
                _diagnostics = TestDiagnostics.Create();
                var scriptParserConfiguration = new ScriptParserConfiguration()
                    .Use(_diagnostics);
                _parser = new ScriptParserFactory().Create(scriptParserConfiguration);
                _logicalContext = await _testContext.LogicalTestContext.CreateLogicalContext(true);
            });
            task.Wait();
        }

        public void Dispose()
        {
            var task = Task.Run(() =>
            {
                _parser = null;
                _logicalContext.Dispose();
                _logicalContext = null;
            });
            task.Wait();
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Add_Simple()
        {
            var continent = "Europe";

            // Arrange.
            var addQueries = new[]
            {
                $"/Locations+=/{continent}",
                $"<= /Locations/{continent}"
            };

            var addQuery = String.Join("\r\n", addQueries);
            var selectQuery = $"<= /Locations/{continent}";

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstContinentEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondContinentEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(firstContinentEntry);
            Assert.NotNull(secondContinentEntry);
            Assert.Equal(((INode)firstContinentEntry).Id, ((INode)secondContinentEntry).Id);
            Assert.Equal(continent, firstContinentEntry.ToString());
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Add_1()
        {
            // Arrange.
            var continent = "Europe";
            var country = "NL";
            var region = "Overijssel";
            var city = "Enschede";
            var location = "Helmerhoek";

            var addQueries = new[]
            {
                $"/Locations+=/{continent}",
                $"/Locations/{continent}+=/{country}",
                $"/Locations/{continent}/{country}+=/{region}",
                $"/Locations/{continent}/{country}/{region}+=/{city}",
                $"<= /Locations/{continent}/{country}/{region}/{city}+=/{location}"
            };

            var addQuery = String.Join("\r\n", addQueries);
            var selectQuery = $"<= /Locations/{continent}/{country}/{region}/{city}/{location}";

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstLocationEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondLocationEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(firstLocationEntry);
            Assert.NotNull(secondLocationEntry);
            Assert.Equal(((INode)firstLocationEntry).Id, ((INode)secondLocationEntry).Id);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Add_2()
        {
            // Arrange.
            var now = DateTime.Now;
            var addQueries = new[]
            {
                "/Time+=/{0:yyyy}",
                "/Time/{0:yyyy}+=/{0:MM}",
                "/Time/{0:yyyy}/{0:MM}+=/{0:dd}",
                "/Time/{0:yyyy}/{0:MM}/{0:dd}+=/{0:HH}",
                "/Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}+=/{0:mm}",
                "<= /Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}",
            };

            var addQuery = String.Format(String.Join("\r\n", addQueries), now);
            var selectQuery = String.Format("<= /Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}", now);

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstMinuteEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondMinuteEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(firstMinuteEntry);
            Assert.NotNull(secondMinuteEntry);
            Assert.Equal(((INode)firstMinuteEntry).Id, ((INode)secondMinuteEntry).Id);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Add_3()
        {
            // Arrange.
            var now = DateTime.Now;
            var addQueries = new[]
            {
                "/Time+=/{0:yyyy}",
                "/Time/{0:yyyy}+=/{0:MM}",
                "/Time/{0:yyyy}/{0:MM}+=/{0:dd}",
                "/Time/{0:yyyy}/{0:MM}/{0:dd}+=/{0:HH}",
                "/Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}+=/{0:mm}",
                "<= /Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}"
            };

            var addQuery = String.Format(String.Join("\r\n", addQueries), now);
            var selectQuery = String.Format("/Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}", now);

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstMinuteEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondMinuteEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(firstMinuteEntry);
            Assert.NotNull(secondMinuteEntry);
            Assert.Equal(((INode)firstMinuteEntry).Id, ((INode)secondMinuteEntry).Id);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Add_4()
        {
            // Arrange.
            var now = DateTime.Now;
            var addQueries = new[]
            {
                "/Time+=/{0:yyyy}",
                "/Time/{0:yyyy}+=/{0:MM}",
                "/Time/{0:yyyy}/{0:MM}+=/{0:dd}",
                "/Time/{0:yyyy}/{0:MM}/{0:dd}+=/{0:HH}",
                "/Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}+=/{0:mm}",
                "/Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}",
            };

            var addQuery = String.Format(String.Join("\r\n", addQueries), now);
            var selectQuery = String.Format("<= /Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}", now);

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstMinuteEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondMinuteEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(firstMinuteEntry);
            Assert.NotNull(secondMinuteEntry);
            Assert.Equal(((INode)firstMinuteEntry).Id, ((INode)secondMinuteEntry).Id);
        }


        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Add_At_Once_1()
        {
            // Arrange.
            var continent = "Europe";
            var country = "NL";
            var region = "Overijssel";
            var city = "Enschede";
            var location = "Helmerhoek";

            var addQueries = new[]
            {
                $"<= /Locations+=/{continent}/{country}/{region}/{city}/{location}"
            };

            var addQuery = String.Join("\r\n", addQueries);
            var selectQuery = $"<= /Locations/{continent}/{country}/{region}/{city}/{location}";

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstLocationEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondLocationEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(firstLocationEntry);
            Assert.NotNull(secondLocationEntry);
            Assert.Equal(((INode)firstLocationEntry).Id, ((INode)secondLocationEntry).Id);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Add_At_Once_2()
        {
            // Arrange.
            var now = DateTime.Now;
            var addQueries = new[]
            {
                "/Time+=/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}",
                "<= /Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}",
            };

            var addQuery = String.Format(String.Join("\r\n", addQueries), now);
            var selectQuery = String.Format("<= /Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}", now);

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstMinuteEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondMinuteEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(firstMinuteEntry);
            Assert.NotNull(secondMinuteEntry);
            Assert.Equal(((INode)firstMinuteEntry).Id, ((INode)secondMinuteEntry).Id);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Add_At_Once_3()
        {
            // Arrange.
            var now = DateTime.Now;
            var addQueries = new[]
            {
                "/Time+=/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}",
                "/Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}",
            };

            var addQuery = String.Format(String.Join("\r\n", addQueries), now);
            var selectQuery = String.Format("<= /Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}", now);

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstMinuteEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondMinuteEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(firstMinuteEntry);
            Assert.NotNull(secondMinuteEntry);
            Assert.Equal(((INode)firstMinuteEntry).Id, ((INode)secondMinuteEntry).Id);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Add_At_Once_4()
        {
            // Arrange.
            var now = DateTime.Now;
            var addQueries = new[]
            {
                "/Time+=/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}",
                "<= /Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}",
            };

            var addQuery = String.Format(String.Join("\r\n", addQueries), now);
            var selectQuery = String.Format("/Time/{0:yyyy}/{0:MM}/{0:dd}/{0:HH}/{0:mm}", now);

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstMinuteEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondMinuteEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(firstMinuteEntry);
            Assert.NotNull(secondMinuteEntry);
            Assert.Equal(((INode)firstMinuteEntry).Id, ((INode)secondMinuteEntry).Id);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Add_Spaced_1()
        {
            // Arrange.
            var continent = "Europe";
            var country = "NL";
            var region = "Overijssel";
            var city = "Enschede";
            var location = "Helmerhoek";

            var addQueries = new[]
            {
                $"/Locations +=/{continent}",
                $"/Locations/{continent} +=/{country}",
                $"/Locations/{continent}/{country} +=/{region}",
                $"/Locations/{continent}/{country}/{region} +=/{city}",
                $"<= /Locations/{continent}/{country}/{region}/{city} +=/{location}",
            };

            var addQuery = String.Join("\r\n", addQueries);
            var selectQuery = $"/Locations/{continent}/{country}/{region}/{city}/{location}";

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstLocationEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondLocationEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(firstLocationEntry);
            Assert.NotNull(secondLocationEntry);
            Assert.Equal(((INode)firstLocationEntry).Id, ((INode)secondLocationEntry).Id);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Add_Spaced_2()
        {
            // Arrange.
            var continent = "Europe";
            var country = "NL";
            var region = "Overijssel";
            var city = "Enschede";
            var location = "Helmerhoek";

            var addQueries = new[]
            {
                $"/Locations+= /{continent}",
                $"/Locations/{continent}+= /{country}",
                $"/Locations/{continent}/{country}+= /{region}",
                $"/Locations/{continent}/{country}/{region}+= /{city}",
                $"<= /Locations/{continent}/{country}/{region}/{city}+= /{location}",
            };

            var addQuery = String.Join("\r\n", addQueries);
            var selectQuery = $"/Locations/{continent}/{country}/{region}/{city}/{location}";

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstLocationEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondLocationEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(firstLocationEntry);
            Assert.NotNull(secondLocationEntry);
            Assert.Equal(((INode)firstLocationEntry).Id, ((INode)secondLocationEntry).Id);
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Advanced_Add_Tree_At_Once()
        {
            // Arrange.
            var addQuery = "<= /Person+=/Doe/John";
            var selectQuery = "/Person/Doe/John";

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstJohnEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondJohnEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(firstJohnEntry);
            Assert.NotNull(secondJohnEntry);
            Assert.Equal(((INode)firstJohnEntry).Id, ((INode)secondJohnEntry).Id);

        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Advanced_Add_Tree_At_Once_From_Root_NonSpaced_01()
        {
            // Arrange.
            var addQuery = "+=/Person/Doe/John";
            var selectQuery = "/Person/Doe/John";

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstJohnEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondJohnEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.Null(firstJohnEntry);//, "First entry is not null");
            Assert.NotNull(secondJohnEntry);//, "Second entry is null");
            Assert.Equal("John", secondJohnEntry.ToString());
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Advanced_Add_Tree_At_Once_From_Root_Spaced_02()
        {
            // Arrange.
            var addQuery = "+= /Person/Doe/John";
            var selectQuery = "/Person/Doe/John";

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstJohnEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondJohnEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.Null(firstJohnEntry);//, "First entry is not null");
            Assert.NotNull(secondJohnEntry);//, "Second entry is null");
            Assert.Equal("John", secondJohnEntry.ToString());
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Advanced_Add_Tree_At_Once_From_Root_Wrong_Root()
        {
            // Arrange.
            var addQuery = "+=/Person_Bad/Doe/John";

            var addScript = _parser.Parse(addQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var act = processor.Process(addScript);

            // Assert.
            await ExceptionAssert.ThrowsObservable<ScriptProcessingException, SequenceProcessingResult>(act); 
        }

        [Fact, Trait("Category", TestAssembly.Category)]
        public async Task ScriptProcessor_Scripted_Advanced_Add_Tree_At_Once_Spaced()
        {
            // Arrange.
            var addQuery = "<= /Person += /Doe/John";
            var selectQuery = "/Person/Doe/John";

            var addScript = _parser.Parse(addQuery).Script;
            var selectScript = _parser.Parse(selectQuery).Script;
            var scope = new ScriptScope();
            var configuration = new ScriptProcessorConfiguration()
                .Use(_diagnostics)
                .Use(scope)
                .Use(_logicalContext);
            var processor = new ScriptProcessorFactory().Create(configuration);

            // Act.
            var lastSequence = await processor.Process(addScript);
            dynamic firstJohnEntry = await lastSequence.Output.SingleOrDefaultAsync();
            lastSequence = await processor.Process(selectScript);
            dynamic secondJohnEntry = await lastSequence.Output.SingleOrDefaultAsync();

            // Assert.
            Assert.NotNull(firstJohnEntry);
            Assert.NotNull(secondJohnEntry);
            Assert.Equal(((INode)firstJohnEntry).Id, ((INode)secondJohnEntry).Id);
        }
    }
}