using CalculatorProgram;

using NUnit.Framework.Legacy;


namespace CalculatorTestsProgram
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_WhenCalled_ReturnsSumOfArguments()
        {
            var result = _calculator.Add(1, 2);
            ClassicAssert.AreEqual(3, result);
        }

        [Test]
        public void Subtract_WhenCalled_ReturnsDifferenceOfArguments()
        {
            var result = _calculator.Subtract(5, 3);
            ClassicAssert.AreEqual(2, result);
        }
    }
}