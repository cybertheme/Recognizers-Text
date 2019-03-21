using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.Number.Ukrainian
{
    public sealed class PercentageExtractor : BasePercentageExtractor
    {
        public PercentageExtractor()
            : base(new NumberExtractor())
        {
        }

        public PercentageExtractor(NumberOptions options = NumberOptions.None)
            : base(new NumberExtractor(options: options))
        {
        }

        protected override ImmutableHashSet<Regex> InitRegexes()
        {
            HashSet<string> regexStrs = new HashSet<string>
            {
                $@"(@{IntegerExtractor.AllIntRegex})(\s)(процент|відсоток|відсотків|процентів|проценти|відсотки)",
            };

            return BuildRegexes(regexStrs);
        }
    }
}