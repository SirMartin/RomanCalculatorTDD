using System.Collections.Generic;
using NUnit.Framework;
using RomanCalculatorTDD.Extensions;
using RomanCalculatorTDD.Models;

namespace RomanCalculatorTDDTests
{
    [TestFixture]
    public class RomanArabicModelExtensionsTests
    {
        private readonly List<RomanArabicValue> _values;

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
            Assert.AreEqual('I', _values.GetRomanValue(1));
            Assert.AreEqual('C', _values.GetRomanValue(100));
            Assert.AreEqual('D', _values.GetRomanValue(500));
            Assert.AreEqual(null, _values.GetRomanValue(333));

            Assert.AreEqual('I', _values.GetRomanValueModel(1)?.RomanValue);
            Assert.AreEqual('C', _values.GetRomanValueModel(100)?.RomanValue);
            Assert.AreEqual('D', _values.GetRomanValueModel(500)?.RomanValue);
            Assert.AreEqual(null, _values.GetRomanValueModel(333)?.RomanValue);
        }

        [Test]
        public void GetNextRomanValueExtensionTests()
        {
            Assert.AreEqual('V', _values.GetNextRomanValue(2)?.RomanValue);
            Assert.AreEqual('C', _values.GetNextRomanValue(70)?.RomanValue);
            Assert.AreEqual(null, _values.GetNextRomanValue(2000)?.RomanValue);
        }

        [Test]
        public void GetPreviousRomanValueExtensionTests()
        {
            Assert.AreEqual(null, _values.GetPreviousRomanValue(1)?.RomanValue);
            Assert.AreEqual('L', _values.GetPreviousRomanValue(70)?.RomanValue);
            Assert.AreEqual('M', _values.GetPreviousRomanValue(2000)?.RomanValue);
        }

        [Test]
        public void GetPreviousSubtractableRomanValueExtensionTests()
        {
            Assert.AreEqual(null, _values.GetPreviousSubtractableRomanValue(1)?.RomanValue);
            Assert.AreEqual('I', _values.GetPreviousSubtractableRomanValue(9)?.RomanValue);
            Assert.AreEqual('X', _values.GetPreviousSubtractableRomanValue(70)?.RomanValue);
        }

        [Test]
        public void GetArabicValueExtensionTests()
        {
            Assert.AreEqual(1, _values.GetArabicValue('I'));
            Assert.AreEqual(10, _values.GetArabicValue('X'));
            Assert.AreEqual(50, _values.GetArabicValue('L'));
            Assert.AreEqual(null, _values.GetArabicValue('P'));

            Assert.AreEqual(1, _values.GetArabicValueModel('I')?.ArabicValue);
            Assert.AreEqual(10, _values.GetArabicValueModel('X')?.ArabicValue);
            Assert.AreEqual(50, _values.GetArabicValueModel('L')?.ArabicValue);
            Assert.AreEqual(null, _values.GetArabicValueModel('P')?.ArabicValue);
        }

        [Test]
        public void GetMaximunNextRomanValueTests()
        {
            Assert.AreEqual('X', _values.GetMaximunNextRomanValue('I')?.RomanValue);
            Assert.AreEqual('C', _values.GetMaximunNextRomanValue('X')?.RomanValue);
            Assert.AreEqual(null, _values.GetMaximunNextRomanValue('M')?.RomanValue);
        }
        
    }
}
