using System;
using System.Collections.Generic;
using NUnit.Framework;
using StringKata;

namespace TestStringCalculator
{
    [TestFixture]
    public class TestNumbersGreaterThan1000Filter
    {
        [Test]
        public void Construct_ShouldNotError()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            Assert.DoesNotThrow(()=>new NumbersGreaterThan1000Filter());
        }

        [Test]
        public void Filter_WhenOneNumberLT1000_ShouldReturnListWithNumber()
        {
            //---------------Set up test pack-------------------
            var numbers = new List<int> {1};
            var filter = CreateNumbersGreaterThan1000Filter();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actualNumbers = filter.Filter(numbers);
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(numbers, actualNumbers);
        }

        [Test]
        public void Filter_WhenTwoNumbersLT1000_ShouldReturnListWithNumbers()
        {
            //---------------Set up test pack-------------------
            var numbers = new List<int> {1, 2};
            var filter = CreateNumbersGreaterThan1000Filter();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actualNumbers = filter.Filter(numbers);
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(numbers, actualNumbers);
        }

        [Test]
        public void Filter_WhenManyNumbersLT1000_ShouldReturnListWithNumbers()
        {
            //---------------Set up test pack-------------------
            var numbers = new List<int> {1, 2, 3};
            var filter = CreateNumbersGreaterThan1000Filter();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actualNumbers = filter.Filter(numbers);
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(numbers, actualNumbers);
        }

        [Test]
        public void Filter_WhenHasNumber1000_ShouldReturnListWithNumber()
        {
            //---------------Set up test pack-------------------
            var numbers = new List<int> {1000};
            var filter = CreateNumbersGreaterThan1000Filter();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actualNumbers = filter.Filter(numbers);
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(numbers, actualNumbers);
        }

        [Test]
        public void Filter_WhenHasNumberGT1000_ShouldReturnFilteredListWithNumbers()
        {
            //---------------Set up test pack-------------------
            var numbers = new List<int> {1, 2 ,1000, 1001};
            var filter = CreateNumbersGreaterThan1000Filter();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actualNumbers = filter.Filter(numbers);
            //---------------Test Result -----------------------
            var expectedNumbers = new List<int> {1, 2, 1000};
            CollectionAssert.AreEqual(expectedNumbers, actualNumbers);
        }

        [Test]
        public void Filter_WhenHasManyNumbersGT1000_ShouldReturnFilteredListWithNumbers()
        {
            //---------------Set up test pack-------------------
            var numbers = new List<int> { 2002, 3003, 1, 2 ,1000, 1001};
            var filter = CreateNumbersGreaterThan1000Filter();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actualNumbers = filter.Filter(numbers);
            //---------------Test Result -----------------------
            var expectedNumbers = new List<int> {1, 2, 1000};
            CollectionAssert.AreEqual(expectedNumbers, actualNumbers);
        }

        private static NumbersGreaterThan1000Filter CreateNumbersGreaterThan1000Filter()
        {
            var filter = new NumbersGreaterThan1000Filter();
            return filter;
        }

    }
}