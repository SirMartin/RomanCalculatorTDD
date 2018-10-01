namespace RomanCalculatorTDD.Models
{
    public class RomanArabicValue
    {
        public char RomanValue { get; }
        public int ArabicValue { get; }
        public int AmountOfRepetitions { get; }
        public bool IsSubtractable { get; }

        public RomanArabicValue(char roman, int arabic, int repetitions, bool isSubtractable)
        {
            RomanValue = roman;
            ArabicValue = arabic;
            AmountOfRepetitions = repetitions;
            IsSubtractable = isSubtractable;
        }
    }
}
