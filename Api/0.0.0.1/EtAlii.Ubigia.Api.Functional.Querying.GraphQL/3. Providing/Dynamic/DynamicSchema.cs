﻿namespace EtAlii.Ubigia.Api.Functional.Querying.GraphQL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using global::GraphQL;
    using global::GraphQL.Execution;
    using global::GraphQL.Language.AST;
    using global::GraphQL.Types;
    using ISchema = global::GraphQL.Types.ISchema;

    public partial class DynamicSchema : Schema
    {
        private readonly List<IGraphType> _dynamicSchema = new List<IGraphType>();

        private readonly IStaticSchema _staticSchema;
        private readonly Document _document;
        private readonly IOperationProcessor _operationProcessor;
        private readonly Dictionary<Type, DynamicObjectGraphType> _graphObjectInstances;
                
        private readonly Type _baseClassType = typeof(DynamicObjectGraphType);

        private DynamicSchema(IStaticSchema staticSchema, Document document, IOperationProcessor operationProcessor)
            : base(staticSchema.DependencyResolver)
        {
            _staticSchema = staticSchema;
            _document = document;
            _operationProcessor = operationProcessor;
            
            _graphObjectInstances = new Dictionary<Type, DynamicObjectGraphType>();
            
            Query = staticSchema.Query;
            Mutation = staticSchema.Mutation;
            Directives = staticSchema.Directives;

            DependencyResolver = new FuncDependencyResolver(ResolveDynamicType);
        }

        private object ResolveDynamicType(Type type)
        {
            if (type.IsSubclassOf(_baseClassType))
            {
                return _graphObjectInstances[type];
            }

            return _staticSchema.DependencyResolver.Resolve(type);
        }

        internal static async Task<Schema> Create(ISchema originalSchema, IOperationProcessor operationProcessor, Document document)
        {
            var staticUbigiaSchema = (StaticSchema)originalSchema;

            var dynamicSchema = new DynamicSchema(staticUbigiaSchema, document, operationProcessor);
            await dynamicSchema.AddDynamicTypes();
            return dynamicSchema;
        }

        internal static async Task<Schema> Create(ISchema originalSchema, IOperationProcessor operationProcessor, string query)
        {
            var document = new GraphQLDocumentBuilder().Build(query);
            return await Create(originalSchema, operationProcessor, document);
        }
 
        private async Task AddDynamicTypes()
        {
            foreach (var operation in _document.Operations)
            {
                await _operationProcessor.Process(operation, Query, _graphObjectInstances);
            }
        }
    }
}
