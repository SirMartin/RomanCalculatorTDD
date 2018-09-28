using NUnit.Framework;
using RomanCalculatorTDD;

namespace RomanCalculatorTDDTests
{
    [TestFixture]
    public class ConsistentRomanArabicConvertionTests
    {
        RomanCalculator _calculator;

        public ConsistentRomanArabicConvertionTests()
        {
            _calculator = new RomanCalculator();
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
            for (int i = 1; i <= 3000; i++)
            {
                Assert.AreEqual(i, _calculator.ToArabicNumber(_calculator.ToRomanNumber(i)));
            }
        }

    }
}
