using NUnit.Framework;
using RomanCalculatorTDD;

namespace RomanCalculatorTDDTests
{
    [TestFixture]
    public class ConvertToRomanNumberTests
    {
        RomanCalculator _calculator;

        public ConvertToRomanNumberTests()
        {
            _calculator = new RomanCalculator();
        }

        [Test]
        public void BasicNumberToRomanTest()
        {
            Assert.AreEqual("I", _calculator.ToRomanNumber(1));
            Assert.AreEqual("V", _calculator.ToRomanNumber(5));
            Assert.AreEqual("X", _calculator.ToRomanNumber(10));
            Assert.AreEqual("L", _calculator.ToRomanNumber(50));
            Assert.AreEqual("C", _calculator.ToRomanNumber(100));
            Assert.AreEqual("D", _calculator.ToRomanNumber(500));
            Assert.AreEqual("M", _calculator.ToRomanNumber(1000));
        }

        [Test]
        public void AddingNumberToRomanTest()
        {
            Assert.AreEqual("II", _calculator.ToRomanNumber(2));
            Assert.AreEqual("III", _calculator.ToRomanNumber(3));
            Assert.AreEqual("XV", _calculator.ToRomanNumber(15));
            Assert.AreEqual("XX", _calculator.ToRomanNumber(20));
            Assert.AreEqual("LX", _calculator.ToRomanNumber(60));
            Assert.AreEqual("LXV", _calculator.ToRomanNumber(65));
            Assert.AreEqual("CC", _calculator.ToRomanNumber(200));
            Assert.AreEqual("CCXXVI", _calculator.ToRomanNumber(226));
            Assert.AreEqual("MCCCXXI", _calculator.ToRomanNumber(1321));
            Assert.AreEqual("MMCCXXII", _calculator.ToRomanNumber(2222));
        }

        [Test]
        public void SubstractNumberToRomanTest()
        {
            Assert.AreEqual("IV", _calculator.ToRomanNumber(4));
            Assert.AreEqual("XC", _calculator.ToRomanNumber(90));
            Assert.AreEqual("XCV", _calculator.ToRomanNumber(95));
            Assert.AreEqual("XCIX", _calculator.ToRomanNumber(99));
            Assert.AreEqual("CD", _calculator.ToRomanNumber(400));
            Assert.AreEqual("DCCCXCIX", _calculator.ToRomanNumber(899));
            Assert.AreEqual("CMXXIV", _calculator.ToRomanNumber(924));
            Assert.AreEqual("MCMXCIX", _calculator.ToRomanNumber(1999));
            Assert.AreEqual("MMCDXLIV", _calculator.ToRomanNumber(2444));
            Assert.AreEqual("MMMCMXCIX", _calculator.ToRomanNumber(3999));
        }

        [Test]
        public void SuggestedNumbersToRomanTest()
        {
            Assert.AreEqual("XC", _calculator.ToRomanNumber(90));
            Assert.AreEqual("CMXCIX", _calculator.ToRomanNumber(999));
            Assert.AreEqual("MCMXCIX", _calculator.ToRomanNumber(1999));
            Assert.AreEqual("MMCDXLIV", _calculator.ToRomanNumber(2444));
        }

        [Test]
        public void InvalidArabicNumbers()
        {
            Assert.Throws<InvalidArabicNumberException>(() => _calculator.ToRomanNumber(-5));
            Assert.Throws<InvalidArabicNumberException>(() => _calculator.ToRomanNumber(0));
            Assert.Throws<TooBigArabicNumberException>(() => _calculator.ToRomanNumber(4000));
        }
    }
}
