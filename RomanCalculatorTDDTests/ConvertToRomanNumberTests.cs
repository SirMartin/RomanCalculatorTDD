﻿using NUnit.Framework;
using RomanCalculatorTDD;
using RomanCalculatorTDD.Extensions;

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
            Assert.AreEqual(4, _calculator.ToArabicNumber("IV"));
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
            //Assert.AreEqual("XC", _calculator.ToRomanNumber(90));
            //Assert.AreEqual("CMXCIX", _calculator.ToRomanNumber(999));
            //Assert.AreEqual("MCMXCIX", _calculator.ToRomanNumber(1999));
            //Assert.AreEqual("MMCDXLIV", _calculator.ToRomanNumber(2444));
        }

        [Test]
        public void InvalidArabicNumbers()
        {
            Assert.Throws<InvalidArabicNumberException>(() => _calculator.ToRomanNumber(-5));
            Assert.Throws<InvalidArabicNumberException>(() => _calculator.ToRomanNumber(0));
            Assert.Throws<TooBigArabicNumberException>(() => _calculator.ToRomanNumber(3334));
        }

        [Test]
        public void PreviousAndNextValues()
        {
            Assert.AreEqual('X', _calculator.values.GetPreviousRomanValue(20));
            Assert.AreEqual('L', _calculator.values.GetNextRomanValue(20));

            Assert.AreEqual('M', _calculator.values.GetPreviousRomanValue(2000));
            Assert.AreEqual(null, _calculator.values.GetNextRomanValue(2000));
        }


    }
}