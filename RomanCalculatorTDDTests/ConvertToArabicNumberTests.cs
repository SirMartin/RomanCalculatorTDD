using NUnit.Framework;
using RomanCalculatorTDD;

namespace RomanCalculatorTDDTests
{
    [TestFixture]
    public class ConvertToArabicNumberTests
    {
        RomanCalculator _calculator;

        public ConvertToArabicNumberTests()
        {
            _calculator = new RomanCalculator();
        }

        [Test]
        public void BasicNumberToArabicTest()
        {
            Assert.AreEqual(1, _calculator.ToArabicNumber("I"));
            Assert.AreEqual(5, _calculator.ToArabicNumber("V"));
            Assert.AreEqual(10, _calculator.ToArabicNumber("X"));
            Assert.AreEqual(50, _calculator.ToArabicNumber("L"));
            Assert.AreEqual(100, _calculator.ToArabicNumber("C"));
            Assert.AreEqual(500, _calculator.ToArabicNumber("D"));
            Assert.AreEqual(1000, _calculator.ToArabicNumber("M"));
        }

        [Test]
        public void AddingBasicNumberToArabicTest()
        {
            Assert.AreEqual(2, _calculator.ToArabicNumber("II"));
            Assert.AreEqual(3, _calculator.ToArabicNumber("III"));

            Assert.AreEqual(20, _calculator.ToArabicNumber("XX"));
            Assert.AreEqual(30, _calculator.ToArabicNumber("XXX"));

            Assert.AreEqual(200, _calculator.ToArabicNumber("CC"));
            Assert.AreEqual(300, _calculator.ToArabicNumber("CCC"));

            Assert.AreEqual(2000, _calculator.ToArabicNumber("MM"));
            Assert.AreEqual(3000, _calculator.ToArabicNumber("MMM"));
        }

        [Test]
        public void AddingMixNumberToArabicTest()
        {
            Assert.AreEqual(6, _calculator.ToArabicNumber("VI"));
            Assert.AreEqual(7, _calculator.ToArabicNumber("VII"));
            Assert.AreEqual(8, _calculator.ToArabicNumber("VIII"));

            Assert.AreEqual(11, _calculator.ToArabicNumber("XI"));
            Assert.AreEqual(13, _calculator.ToArabicNumber("XIII"));
            Assert.AreEqual(15, _calculator.ToArabicNumber("XV"));
            Assert.AreEqual(17, _calculator.ToArabicNumber("XVII"));

            Assert.AreEqual(22, _calculator.ToArabicNumber("XXII"));
            Assert.AreEqual(25, _calculator.ToArabicNumber("XXV"));
            Assert.AreEqual(28, _calculator.ToArabicNumber("XXVIII"));

            Assert.AreEqual(33, _calculator.ToArabicNumber("XXXIII"));
            Assert.AreEqual(35, _calculator.ToArabicNumber("XXXV"));

            Assert.AreEqual(51, _calculator.ToArabicNumber("LI"));

            Assert.AreEqual(76, _calculator.ToArabicNumber("LXXVI"));

            Assert.AreEqual(102, _calculator.ToArabicNumber("CII"));
            Assert.AreEqual(125, _calculator.ToArabicNumber("CXXV"));
            Assert.AreEqual(133, _calculator.ToArabicNumber("CXXXIII"));

            Assert.AreEqual(502, _calculator.ToArabicNumber("DII"));
            Assert.AreEqual(600, _calculator.ToArabicNumber("DC"));
            Assert.AreEqual(766, _calculator.ToArabicNumber("DCCLXVI"));

            Assert.AreEqual(1060, _calculator.ToArabicNumber("MLX"));

            Assert.AreEqual(3333, _calculator.ToArabicNumber("MMMCCCXXXIII"));
        }

        [Test]
        public void SubstractNumberToArabicTest()
        {
            Assert.AreEqual(4, _calculator.ToArabicNumber("IV"));
            Assert.AreEqual(9, _calculator.ToArabicNumber("IX"));
            Assert.AreEqual(40, _calculator.ToArabicNumber("XL"));
            Assert.AreEqual(90, _calculator.ToArabicNumber("XC"));
            Assert.AreEqual(400, _calculator.ToArabicNumber("CD"));
            Assert.AreEqual(900, _calculator.ToArabicNumber("CM"));
        }

        [Test]
        public void SubstractMixNumberToArabicTest()
        {
            Assert.AreEqual(90, _calculator.ToArabicNumber("XC"));
            Assert.AreEqual(95, _calculator.ToArabicNumber("XCV"));
            Assert.AreEqual(99, _calculator.ToArabicNumber("XCIX"));
            Assert.AreEqual(400, _calculator.ToArabicNumber("CD"));
            Assert.AreEqual(899, _calculator.ToArabicNumber("DCCCXCIX"));
            Assert.AreEqual(924, _calculator.ToArabicNumber("CMXXIV"));
            Assert.AreEqual(1999, _calculator.ToArabicNumber("MCMXCIX"));
            Assert.AreEqual(2444, _calculator.ToArabicNumber("MMCDXLIV"));
        }

        [Test]
        public void SuggestedNumbersToRomanTest()
        {
            Assert.AreEqual(90, _calculator.ToArabicNumber("XC"));
            Assert.AreEqual(999, _calculator.ToArabicNumber("CMXCIX"));
            Assert.AreEqual(1999, _calculator.ToArabicNumber("MCMXCIX"));
            Assert.AreEqual(2444, _calculator.ToArabicNumber("MMCDXLIV"));
        }

        [Test]
        public void InvalidNumbersByRepetitionToArabicTest()
        {
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("IIII"));
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("VVV"));
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("XXXX"));
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("LL"));
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("CCCC"));
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("DD"));
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("MMMM"));

            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("XXVVI"));
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("XXXXI"));
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("CCIIII"));
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("MMMMXVI"));
        }

        [Test]
        public void InvalidNumbersByPositionArabicTest()
        {
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("VX"));
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("VC"));
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("LC"));
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("DM"));
            Assert.Throws<InvalidRomanNumberException>(() => _calculator.ToArabicNumber("IM"));
        }
    }
}
