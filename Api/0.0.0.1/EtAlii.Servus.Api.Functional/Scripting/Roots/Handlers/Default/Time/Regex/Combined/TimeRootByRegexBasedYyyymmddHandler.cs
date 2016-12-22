namespace EtAlii.Servus.Api.Functional
{
    using System;
    using System.Linq;

    public class TimeRootByRegexBasedYyyymmddHandler : IRootHandler
    {

        public PathSubjectPart[] Template { get { return _template; } }
        private readonly PathSubjectPart[] _template;

        public TimeRootByRegexBasedYyyymmddHandler()
        {
            _template = new PathSubjectPart[] { new RegexPathSubjectPart(@"\d{4}\d{2}\d{2}") };
        }

        public void Process(IRootContext context, PathSubjectPart[] match, PathSubjectPart[] rest, ExecutionScope scope, IObserver<object> output)
        {
            var time = match[0].ToString();
            var year = Int32.Parse(time.Substring(0, 4));
            var month = Int32.Parse(time.Substring(4, 2));
            var day = Int32.Parse(time.Substring(6, 2));

            var parts = new PathSubjectPart[] {
                    new IsParentOfPathSubjectPart(), new ConstantPathSubjectPart("Time"), 
                    new IsParentOfPathSubjectPart(), new ConstantPathSubjectPart(year.ToString("D4")),
                    new IsParentOfPathSubjectPart(), new ConstantPathSubjectPart(month.ToString("D2")),
                    new IsParentOfPathSubjectPart(), new ConstantPathSubjectPart(day.ToString("D2")),
                }
                .Concat(rest)
                .ToArray();
            var path = new AbsolutePathSubject(parts);
            context.Converter.Convert(path, scope, output);
        }
    }
}