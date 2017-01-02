﻿// Copyright (c) Peter Vrenken. All rights reserved. See License.txt in the project root for license information.

namespace EtAlii.Servus.Api.Functional
{
    using System.Linq;
    using Moppet.Lapa;

    internal class SubjectsParser : ISubjectsParser
    {
        public string Id { get { return _id; } }
        private readonly string _id = "Subjects";

        public LpsParser Parser { get { return _parser; } }
        private readonly LpsParser _parser;

        private readonly INodeValidator _nodeValidator;
        private readonly ISubjectParser[] _parsers;

        public SubjectsParser(
            IFunctionSubjectParser functionSubjectParser,
            IVariableSubjectParser variableSubjectParser,
            IConstantSubjectsParser constantSubjectsParser,
            IPathSubjectParser pathSubjectParser,
            INodeValidator nodeValidator)
        {
            _parsers = new ISubjectParser[]
            {
                functionSubjectParser,
                variableSubjectParser,
                constantSubjectsParser,
                pathSubjectParser
            };
            _nodeValidator = nodeValidator;
            var lpsParsers = _parsers.Aggregate(new LpsAlternatives(), (current, parser) => current | parser.Parser);
            _parser = new LpsParser(Id, true, lpsParsers);
        }

        public bool CanParse(LpNode node)
        {
            return node.Id == Id;
        }

        public SequencePart Parse(LpNode node)
        {
            _nodeValidator.EnsureSuccess(node, Id);
            var childNode = node.Children.Single();
            var parser = _parsers.Single(p => p.CanParse(childNode));
            var result = parser.Parse(childNode);
            return result;
        }

        public bool CanValidate(SequencePart part)
        {
            return part is Subject;
        }

        public void Validate(SequencePart before, SequencePart part, int partIndex, SequencePart after)
        {
            var subject = (Subject)part;
            var parser = _parsers.Single(p => p.CanValidate(subject));
            parser.Validate(before, subject, partIndex, after);

            if (before is Subject || after is Subject)
            {
                throw new ScriptParserException("Two subjects cannot be combined.");
            }
            if (before is Comment)
            {
                throw new ScriptParserException("A subject cannot used in combination with comments.");
            }
        }
    }
}
