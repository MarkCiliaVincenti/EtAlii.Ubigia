﻿// Copyright (c) Peter Vrenken. All rights reserved. See License.txt in the project root for license information.

namespace EtAlii.Servus.Api.Functional
{
    using EtAlii.xTechnology.MicroContainer;

    internal class PathBuildingScaffolding : IScaffolding
    {
        public void Register(Container container)
        {
            container.Register<IPathSubjectPartToGraphPathPartConverterSelector, PathSubjectPartToGraphPathPartConverterSelector>();
            container.Register<IConstantPathSubjectPartToGraphPathPartsConverter, ConstantPathSubjectPartToGraphPathPartsConverter>();
            container.Register<IWildcardPathSubjectPartToGraphPathPartsConverter, WildcardPathSubjectPartToGraphPathPartsConverter>();
            container.Register<ITraversingWildcardPathSubjectPartToGraphPathPartsConverter, TraversingWildcardPathSubjectPartToGraphPathPartsConverter>();

            container.Register<IConditionalPathSubjectPartToGraphPathPartsConverter, ConditionalPathSubjectPartToGraphPathPartsConverter>();
            container.Register<IConditionalPredicateFactorySelector, ConditionalPredicateFactorySelector>();
            container.Register<IEqualPredicateFactory, EqualPredicateFactory>();
            container.Register<INotEqualPredicateFactory, NotEqualPredicateFactory>();
            container.Register<ILessThanPredicateFactory, LessThanPredicateFactory>();
            container.Register<ILessThanOrEqualPredicateFactory, LessThanOrEqualPredicateFactory>();
            container.Register<IMoreThanPredicateFactory, MoreThanPredicateFactory>();
            container.Register<IMoreThanOrEqualPredicateFactory, MoreThanOrEqualPredicateFactory>();

            container.Register<IIdentifierPathSubjectPartToGraphPathPartsConverter, IdentifierPathSubjectPartToGraphPathPartsConverter>();
            container.Register<IIsParentOfPathSubjectPartToGraphPathPartsConverter, IsParentOfPathSubjectPartToGraphPathPartsConverter>();
            container.Register<IIsChildOfPathSubjectPartToGraphPathPartsConverter, IsChildOfPathSubjectPartToGraphPathPartsConverter>();
            container.Register<IDowndatePathSubjectPartToGraphPathPartsConverter, DowndatePathSubjectPartToGraphPathPartsConverter>();
            container.Register<IUpdatePathSubjectPartToGraphPathPartsConverter, UpdatePathSubjectPartToGraphPathPartsConverter>();
            container.Register<IVariablePathSubjectPartToGraphPathPartsConverter, VariablePathSubjectPartToGraphPathPartsConverter>();
            container.Register<IPathSubjectToGraphPathConverter, PathSubjectToGraphPathConverter>();
            container.Register<IPathProcessor, PathProcessor>();

            container.Register<IConstantSubjectsParser, ConstantSubjectsParser>();
            container.Register<IStringConstantSubjectParser, StringConstantSubjectParser>();
            container.Register<IObjectConstantSubjectParser, ObjectConstantSubjectParser>();
        }
    }
}
