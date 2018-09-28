using System;

namespace RomanCalculatorTDD
{
    public class InvalidRomanNumberException : Exception
    {
        public InvalidRomanNumberException(string romanNumber)
            : base($"The roman number {romanNumber} is not correct.")
        {
        }
    }

    public class TooBigArabicNumberException : Exception
    {
        public TooBigArabicNumberException(int arabicNumber)
            : base($"The number {arabicNumber} is too big to be converted in this application.")
        {
        }
    }

    public class InvalidArabicNumberException : Exception
    {
        public InvalidArabicNumberException()
            : base($"The Romans didn't know about the 0 or negative numbers.")
        {
        }
    }
}
