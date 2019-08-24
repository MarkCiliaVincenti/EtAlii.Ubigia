namespace EtAlii.Ubigia.Api.Functional
{
    using EtAlii.Ubigia.Api.Functional.Scripting;
    using Moppet.Lapa;

    internal class AssignmentParser : IAssignmentParser
    {
        public LpsParser Parser { get; }

        public AssignmentParser(IWhitespaceParser whitespaceParser)
        {
            Parser = whitespaceParser.Optional + Lp.Char('<') + Lp.Char('=') + whitespaceParser.Optional;
        }
    }
}