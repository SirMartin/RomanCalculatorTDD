using RomanCalculatorTDD.Models;
using RomanCalculatorTDD.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace RomanCalculatorTDD
{
    public class RomanCalculator
    {
        private readonly List<RomanArabicValue> _values;
        public RomanCalculator()
        {
            _values = new List<RomanArabicValue>
            {
                new RomanArabicValue('I', 1, 3, true),
                new RomanArabicValue('V', 5 ,1, false),
                new RomanArabicValue('X', 10 ,3, true),
                new RomanArabicValue('L', 50 ,1, false),
                new RomanArabicValue('C', 100 ,3, true),
                new RomanArabicValue('D', 500 ,1, false),
                new RomanArabicValue('M', 1000, 3, true)
            };
        }

        #region Arabic Number Validations

        private void ValidateArabicNumberToConvert(int arabic)
        {
            if (arabic <= 0)
            {
                throw new InvalidArabicNumberException();
            }

            if (arabic > 3999)
            {
                throw new TooBigArabicNumberException(arabic);
            }
        }

        #endregion

        #region Roman Number Validations

        private bool CheckForMultipliers(string roman, int i)
        {
            // Check for more than 3 repeated element (for I,X,C,M) and more than 1 (for V, L, D).
            var r = _values.FirstOrDefault(x => x.RomanValue == roman[i]);
            if (r == null || i + r.AmountOfRepetitions >= roman.Length)
                return true;

            var isRepeated = true;
            for (var j = 1; j <= r.AmountOfRepetitions; j++)
            {
                if (roman[i] != roman[i + j])
                {
                    isRepeated = false;
                    break;
                }
            }

            return !isRepeated;
        }

        private bool CheckForPositions(string roman, int i)
        {
            // Check the right positions.
            if (i + 1 >= roman.Length)
                return true;

            var model = _values.GetArabicValueModel(roman[i]);

            switch (model.AmountOfRepetitions)
            {
                case 1:
                    if (_values.GetArabicValue(roman[i]) < _values.GetArabicValue(roman[i + 1]))
                    {
                        return false;
                    }
                    break;
                case 3:
                    var maxValue = _values.GetMaximunNextRomanValue(roman[i]);
                    if (maxValue != null &&_values.GetArabicValue(roman[i + 1]) > maxValue.ArabicValue)
                    {
                        return false;
                    }
                    break;
            }

            return true;
        }

        private bool ValidateRomanNumber(string roman)
        {
            for (var i = 0; i < roman.Length; i++)
            {
                if (!CheckForMultipliers(roman, i))
                    return false;

                if (!CheckForPositions(roman, i))
                    return false;
            }

            return true;
        }

        #endregion

        #region Calculation to Arabic

        public int ToArabicNumber(string roman)
        {
            var isValid = ValidateRomanNumber(roman);
            if (!isValid)
            {
                throw new InvalidRomanNumberException(roman);
            }

            var result = 0;
            for (var i = 0; i < roman.Length; i++)
            {
                var c = roman[i];

                // Check if its the last char.
                if (i == roman.Length - 1)
                {
                    var n = _values.GetArabicValue(c);
                    result += n ?? 0;
                    continue;
                }

                // Not the latest char.
                var actualCharValue = _values.GetArabicValue(c);
                if (actualCharValue.HasValue)
                {
                    if (_values.GetArabicValue(roman[i + 1]) > actualCharValue.Value)
                    {
                        // Subtraction
                        result -= actualCharValue.Value;
                    }
                    else
                    {
                        result += actualCharValue.Value;
                    }
                }

            }

            return result;
        }

        #endregion

        #region Calculation to Roman

        public string ToRomanNumber(int arabic)
        {
            ValidateArabicNumberToConvert(arabic);

            var numbers = SplitNumber(arabic);

            var result = string.Empty;
            foreach (var n in numbers)
            {
                if (n <= 0)
                    continue;

                result += Recursive(n);
            }

            return result;
        }

        private string Recursive(int n, char? latestValue = null, bool isFullNumber = true)
        {
            var result = string.Empty;

            var value = _values.GetRomanValue(n);
            if (value.HasValue && (!latestValue.HasValue || latestValue.Value != value))
            {
                result += value;
            }
            else
            {
                var previousValue = _values.GetPreviousRomanValue(n);
                if (previousValue != null)
                {
                    var counted = 0;
                    var repetitions = 0;
                    while (counted != n && counted + previousValue.ArabicValue <= n &&
                           repetitions < previousValue.AmountOfRepetitions)
                    {
                        counted += previousValue.ArabicValue;
                        result += previousValue.RomanValue;
                        repetitions++;
                    }

                    // The number is found.
                    if (counted == n)
                    {
                        return result;
                    }

                    // If the part of the number is not complete, continue with smaller values.
                    if (counted != n && isFullNumber)
                    {
                        var subResult = Recursive(n - counted, previousValue.RomanValue, false);
                        if (!string.IsNullOrEmpty(subResult))
                        {
                            // We have found the number so we can return it.
                            return result + subResult;
                        }

                    }
                    else if (counted != n && !isFullNumber)
                    {
                        // Return as fail.
                        return null;
                    }
                }

                if (!isFullNumber)
                    return null;

                // The other methods didn't work, try with subtraction.
                result = MakeSubtraction(n);
            }

            return result;
        }

        private string MakeSubtraction(int arabicNumber)
        {
            var tempNumber = _values.GetNextRomanValue(arabicNumber).ArabicValue;
            var n = _values.GetPreviousSubtractableRomanValue(tempNumber);
            var result = _values.GetRomanValue(tempNumber).ToString();
            while (tempNumber > arabicNumber)
            {
                result = n.RomanValue + result;
                tempNumber = tempNumber - n.ArabicValue;
            }

            return result;
        }

        private int GetFullUnitNumber(int number)
        {
            return int.Parse("1".PadRight(number.ToString().Length + 1, '0'));
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
