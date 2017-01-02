﻿namespace EtAlii.Servus.Api.Functional
{
    using System.Linq;
    using Moppet.Lapa;

    internal class PathSubjectPartsParser : IPathSubjectPartsParser
    {
        public string Id { get { return _id; } }
        private readonly string _id = "PathSubjectsPart";

        public LpsParser Parser { get { return _parser; } }
        private readonly LpsParser _parser;

        private readonly INodeValidator _nodeValidator;
        private readonly IPathSubjectPartParser[] _parsers;

        public PathSubjectPartsParser(
            ITraversingWildcardPathSubjectPartParser traversingWildcardPathSubjectPartParser,
            IWildcardPathSubjectPartParser wildcardPathSubjectPartParser,
            IConditionalPathSubjectPartParser conditionalPathSubjectPartParser,
            IConstantPathSubjectPartParser constantPathSubjectPartParser,
            IVariablePathSubjectPartParser variablePathSubjectPartParser,
            IIdentifierPathSubjectPartParser identifierPathSubjectPartParser,
            IIsParentOfPathSubjectPartParser isParentOfPathSubjectPartParser,
            IIsChildOfPathSubjectPartParser isChildOfPathSubjectPartParser,
            IDowndateOfPathSubjectPartParser downdateOfPathSubjectPartParser,
            IUpdatesOfPathSubjectPartParser updatesOfPathSubjectPartParser,
            INodeValidator nodeValidator)
        {
            _parsers = new IPathSubjectPartParser[]
            {
                traversingWildcardPathSubjectPartParser,
                wildcardPathSubjectPartParser,
                conditionalPathSubjectPartParser, 
                constantPathSubjectPartParser,
                variablePathSubjectPartParser,
                identifierPathSubjectPartParser,
                isParentOfPathSubjectPartParser,
                isChildOfPathSubjectPartParser,
                downdateOfPathSubjectPartParser,
                updatesOfPathSubjectPartParser
            };
            _nodeValidator = nodeValidator;
            var lpsParsers = _parsers.Aggregate(new LpsAlternatives(), (current, parser) => current | parser.Parser);
            _parser = new LpsParser(Id, true, lpsParsers);
        }

        public PathSubjectPart Parse(LpNode node)
        {
            _nodeValidator.EnsureSuccess(node, Id);
            var childNode = node.Children.Single();
            var parser = _parsers.Single(p => p.CanParse(childNode));
            var result = parser.Parse(childNode);
            return result;
        }

        public void Validate(PathSubjectPart before, PathSubjectPart part, int partIndex, PathSubjectPart after)
        {
            var parser = _parsers.Single(p => p.CanValidate(part));
            parser.Validate(before, part, partIndex, after);
        }
    }
}
