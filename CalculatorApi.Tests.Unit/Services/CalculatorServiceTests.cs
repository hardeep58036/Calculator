using CalculatorApi.Services;
using NUnit.Framework;

namespace Tests
{
    public class CalculatorServiceTests
    {
        ICalculatorService _testObject;

        [SetUp]
        public void Setup()
        {
            _testObject = new CalculatorService();
        }

        [TestCase(3, 4, ExpectedResult = 7)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(-1, 1, ExpectedResult = 0)]
        public double Add_two_numbers(double number1, double number2)
        {
            return  _testObject.Add(number1, number2);
        }

        [TestCase(3, 4, ExpectedResult = -1)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(1, 1, ExpectedResult = 0)]
        [TestCase(-1, 1, ExpectedResult = -2)]
        [TestCase(10, 3, ExpectedResult = 7)]
        public double subtract_two_numbers(double number1, double number2)
        {
            return _testObject.Subtract(number1, number2);
        }

        [TestCase(10, 5, ExpectedResult = 2)]
        [TestCase(10, 3, ExpectedResult = 3.33)]
        [TestCase(100, 6, ExpectedResult = 16.67)]
        public double Divide_two_numbers(double number1, double number2)
        {
            return _testObject.Divide(number1, number2);
        }

        [Test]
        public void Divide_two_numbers_by_zero()
        {
            var result = _testObject.Divide(10, 0);
            Assert.True(double.IsInfinity(result));
        }


        [TestCase(10, 5, ExpectedResult =50)]
        [TestCase(0, 0, ExpectedResult =0)]
        [TestCase(2.5, 2, ExpectedResult = 5)]
        [TestCase(-2, -4, ExpectedResult = 8)]
        [TestCase(-3, 5, ExpectedResult = -15)]
        public double Multiply_two_numbers(double number1, double number2)
        {
            return _testObject.Multiply(number1, number2);
        }

    }
}