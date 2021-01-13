﻿namespace EtAlii.Ubigia.Api.Functional.Context
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Functional.Traversal;

    internal class GraphContext : IGraphContext
    {
        private readonly ISchemaProcessorFactory _schemaProcessorFactory;
        private readonly ISchemaParserFactory _schemaParserFactory;
        private readonly ITraversalContext _traversalContext;

        public GraphContext(
            ISchemaProcessorFactory schemaProcessorFactory,
            ISchemaParserFactory schemaParserFactory,
            ITraversalContext traversalContext)
        {
            _schemaProcessorFactory = schemaProcessorFactory;
            _schemaParserFactory = schemaParserFactory;
            _traversalContext = traversalContext;
        }

        public SchemaParseResult Parse(string text)
        {
            var queryParserConfiguration = new SchemaParserConfiguration()
                .Use(_traversalContext.PathParserFactory);
                //.Use(_logicalContext.Configuration)
                //.Use(_diagnostics)
            var parser = _schemaParserFactory.Create(queryParserConfiguration);
            return parser.Parse(text);
        }

        public Task<SchemaProcessingResult> Process(Schema schema, ISchemaScope scope)
        {
            var configuration = new SchemaProcessorConfiguration()
                .Use(scope)
                .Use(_traversalContext);
            var processor = _schemaProcessorFactory.Create(configuration);
            return processor.Process(schema);
        }

        public Task<SchemaProcessingResult> Process(string[] text, ISchemaScope scope)
        {
            var queryParseResult = Parse(string.Join(Environment.NewLine, text));

            if (queryParseResult.Errors.Any())
            {
                var firstError = queryParseResult.Errors.First();
                throw new SchemaParserException(firstError.Message, firstError.Exception);
            }

            return Process(queryParseResult.Schema, scope);
        }


        public Task<SchemaProcessingResult> Process(string text, params object[] args)
        {
            text = string.Format(text, args);
            return Process(text);
        }

        public Task<SchemaProcessingResult> Process(string[] text)
        {
            return Process(string.Join(Environment.NewLine, text));
        }

        public Task<SchemaProcessingResult> Process(string text)
        {
            var queryParseResult = Parse(text);

            if (queryParseResult.Errors.Any())
            {
                var firstError = queryParseResult.Errors.First();
                throw new SchemaParserException(firstError.Message, firstError.Exception);
            }

            var scope = new SchemaScope();

            return Process(queryParseResult.Schema, scope);
        }
    }
}
