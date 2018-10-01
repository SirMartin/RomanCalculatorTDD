using System.Collections.Generic;
using NUnit.Framework;
using RomanCalculatorTDD;
using RomanCalculatorTDD.Models;

namespace RomanCalculatorTDDTests
{
    [TestFixture]
    public class ConsistentRomanArabicConvertionTests
    {
        RomanCalculator _calculator;

        private List<RomanArabicValue> _values;

        public ConsistentRomanArabicConvertionTests()
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

            _calculator = new RomanCalculator(_values);
        }

        [Test]
        public void RomanToArabicToRomanTest()
        {
            var romanNumber = "II";
            Assert.AreEqual(romanNumber, _calculator.ToRomanNumber(_calculator.ToArabicNumber(romanNumber)));

            romanNumber = "XC";
            Assert.AreEqual(romanNumber, _calculator.ToRomanNumber(_calculator.ToArabicNumber(romanNumber)));

            romanNumber = "CMXCIX";
            Assert.AreEqual(romanNumber, _calculator.ToRomanNumber(_calculator.ToArabicNumber(romanNumber)));

            romanNumber = "MCMXCIX";
            Assert.AreEqual(romanNumber, _calculator.ToRomanNumber(_calculator.ToArabicNumber(romanNumber)));

            romanNumber = "MMCDXLIV";
            Assert.AreEqual(romanNumber, _calculator.ToRomanNumber(_calculator.ToArabicNumber(romanNumber)));

            romanNumber = "DCCCXCIX";
            Assert.AreEqual(romanNumber, _calculator.ToRomanNumber(_calculator.ToArabicNumber(romanNumber)));

            romanNumber = "CXXXIII";
            Assert.AreEqual(romanNumber, _calculator.ToRomanNumber(_calculator.ToArabicNumber(romanNumber)));

            romanNumber = "MMMCCCXXXIII";
            Assert.AreEqual(romanNumber, _calculator.ToRomanNumber(_calculator.ToArabicNumber(romanNumber)));
        }

        [Test]
        public void ArabicToRomanToArabicTest()
        {
            for (int i = 1; i <= 3999; i++)
            {
                Assert.AreEqual(i, _calculator.ToArabicNumber(_calculator.ToRomanNumber(i)));
            }
        }

    }
}
