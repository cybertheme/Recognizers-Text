﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.Number.Ukrainian
{
    public class OrdinalExtractor : BaseNumberExtractor
    {
        internal sealed override ImmutableDictionary<Regex, TypeTag> Regexes { get; }
        protected sealed override string ExtractType { get; } = Constants.SYS_NUM_ORDINAL; // "Ordinal";

        public const string RoundNumberOrdinalRegex = @"(тисячний|тисячна|тисячні|тисячного|тисячних|тисячну|тисячному|тисячній|тисячним|тисячною|тисячними|мільйонний|мільйонна|мільйонні|мільйонного|мільйонних|мільйонну|мільйонному|мільйонній|мільйонним|мільйонною|мільйонними|мільярдний|мільярдна|мільярдні|мільярдного|мільярдних|мільярдну|мільярдному|мільярдній|мільярдним|мільярдною|мільярдними|трильйонний|трильйонна|трильйонні|трильйонного|трильйонних|трильйонну|трильйонному|трильйонній|трильйонним|трильйонною|трильйонними)";

        public const string BasicOrdinalRegex =
            @"(перший|перша|перші|першого|першої|перших|першому|першій|першим|першу|першою|першими|другий|другі|друга|других|другу|другого|другим|другою|другими|другому|другій|третя|треті|третій|третього|третю|третіх|третьому|третім|третіми|третьою|четвертий|четверта|четверті|четвертого|четвертих|четверту|четвертому|четвертій|четвертим|четвертою|четвертими|п'ятий|п'ята|п'яті|п'ятого|п'ятих|п'яту|п'ятому|п'ятій|п'ятим|п'ятою|п'ятими|шостий|шоста|шості|шостого|шостих|шосту|шостому|шостій|шостим|шостою|шостими|сьомий|сьома|сьомі|сьомого|сьомих|сьому|сьомому|сьомій|сьомим|сьомою|сьомими|восьмий|восьма|восьмі|восьмого|восьмих|восьму|восьмому|восьмій|восьмим|восьмою|восьмими|дев'ятий|дев'ята|дев'яті|дев'ятого|дев'ятих|дев'яту|дев'ятому|дев'ятій|дев'ятим|дев'ятою|дев'ятими|десятий|десята|десяті|десятого|десятих|десяту|десятому|десятій|десятим|десятою|десятими|одинадцятий|одинадцята|одинадцяті|одинадцятого|одинадцятих|одинадцяту|одинадцятому|одинадцятій|одинадцятим|одинадцятою|одинадцятими|дванадцятий|дванадцята|дванадцяті|дванадцятого|дванадцятих|дванадцяту|дванадцятому|дванадцятій|дванадцятим|дванадцятою|дванадцятими|тринадцятий|тринадцята|тринадцяті|тринадцятого|тринадцятих|тринадцяту|тринадцятому|тринадцятій|тринадцятим|тринадцятою|тринадцятими|чотирнадцятий|чотирнадцята|чотирнадцяті|чотирнадцятого|чотирнадцятих|чотирнадцяту|чотирнадцятому|чотирнадцятій|чотирнадцятим|чотирнадцятою|чотирнадцятими|п'ятнадцятий|п'ятнадцята|п'ятнадцяті|п'ятнадцятого|п'ятнадцятих|п'ятнадцяту|п'ятнадцятому|п'ятнадцятій|п'ятнадцятим|п'ятнадцятою|п'ятнадцятими|шістнадцятий|шістнадцята|шістнадцяті|шістнадцятого|шістнадцятих|шістнадцяту|шістнадцятому|шістнадцятій|шістнадцятим|шістнадцятою|шістнадцятими|сімнадцятий|сімнадцята|сімнадцяті|сімнадцятого|сімнадцятих|сімнадцяту|сімнадцятому|сімнадцятій|сімнадцятим|сімнадцятою|сімнадцятими|вісімнадцятий|вісімнадцята|вісімнадцяті|вісімнадцятого|вісімнадцятих|вісімнадцяту|вісімнадцятому|вісімнадцятій|вісімнадцятим|вісімнадцятою|вісімнадцятими|дев'ятнадцятий|дев'ятнадцята|дев'ятнадцяті|дев'ятнадцятого|дев'ятнадцятих|дев'ятнадцяту|дев'ятнадцятому|дев'ятнадцятій|дев'ятнадцятим|дев'ятнадцятою|дев'ятнадцятими|двадцятий|двадцята|двадцяті|двадцятого|двадцятих|двадцяту|двадцятому|двадцятій|двадцятим|двадцятою|двадцятими|тридцятий|тридцята|тридцяті|тридцятого|тридцятих|тридцяту|тридцятому|тридцятій|тридцятим|тридцятою|тридцятими|сороковий|сорокова|сорокові|сорокового|сорокових|сорокову|сороковому|сороковій|сороковим|сороковою|сороковими|п'тидесятий|п'тидесята|п'тидесяті|п'тидесятого|п'тидесятих|п'тидесяту|п'тидесятому|п'тидесятій|п'тидесятим|п'тидесятою|п'тидесятими|шестидесятий|шестидесята|шестидесяті|шестидесятого|шестидесятих|шестидесяту|шестидесятому|шестидесятій|шестидесятим|шестидесятою|шестидесятими|семидесятий|семидесята|семидесяті|семидесятого|семидесятих|семидесяту|семидесятому|семидесятій|семидесятим|семидесятою|семидесятими|восьмидесятий|восьмидесята|восьмидесяті|восьмидесятого|восьмидесятих|восьмидесяту|восьмидесятому|восьмидесятій|восьмидесятим|восьмидесятою|восьмидесятими|дев'яностий|дев'яноста|дев'яності|дев'яностого|дев'яностих|дев'яносту|дев'яностому|дев'яностій|дев'яностим|дев'яностою|дев'яностими|сотий|сота|соті|сотого|сотих|соту|сотому|сотій|сотим|сотою|сотими|двухсотий|двухсота|двухсоті|двухсотого|двухсотих|двухсоту|двухсотому|двухсотій|двухсотим|двухсотою|двухсотими|трьохсотий|трьохсота|трьохсоті|трьохсотого|трьохсотих|трьохсоту|трьохсотому|трьохсотій|трьохсотим|трьохсотою|трьохсотими|чотирьохсотий|чотирьохсота|чотирьохсоті|чотирьохсотого|чотирьохсотих|чотирьохсоту|чотирьохсотому|чотирьохсотій|чотирьохсотим|чотирьохсотою|чотирьохсотими|п'ятисотий|п'ятисота|п'ятисоті|п'ятисотого|п'ятисотих|п'ятисоту|п'ятисотому|п'ятисотій|п'ятисотим|п'ятисотою|п'ятисотими|шестисотий|шестисота|шестисоті|шестисотого|шестисотих|шестисоту|шестисотому|шестисотій|шестисотим|шестисотою|шестисотими|семисотий|семисота|семисоті|семисотого|семисотих|семисоту|семисотому|семисотій|семисотим|семисотою|семисотими|восьмисотий|восьмисота|восьмисоті|восьмисотого|восьмисотих|восьмисоту|восьмисотому|восьмисотій|восьмисотим|восьмисотою|восьмисотими|дев'ятисотий|дев'ятисота|дев'ятисоті|дев'ятисотого|дев'ятисотих|дев'ятисоту|дев'ятисотому|дев'ятисотій|дев'ятисотим|дев'ятисотою|дев'ятисотими|тисячний|тисячна|тисячні|тисячного|тисячних|тисячну|тисячному|тисячній|тисячним|тисячною|тисячними|мільйонний|мільйонна|мільйонні|мільйонного|мільйонних|мільйонну|мільйонному|мільйонній|мільйонним|мільйонною|мільйонними|мільярдний|мільярдна|мільярдні|мільярдного|мільярдних|мільярдну|мільярдному|мільярдній|мільярдним|мільярдною|мільярдними|трильйонний|трильйонна|трильйонні|трильйонного|трильйонних|трильйонну|трильйонному|трильйонній|трильйонним|трильйонною|трильйонними)";
        
        public static string AllOrdinalRegex
            => $@"(({IntegerExtractor.AllIntRegex})?(\s+)?({BasicOrdinalRegex}))";

        public OrdinalExtractor()
        {
            var _regexes = new Dictionary<Regex, TypeTag>
            {
                {
                    new Regex(
                        @"(?<=\b)((\d*(1ий|2ий|3ій|4ий|5ий|6ий|7ий|8ий|9ий|0ий))|(11ий|12ий))(?=\b)",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline)
                    , RegexTagGenerator.GenerateRegexTag(Constants.ORDINAL_PREFIX, Constants.NUMBER_SUFFIX)
                },
                //{
                //    new Regex(@"(?<=\b)(\d{1,3}(\s*,\s*\d{3})*\s*ий)(?=\b)",
                //        RegexOptions.IgnoreCase | RegexOptions.Singleline)
                //    , "OrdinalNum"
                //},
                {
                    new Regex($@"(?<=\b){AllOrdinalRegex}(?=\b)", RegexOptions.IgnoreCase | RegexOptions.Singleline)
                    , RegexTagGenerator.GenerateRegexTag(Constants.INTEGER_PREFIX, Constants.UKRAINIAN)
                }
            };
            Regexes = _regexes.ToImmutableDictionary();
        }
    }
}