﻿namespace EtAlii.Ubigia.Api.Functional.Querying.GraphQL
{
    using System.Threading.Tasks;
    using EtAlii.Ubigia.Api.Logical;

    internal interface INodeFetcher
    {
        Task<IInternalNode> FetchAsync(string path);
    }
}