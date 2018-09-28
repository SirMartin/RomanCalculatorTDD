using RomanCalculatorTDD.Models;
using System.Collections.Generic;
using System.Linq;

namespace RomanCalculatorTDD.Extensions
{
    public static class RomanArabicModelExtensions
    {
        public static char? GetRomanValue(this List<RomanArabicValue> numbers, int value)
        {
            return numbers.FirstOrDefault(x => x.ArabicValue == value)?.RomanValue;
        }

        public static char? GetNextRomanValue(this List<RomanArabicValue> numbers, int value)
        {
            return numbers.FirstOrDefault(x => x.ArabicValue > value)?.RomanValue;
        }

        public static char GetPreviousRomanValue(this List<RomanArabicValue> numbers, int value)
        {
            return numbers.Last(x => x.ArabicValue < value).RomanValue;
        }

        public static char GetClosestRomanValue(this List<RomanArabicValue> numbers, int value)
        {
            var result = numbers.GetRomanValue(value);
            if (!result.HasValue)
            {
                result = numbers.GetPreviousRomanValue(value);
            }

            return result.Value;
        }

        public static int GetArabicValue(this List<RomanArabicValue> numbers, char value)
        {
            return numbers.First(x => x.RomanValue == value).ArabicValue;
        }

        public static int GetRepetitions(this List<RomanArabicValue> numbers, int value)
        {
            return numbers.First(x => x.ArabicValue == value).AmountOfRepetitions;
        }

        public static int GetRepetitions(this List<RomanArabicValue> numbers, char value)
        {
            return numbers.First(x => x.RomanValue == value).AmountOfRepetitions;
        }
    }
}
