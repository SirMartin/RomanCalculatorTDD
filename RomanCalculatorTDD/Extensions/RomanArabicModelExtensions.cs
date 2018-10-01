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

        public static RomanArabicValue GetNextRomanValue(this List<RomanArabicValue> numbers, int value)
        {
            return numbers.FirstOrDefault(x => x.ArabicValue > value);
        }

        public static RomanArabicValue GetPreviousRomanValue(this List<RomanArabicValue> numbers, int value)
        {
            return numbers.LastOrDefault(x => x.ArabicValue < value);
        }

        public static RomanArabicValue GetPreviousSubtractableRomanValue(this List<RomanArabicValue> numbers, int value)
        {
            return numbers.LastOrDefault(x => x.ArabicValue < value && x.IsSubtractable);
        }
        
        public static int GetArabicValue(this List<RomanArabicValue> numbers, char value)
        {
            return numbers.First(x => x.RomanValue == value).ArabicValue;
        }
    }
}
