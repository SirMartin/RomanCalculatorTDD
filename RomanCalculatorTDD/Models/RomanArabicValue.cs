namespace RomanCalculatorTDD.Models
{
    public class RomanArabicValue
    {
        public char RomanValue { get; }
        public int ArabicValue { get; }
        public int AmountOfRepetitions { get; }

        public RomanArabicValue(char roman, int arabic, int repetitions)
        {
            RomanValue = roman;
            ArabicValue = arabic;
            AmountOfRepetitions = repetitions;
        }
    }
}
