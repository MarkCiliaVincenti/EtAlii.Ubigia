// Copyright (c) Peter Vrenken. All rights reserved. See the license in https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Functional.Traversal
{
    using System;
    using System.Globalization;
    using EtAlii.Ubigia.Api.Functional.Traversal.Antlr;

    public partial class GtlVisitor
    {
        // We use CultureInfo.InvariantCulture to ensure the . is always used as separator.
        public override object VisitString_quoted(GtlParser.String_quotedContext context) => context.STRING_QUOTED().GetText().Trim('"', '\'');

        public override object VisitBoolean_literal(GtlParser.Boolean_literalContext context) => bool.Parse(context.BOOLEAN_LITERAL().GetText());

        public override object VisitFloat_literal(GtlParser.Float_literalContext context) => float.Parse(context.GetText(), CultureInfo.InvariantCulture);

        public override object VisitFloat_literal_unsigned(GtlParser.Float_literal_unsignedContext context) => float.Parse(context.GetText(), CultureInfo.InvariantCulture);

        public override object VisitInteger_literal(GtlParser.Integer_literalContext context) => int.Parse(context.GetText(), CultureInfo.InvariantCulture);

        public override object VisitInteger_literal_unsigned(GtlParser.Integer_literal_unsignedContext context) => int.Parse(context.GetText(), CultureInfo.InvariantCulture);

        public override object VisitIdentifier(GtlParser.IdentifierContext context) => context.IDENTIFIER()?.GetText();

        public override object VisitTimespan(GtlParser.TimespanContext context)
        {
            var days = (int)VisitInteger_literal_unsigned(context.integer_literal_unsigned(0));
            var hours = (int)VisitInteger_literal_unsigned(context.integer_literal_unsigned(1));
            var minutes = (int)VisitInteger_literal_unsigned(context.integer_literal_unsigned(2));
            var seconds = (int)VisitInteger_literal_unsigned(context.integer_literal_unsigned(3));
            var milliseconds = (int)VisitInteger_literal_unsigned(context.integer_literal_unsigned(4));
            return new TimeSpan(days, hours, minutes, seconds, milliseconds);
        }

        public override object VisitDatetime_format_1(GtlParser.Datetime_format_1Context context)
        {
            var year = context.datetime_date_yyyy().GetText();
            var month = context.datetime_date_mm().GetText();
            var day = context.datetime_date_dd().GetText();
            var hour = context.datetime_time_hh().GetText();
            var minute = context.datetime_time_mm().GetText();
            var second = context.datetime_time_ss().GetText();
            var milliSecond = context.datetime_ms().GetText();

            return DateTime.ParseExact($"{year}-{month}-{day}T{hour}:{minute}:{second}.{milliSecond}", "yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture);
        }
        public override object VisitDatetime_format_2(GtlParser.Datetime_format_2Context context)
        {
            var year = context.datetime_date_yyyy().GetText();
            var month = context.datetime_date_mm().GetText();
            var day = context.datetime_date_dd().GetText();
            var hour = context.datetime_time_hh().GetText();
            var minute = context.datetime_time_mm().GetText();
            var second = context.datetime_time_ss().GetText();

            return DateTime.ParseExact($"{year}-{month}-{day}T{hour}:{minute}:{second}", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
        }
        public override object VisitDatetime_format_3(GtlParser.Datetime_format_3Context context)
        {
            var year = context.datetime_date_yyyy().GetText();
            var month = context.datetime_date_mm().GetText();
            var day = context.datetime_date_dd().GetText();
            var hour = context.datetime_time_hh().GetText();
            var minute = context.datetime_time_mm().GetText();

            return DateTime.ParseExact($"{year}-{month}-{day}T{hour}:{minute}", "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
        }
        public override object VisitDatetime_format_4(GtlParser.Datetime_format_4Context context)
        {
            var year = context.datetime_date_yyyy().GetText();
            var month = context.datetime_date_mm().GetText();
            var day = context.datetime_date_dd().GetText();

            return DateTime.ParseExact($"{year}-{month}-{day}", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
        public override object VisitDatetime_format_5(GtlParser.Datetime_format_5Context context)
        {
            var year = context.datetime_date_yyyy().GetText();
            var month = context.datetime_date_mm().GetText();
            var day = context.datetime_date_dd().GetText();
            var hour = context.datetime_time_hh().GetText();
            var minute = context.datetime_time_mm().GetText();
            var second = context.datetime_time_ss().GetText();
            var milliSecond = context.datetime_ms().GetText();

            return DateTime.ParseExact($"{year}-{month}-{day}T{hour}:{minute}:{second}.{milliSecond}", "yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture);
        }
        public override object VisitDatetime_format_6(GtlParser.Datetime_format_6Context context)
        {
            var year = context.datetime_date_yyyy().GetText();
            var month = context.datetime_date_mm().GetText();
            var day = context.datetime_date_dd().GetText();
            var hour = context.datetime_time_hh().GetText();
            var minute = context.datetime_time_mm().GetText();
            var second = context.datetime_time_ss().GetText();

            return DateTime.ParseExact($"{year}-{month}-{day}T{hour}:{minute}:{second}", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
        }

        public override object VisitDatetime_format_7(GtlParser.Datetime_format_7Context context)
        {
            var year = context.datetime_date_yyyy().GetText();
            var month = context.datetime_date_mm().GetText();
            var day = context.datetime_date_dd().GetText();
            var hour = context.datetime_time_hh().GetText();
            var minute = context.datetime_time_mm().GetText();

            return DateTime.ParseExact($"{year}-{month}-{day}T{hour}:{minute}", "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
        }

        public override object VisitDatetime_format_8(GtlParser.Datetime_format_8Context context)
        {
            var year = context.datetime_date_yyyy().GetText();
            var month = context.datetime_date_mm().GetText();
            var day = context.datetime_date_dd().GetText();

            return DateTime.ParseExact($"{year}-{month}-{day}", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }
}
