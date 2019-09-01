namespace EtAlii.Ubigia.Api.Functional
{
    using System;
    using System.Linq;
    using EtAlii.Ubigia.Api.Functional.Scripting;
    using Moppet.Lapa;

    internal class AssignAndSelectValueAnnotationParser : IAssignAndSelectValueAnnotationParser
    {
        public string Id { get; } = nameof(AssignAndSelectValueAnnotation);
        public LpsParser Parser { get; }

        private const string SourceId = "Source";
        private const string NameId = "Name";
        
        private readonly INodeValidator _nodeValidator;
        private readonly INodeFinder _nodeFinder;
        private readonly INonRootedPathSubjectParser _nonRootedPathSubjectParser;
        private readonly IRootedPathSubjectParser _rootedPathSubjectParser;
        private readonly IQuotedTextParser _quotedTextParser;

        public AssignAndSelectValueAnnotationParser(
            INodeValidator nodeValidator, 
            INodeFinder nodeFinder, 
            INonRootedPathSubjectParser nonRootedPathSubjectParser, 
            IRootedPathSubjectParser rootedPathSubjectParser,
            IWhitespaceParser whitespaceParser,
            IQuotedTextParser quotedTextParser
        )
        {
            _nodeValidator = nodeValidator;
            _nodeFinder = nodeFinder;
            _nonRootedPathSubjectParser = nonRootedPathSubjectParser;
            _rootedPathSubjectParser = rootedPathSubjectParser;
            _quotedTextParser = quotedTextParser;

            // @value-assign(SOURCE, VALUE)
            var sourceParser = new LpsParser(SourceId, true, rootedPathSubjectParser.Parser | nonRootedPathSubjectParser.Parser);
            var nameParser = new LpsParser(NameId, true, Lp.Name().Wrap(NameId) | Lp.OneOrMore(c => char.IsLetterOrDigit(c)).Wrap(NameId) | _quotedTextParser.Parser);
            
            Parser = new LpsParser(Id, true, "@" + AnnotationPrefix.ValueAssign + "(" + whitespaceParser.Optional + sourceParser + whitespaceParser.Optional + "," + whitespaceParser.Optional + nameParser + whitespaceParser.Optional + ")");
        }

        public AnnotationNew Parse(LpNode node)
        {
            _nodeValidator.EnsureSuccess(node, Id);

            var sourceNode = _nodeFinder.FindFirst(node, SourceId);
            var sourceChildNode = sourceNode.Children.Single();
            var sourcePath = sourceChildNode.Id switch
            {
                { } id when id == _rootedPathSubjectParser.Id => (PathSubject) _rootedPathSubjectParser.Parse(sourceChildNode),
                { } id when id == _nonRootedPathSubjectParser.Id => (PathSubject) _nonRootedPathSubjectParser.Parse(sourceChildNode),
                _ => throw new NotSupportedException($"Cannot find path subject in: {node.Match}")
            };
            
            var nameNode = _nodeFinder.FindFirst(node, NameId);
            var nameChildNode = nameNode.Children.Single();
            var name = nameChildNode.Id switch
            {
                {} id when id == _quotedTextParser.Id => _quotedTextParser.Parse(nameChildNode),
                _ => nameChildNode.Match.ToString()
            };

            var constant = name != null ? new StringConstantSubject(name) : null;
            return new AssignAndSelectValueAnnotation(sourcePath, constant);
        }

        public bool CanParse(LpNode node)
        {
            return node.Id == Id;
        }

        public void Validate(StructureFragment parent, StructureFragment self, AnnotationNew annotation, int depth)
        {
            throw new NotImplementedException();
        }

        public bool CanValidate(AnnotationNew annotation)
        {
            return annotation is AssignAndSelectValueAnnotation;
        }
    }
}