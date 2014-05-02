using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using StringKata;

namespace TestStringCalculator
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class TestStringCalculator
    {
        [Test]
        public void Construct_WhenStringParserIsNull_ShouldError()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ArgumentNullException>(() => new StringCalculator(null, new List<INumberFilter>()));
            //---------------Test Result -----------------------
            Assert.AreEqual("stringParser", ex.ParamName);
        }

        [Test]
        public void Add_WhenInputIsEmptyString_ShouldReturn0()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add("");
            //---------------Test Result -----------------------
            Assert.AreEqual(0, result);
        }        
        
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void Add_WhenInputHasSingleNumber_ShouldReturnNumber(string input, int expected)
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_WhenInputHasTwoNumbers_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add("1,2");
            //---------------Test Result -----------------------
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_WhenInputHasManyNumbers_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add("1,2,3");
            //---------------Test Result -----------------------
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_WhenInputHasNewLine_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add("1,2\n3");
            //---------------Test Result -----------------------
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_WhenInputHasCustomDelimiter_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add("//;\n2;4;6");
            //---------------Test Result -----------------------
            Assert.AreEqual(12, result);
        }

        [Test]
        public void Add_WhenInputHasNegatives_ShouldError()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ApplicationException>(() => calculator.Add("1,-2,3,-4,-5"));
            //---------------Test Result -----------------------
            Assert.AreEqual("Negatives not allowed: -2,-4,-5", ex.Message);
        }

        [Test]
        public void Add_WhenInputHasNumbersGreaterThan1000_ShouldReturnFilterAndSum()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add("1,2,1000,1001");
            //---------------Test Result -----------------------
            Assert.AreEqual(1003, result);
        }

        [Test]
        public void Add_WhenHasOneNumberFilter_ShouldCallNumberFilter()
        {
            //---------------Set up test pack-------------------
            var numberFilter = Substitute.For<INumberFilter>();
            var numberFilters = new List<INumberFilter> {numberFilter};
            var stringCalculator = CreateStringCalculatorWithFakes(numberFilters);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = stringCalculator.Add("1,2,3");
            //---------------Test Result -----------------------
            numberFilter.Received().Filter(Arg.Any<IEnumerable<int>>());
        }

        [Test]
        public void Add_WhenHasTwoNumberFilters_ShouldCallNumberFilters()
        {
            //---------------Set up test pack-------------------
            var numberFilter = Substitute.For<INumberFilter>();
            var numberFilter2 = Substitute.For<INumberFilter>();
            var numberFilters = new List<INumberFilter> {numberFilter, numberFilter2};
            var stringCalculator = CreateStringCalculatorWithFakes(numberFilters);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = stringCalculator.Add("1,2,3");
            //---------------Test Result -----------------------
            numberFilter.Received().Filter(Arg.Any<IEnumerable<int>>());
            numberFilter2.Received().Filter(Arg.Any<IEnumerable<int>>());
        }

        [Test]
        public void Add_WhenHasManyNumberFilters_ShouldCallNumberFilters()
        {
            //---------------Set up test pack-------------------
            var numberFilter = Substitute.For<INumberFilter>();
            var numberFilter2 = Substitute.For<INumberFilter>();
            var numberFilter3 = Substitute.For<INumberFilter>();
            var numberFilters = new List<INumberFilter> { numberFilter, numberFilter2, numberFilter3 };
            var stringCalculator = CreateStringCalculatorWithFakes(numberFilters);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = stringCalculator.Add("1,2,3");
            //---------------Test Result -----------------------
            numberFilter.Received().Filter(Arg.Any<IEnumerable<int>>());
            numberFilter2.Received().Filter(Arg.Any<IEnumerable<int>>());
            numberFilter3.Received().Filter(Arg.Any<IEnumerable<int>>());
        }

        private static StringCalculator CreateStringCalculatorWithFakes(List<INumberFilter> numberFilters)
        {
            var stringParser = Substitute.For<IStringParser>();
            stringParser.ParseNumbers(Arg.Any<string>()).Returns(new List<int>());
            var stringCalculator = new StringCalculator(stringParser, numberFilters);
            return stringCalculator;
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator(new StringParser(), new List<INumberFilter> {new NegativeNumberFilter(), new NumbersGreaterThan1000Filter()});
        }
    }
}