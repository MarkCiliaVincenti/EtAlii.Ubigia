﻿namespace EtAlii.Servus.Api.Data
{
    using Remotion.Linq;
    using Remotion.Linq.Parsing.Structure;
    using System.Linq;
    using System.Linq.Expressions;

    public class RootQueryProvider : QueryProviderBase
    {
        public RootQueryProvider(IQueryParser queryParser, IQueryExecutor queryExecutor)
            : base(queryParser, queryExecutor)
        {
        }

        public override IQueryable<T> CreateQuery<T>(Expression expression)
        {
            return new Queryable<T>(this, expression);
        } 
    }
}