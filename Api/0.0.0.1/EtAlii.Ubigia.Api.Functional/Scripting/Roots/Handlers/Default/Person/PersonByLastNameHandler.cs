namespace EtAlii.Ubigia.Api.Functional
{
    using System;
    using System.Linq;

    internal class PersonByLastNameHandler : IRootHandler
    {

        public PathSubjectPart[] Template => _template;
        private readonly PathSubjectPart[] _template;

        public PersonByLastNameHandler()
        {
            _template = new PathSubjectPart[] { new TypedPathSubjectPart(TypedPathFormatter.Name.LastNameFormatter) };
        }

        public void Process(IRootContext context, PathSubjectPart[] match, PathSubjectPart[] rest, ExecutionScope scope, IObserver<object> output)
        {
            var parts = new PathSubjectPart[] { new IsParentOfPathSubjectPart(), new ConstantPathSubjectPart("Person"), new IsParentOfPathSubjectPart() }
               .Concat(match)
               .Concat(rest)
               .ToArray();
            var path = new AbsolutePathSubject(parts);
            context.Converter.Convert(path, scope, output);
        }
    }
}