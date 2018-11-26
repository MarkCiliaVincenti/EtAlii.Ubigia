﻿namespace EtAlii.Ubigia.Api.Functional.Querying.GraphQL
{
    using System.Collections.Generic;
    using global::GraphQL.Types;
    using System.Threading.Tasks;
    using global::GraphQL.Language.AST;

    internal interface INodesFieldAdder
    {
        void Add(
            string name,
            NodesDirectiveResult[] nodesDirectiveResults, 
            Registration registration, 
            ComplexGraphType<object> parent, 
            Dictionary<System.Type, GraphType> graphTypes);
    }
}