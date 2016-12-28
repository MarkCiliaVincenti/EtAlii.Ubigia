namespace EtAlii.Servus.Api.Functional
{
    using System;
    using System.Linq;

    internal class TimeRootByRegexBasedSeparatedYyyymmddhhmmssHandler : IRootHandler
    {

        public PathSubjectPart[] Template { get { return _template; } }
        private readonly PathSubjectPart[] _template;
        private readonly ITimePreparer _timePreparer;

        public TimeRootByRegexBasedSeparatedYyyymmddhhmmssHandler(ITimePreparer timePreparer)
        {
            _timePreparer = timePreparer;

            _template = new PathSubjectPart[] { new RegexPathSubjectPart(@"\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}") };
        }

        public void Process(IRootContext context, PathSubjectPart[] match, PathSubjectPart[] rest, ExecutionScope scope, IObserver<object> output)
        {
            var timeString = match[0].ToString();
            var year = Int32.Parse(timeString.Substring(0, 4));
            var month = Int32.Parse(timeString.Substring(5, 2));
            var day = Int32.Parse(timeString.Substring(8, 2));
            var hour = Int32.Parse(timeString.Substring(11, 2));
            var minute = Int32.Parse(timeString.Substring(14, 2));
            var second = Int32.Parse(timeString.Substring(17, 2));

            var time = new DateTime(year, month, day, hour, minute, second, 0);
            _timePreparer.Prepare(context, scope, time);

            var parts = new PathSubjectPart[]
                {
                    new IsParentOfPathSubjectPart(), new ConstantPathSubjectPart("Time"),
                    new IsParentOfPathSubjectPart(), new ConstantPathSubjectPart($"{time:yyyy}"),
                    new IsParentOfPathSubjectPart(), new ConstantPathSubjectPart($"{time:MM}"),
                    new IsParentOfPathSubjectPart(), new ConstantPathSubjectPart($"{time:dd}"),
                    new IsParentOfPathSubjectPart(), new ConstantPathSubjectPart($"{time:HH}"),
                    new IsParentOfPathSubjectPart(), new ConstantPathSubjectPart($"{time:mm}"),
                    new IsParentOfPathSubjectPart(), new ConstantPathSubjectPart($"{time:ss}"),
                    new IsParentOfPathSubjectPart(), new WildcardPathSubjectPart("*"), // millisecond
                }
                .Concat(rest)
                .ToArray();
            var path = new AbsolutePathSubject(parts);
            context.Converter.Convert(path, scope, output);
        }
    }
}