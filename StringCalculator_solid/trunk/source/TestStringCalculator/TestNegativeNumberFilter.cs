using System;
using System.Collections.Generic;
using NUnit.Framework;
using StringKata;

namespace TestStringCalculator
{
    [TestFixture]
    public class TestNegativeNumberFilter
    {
        [Test]
        public void Construct_ShouldNotError()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            Assert.DoesNotThrow(()=>new NegativeNumberFilter());
        }

        [Test]
        public void Filter_WhenNoNegativesAndOneNumber_ShouldReturnListWithNumber()
        {
            //---------------Set up test pack-------------------
            var numbers = new List<int> {1};
            var filter = CreateNegativeNumberFilter();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actualNumbers = filter.Filter(numbers);
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(numbers, actualNumbers);
        }

        [Test]
        public void Filter_WhenNoNegativesAndTwoNumbers_ShouldReturnListWithNumbers()
        {
            //---------------Set up test pack-------------------
            var numbers = new List<int> { 1, 2 };
            var filter = CreateNegativeNumberFilter();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actualNumbers = filter.Filter(numbers);
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(numbers, actualNumbers);
        }

        [Test]
        public void Filter_WhenNoNegativesAndManyNumbers_ShouldReturnListWithNumbers()
        {
            //---------------Set up test pack-------------------
            var numbers = new List<int> { 1, 2, 3 };
            var filter = CreateNegativeNumberFilter();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actualNumbers = filter.Filter(numbers);
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(numbers, actualNumbers);
        }

        [Test]
        public void Filter_WhenHasOneNegative_ShouldError()
        {
            //---------------Set up test pack-------------------
            var numbers = new List<int> { -2 };
            var filter = CreateNegativeNumberFilter();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ApplicationException>(() => filter.Filter(numbers));
            //---------------Test Result -----------------------
            Assert.AreEqual("Negatives not allowed: -2", ex.Message);
        }

        private static NegativeNumberFilter CreateNegativeNumberFilter()
        {
            var filter = new NegativeNumberFilter();
            return filter;
        }
    }
}