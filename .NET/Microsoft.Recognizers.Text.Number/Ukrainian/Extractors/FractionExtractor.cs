﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.Number.Ukrainian
{
    public class FractionExtractor : BaseNumberExtractor
    {
        public FractionExtractor()
        {
            var regexes = new Dictionary<Regex, TypeTag>
            {
                // {
                //     new Regex(
                //         $@"(?<=\b)({AllFracRegex}\s+(і\s+)?)?({IntegerExtractor.AllIntRegex
                //             })(\s+|\s*-\s*)((({OrdinalExtractor.AllOrdinalRegex})|({
                //                 OrdinalExtractor.RoundNumberOrdinalRegex}))s|halves|quarters)(?=\b)",
                //         RegexOptions.IgnoreCase | RegexOptions.Singleline)
                //     , "FracUa"
                // },
                {
                    new Regex(
                        @"(((?<=\W|^)-\s*)|(?<=\b))\d+\s+\d+[/]\d+(?=(\b[^/]|$))",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    RegexTagGenerator.GenerateRegexTag(Constants.FRACTION_PREFIX, Constants.INTEGER_PREFIX)
                },
                {
                    new Regex(
                        @"(((?<=\W|^)-\s*)|(?<=\b))\d+[/]\d+(?=(\b[^/]|$))",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    RegexTagGenerator.GenerateRegexTag(Constants.FRACTION_PREFIX, Constants.INTEGER_PREFIX)
                },
                {
                    new Regex(
                        $@"(({IntegerExtractor.AllIntRegex}\s+)({OrdinalExtractor.AllOrdinalRegex}))",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    RegexTagGenerator.GenerateRegexTag(Constants.FRACTION_PREFIX, Constants.UKRAINIAN)
                },
                {
                    new Regex(
                        $@"(({IntegerExtractor.AllIntRegex}(\s+))цілих(\s+)(({IntegerExtractor.AllIntRegex}\s+)({OrdinalExtractor.AllOrdinalRegex})))",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    RegexTagGenerator.GenerateRegexTag(Constants.FRACTION_PREFIX, Constants.UKRAINIAN)
                },
            };
            Regexes = regexes.ToImmutableDictionary();
        }

        public static string AllFracRegex
            =>
                $@"({IntegerExtractor.AllIntRegex})";

        internal sealed override ImmutableDictionary<Regex, TypeTag> Regexes { get; }

        protected sealed override string ExtractType { get; } = Constants.SYS_NUM_FRACTION; // "Fraction";
    }
}