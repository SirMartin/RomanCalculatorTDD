using RomanCalculatorTDD.Models;
using RomanCalculatorTDD.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace RomanCalculatorTDD
{
    public class RomanCalculator
    {
        public readonly List<RomanArabicValue> values;
        public RomanCalculator()
        {
            values = new List<RomanArabicValue>
            {
                new RomanArabicValue('I', 1, 3),
                new RomanArabicValue('V', 5 ,1),
                new RomanArabicValue('X', 10 ,3),
                new RomanArabicValue('L', 50 ,1),
                new RomanArabicValue('C', 100 ,3),
                new RomanArabicValue('D', 500 ,1),
                new RomanArabicValue('M', 1000, 3)
            };
        }

        #region To Arabic

        private void CheckForMultipliers(string roman, int i)
        {
            // Check for more than 3 repeated element (for I,X,C,M) and more than 1 (for V, L, D).
            var r = values.FirstOrDefault(x => x.RomanValue == roman[i]);
            if (r == null || i + r.AmountOfRepetitions >= roman.Length)
                return;

            var isRepeated = true;
            for (var j = 1; j <= r.AmountOfRepetitions; j++)
            {
                if (roman[i] != roman[i + j])
                {
                    isRepeated = false;
                    break;
                }
            }

            if (isRepeated)
            {
                throw new InvalidRomanNumberException(roman);
            }
        }

        private void CheckForPositions(string roman, int i)
        {
            // Check the right positions.
            if (i + 1 >= roman.Length)
                return;

            switch (roman[i])
            {
                case 'I':
                    if (values.GetArabicValue(roman[i + 1]) > values.GetArabicValue('X'))
                    {
                        throw new InvalidRomanNumberException(roman);
                    }
                    break;
                case 'X':
                    if (values.GetArabicValue(roman[i + 1]) > values.GetArabicValue('C'))
                    {
                        throw new InvalidRomanNumberException(roman);
                    }
                    break;
                case 'V':
                case 'L':
                case 'D':
                    if (values.GetArabicValue(roman[i]) < values.GetArabicValue(roman[i + 1]))
                    {
                        throw new InvalidRomanNumberException(roman);
                    }
                    break;
                default:
                    break;
            }
        }

        private void ValidateRomanNumber(string roman)
        {
            for (var i = 0; i < roman.Length; i++)
            {
                CheckForMultipliers(roman, i);

                CheckForPositions(roman, i);
            }
        }

        public int ToArabicNumber(string roman)
        {
            ValidateRomanNumber(roman);

            var result = 0;
            for (var i = 0; i < roman.Length; i++)
            {
                var c = roman[i];

                // Check if its the last char.
                if (i == roman.Length - 1)
                {
                    result += values.GetArabicValue(c);
                    continue;
                }

                // Not the latest char.
                var actualCharValue = values.GetArabicValue(c);
                if (values.GetArabicValue(roman[i + 1]) > actualCharValue)
                {
                    // Subtraction
                    result -= actualCharValue;
                }
                else
                {
                    result += actualCharValue;
                }


            }

            return result;
        }

        #endregion

        #region To Roman

        public string ToRomanNumber(int arabic)
        {
            ValidateArabicNumberToConvert(arabic);

            var numbers = SplitNumber(arabic);

            var result = string.Empty;
            foreach (var n in numbers)
            {
                if (n <= 0)
                    continue;

                var value = values.GetRomanValue(n);
                if (value.HasValue)
                {
                    result += value;
                }
                else
                {
                    var previousValue = values.GetPreviousRomanValue(n);
                    var nextValue = values.GetNextRomanValue(n);

                    // Check if we repeat the amount of times possible, we get the value or we need to substract.
                    if (previousValue * values.GetRepetitions(previousValue) >= n)
                    {
                        // Only additions.
                        int counted = 0;
                        while (counted < n)
                        {
                            counted += values.GetArabicValue(previousValue);
                            result += previousValue.ToString();
                        }
                    }
                    else
                    {
                        // Need substractions.

                    }
                    // Coger el valor por encima y por debajo, e ir jugando con ellos hastsa sacarlo.
                    // Por ejemplo si hay que hacer el 300, el anterior es 100 (C) y el superior 500 (D)
                    // Se prueba cuantas hasta 3
                }
            }

            return result;
        }



        private void ValidateArabicNumberToConvert(int arabic)
        {
            if (arabic <= 0)
            {
                throw new InvalidArabicNumberException();
            }
            else if (arabic > 3333)
            {
                throw new TooBigArabicNumberException(arabic);
            }
        }

        private List<int> SplitNumber(int number)
        {
            var result = new List<int>();
            int multiplier = 1;
            var chars = number.ToString().ToCharArray();
            for (var i = chars.Length - 1; i >= 0; i--)
            {
                result.Add(int.Parse(chars[i].ToString()) * multiplier);
                multiplier *= 10;
            }

            // Reverse the results.
            result.Reverse();

            return result;
        }


        #endregion
    }
}
