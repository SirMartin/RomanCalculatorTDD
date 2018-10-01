using System.Collections.Generic;
using NUnit.Framework;
using RomanCalculatorTDD;
using RomanCalculatorTDD.Extensions;
using RomanCalculatorTDD.Models;

namespace RomanCalculatorTDDTests
{
    [TestFixture]
    public class RomanArabicModelExtensionsTests
    {
        private List<RomanArabicValue> _values;

        public RomanArabicModelExtensionsTests()
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

        [Test]
        public void GetRomanValueExtensionTests()
        {
            Assert.AreEqual('C', _values.GetRomanValue(100));
            Assert.AreEqual('D', _values.GetRomanValue(500));
        }

        [Test]
        public void GetNextRomanValueExtensionTests()
        {
            Assert.AreEqual('C', _values.GetNextRomanValue(70)?.RomanValue);
            Assert.AreEqual(null, _values.GetNextRomanValue(2000)?.RomanValue);
        }

        [Test]
        public void GetPreviousRomanValueExtensionTests()
        {
            Assert.AreEqual('L', _values.GetPreviousRomanValue(70)?.RomanValue);
            Assert.AreEqual('M', _values.GetPreviousRomanValue(2000)?.RomanValue);
        }

        [Test]
        public void GetPreviousSubtractableRomanValueExtensionTests()
        {
            Assert.AreEqual('X', _values.GetPreviousSubtractableRomanValue(70)?.RomanValue);
            Assert.AreEqual('I', _values.GetPreviousSubtractableRomanValue(9)?.RomanValue);
        }

        [Test]
        public void GetArabicValueExtensionTests()
        {
            Assert.AreEqual(10, _values.GetArabicValue('X'));
            Assert.AreEqual(50, _values.GetArabicValue('L'));
        }
    }
}
