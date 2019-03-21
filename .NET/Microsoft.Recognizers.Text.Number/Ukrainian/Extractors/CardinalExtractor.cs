using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.Number.Ukrainian
{
    public class CardinalExtractor : BaseNumberExtractor
    {
        internal sealed override ImmutableDictionary<Regex, TypeTag> Regexes { get; }
        protected sealed override string ExtractType { get; } = Constants.SYS_NUM_CARDINAL; //"Cardinal";

        public CardinalExtractor(string placeholder = @"\D|\b")
        {
            var builder = ImmutableDictionary.CreateBuilder<Regex, TypeTag>();

            //Add Integer Regexes
            var intExtract = new IntegerExtractor(placeholder);
            builder.AddRange(intExtract.Regexes);

            //Add Double Regexes
            var douExtract = new DoubleExtractor(placeholder);
            builder.AddRange(douExtract.Regexes);

            Regexes = builder.ToImmutable();
        }
    }
}