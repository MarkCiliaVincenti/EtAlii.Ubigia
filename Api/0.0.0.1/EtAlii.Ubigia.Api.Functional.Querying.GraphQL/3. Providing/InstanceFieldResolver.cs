﻿namespace EtAlii.Ubigia.Api.Functional.Querying.GraphQL
{
    using global::GraphQL.Resolvers;
    using global::GraphQL.Types;

    public class InstanceFieldResolver : IFieldResolver<object>
    {
        private readonly object _instance;

        public InstanceFieldResolver(object instance)
        {
            _instance = instance;
        }

        public object Resolve(ResolveFieldContext context)
        {
            return _instance;
        }

        object IFieldResolver.Resolve(ResolveFieldContext context)
        {
            return Resolve(context);
        }
    }
}