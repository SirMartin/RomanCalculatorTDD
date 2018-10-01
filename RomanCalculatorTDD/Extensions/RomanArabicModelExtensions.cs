using RomanCalculatorTDD.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace RomanCalculatorTDD.Extensions
{
    public static class RomanArabicModelExtensions
    {
        public static RomanArabicValue GetRomanValueModel(this List<RomanArabicValue> numbers, int value)
        {
            return numbers.FirstOrDefault(x => x.ArabicValue == value);
        }

        public static char? GetRomanValue(this List<RomanArabicValue> numbers, int value)
        {
            return numbers.GetRomanValueModel(value)?.RomanValue;
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
        
        public static RomanArabicValue GetArabicValueModel(this List<RomanArabicValue> numbers, char value)
        {
            return numbers.FirstOrDefault(x => x.RomanValue == value);
        }

        public static int? GetArabicValue(this List<RomanArabicValue> numbers, char value)
        {
            return numbers.GetArabicValueModel(value)?.ArabicValue;
        }

        public static RomanArabicValue GetMaximunNextRomanValue(this List<RomanArabicValue> numbers, char value)
        {
            var m = numbers.GetArabicValueModel(value);
            var i = numbers.IndexOf(m);
            return numbers.Count < i + 2 ? null : numbers[i + 2];
        }
    }
}
