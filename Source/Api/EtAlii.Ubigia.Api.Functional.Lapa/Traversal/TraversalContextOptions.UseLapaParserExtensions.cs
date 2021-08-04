// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Api.Functional.Traversal
{
    public static class TraversalContextOptionsUseLapaTraversalParserExtensions
    {
        /// <summary>
        /// Add Lapa GTL parsing to the options.
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="TTraversalContextOptions"></typeparam>
        /// <returns></returns>
        public static TTraversalContextOptions UseLapaTraversalParser<TTraversalContextOptions>(this TTraversalContextOptions options)
            where TTraversalContextOptions : FunctionalContextOptions
        {
            var editableOptions = (IEditableFunctionalContextOptions) options;
            editableOptions.ParserOptionsProvider = () => new ParserOptions().UseLapa();
            editableOptions.ProcessorOptionsProvider = () => new TraversalProcessorOptions().UseLapa();

            return options;
        }
    }
}
