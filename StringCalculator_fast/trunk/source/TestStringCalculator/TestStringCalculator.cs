using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using StringKata;

namespace TestStringCalculator
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class TestStringCalculator
    {
        [Test]
        public void Add_WhenEmptyString_ShouldReturn0()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add("");
            //---------------Test Result -----------------------
            Assert.AreEqual(0, result);
        }        
        
        [Test]
        public void Add_WhenSingleNumberString_ShouldReturnNumber()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add("12");
            //---------------Test Result -----------------------
            Assert.AreEqual(12, result);
        }   
     
        [Test]
        public void Add_WhenTwoNumberString_ShouldReturnSum()
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
        public void Add_WhenManyNumberString_ShouldReturnSum()
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
        public void Add_WhenManyNumberStringAndHasNewLineDelimiter_ShouldReturnSum()
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
        public void Add_WhenHasCustomDelimiter_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add("//;\n1;3;5");
            //---------------Test Result -----------------------
            Assert.AreEqual(9, result);
        }

        [Test]
        public void Add_WhenHasNegatives_ShouldError()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ApplicationException>(() => calculator.Add("1,-2,-3"));
            //---------------Test Result -----------------------
            Assert.AreEqual("negatives not allowed -2,-3",ex.Message);
        }


        [Test]
        public void Add_WhenHasNumbersGreaterThan1000_ShouldFilterAndSum()
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
        public void Add_WhenHasMultiCharCustomDelimiter_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add("//[***]\n1***2");
            //---------------Test Result -----------------------
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_WhenHasMultipleCustomDelimiters_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add("//[*][%][&]\n1*2%3&4");
            //---------------Test Result -----------------------
            Assert.AreEqual(10, result);
        }

        [Test]
        public void GetDelimiters_WhenHasNoCustomDelimiter_ShouldReturnDefaultDelimiters()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.GetDelimiters("1,2,3");
            //---------------Test Result -----------------------
            Assert.AreEqual(2, result.Count());
            CollectionAssert.Contains(result, ",");
            CollectionAssert.Contains(result, "\n");
        }

        [Test]
        public void GetDelimiters_WhenHasCustomDelimiter_ShouldReturnDefaultDelimiters()
        {
            //---------------Set up test pack-------------------
            var calculator = CreateStringCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.GetDelimiters("//;\n1;3;5");
            //---------------Test Result -----------------------
            Assert.AreEqual(3, result.Count());
            CollectionAssert.Contains(result, ",");
            CollectionAssert.Contains(result, "\n");
            CollectionAssert.Contains(result, ";");
        }

        private static StringCalculator CreateStringCalculator()
        {
            var calculator = new StringCalculator();
            return calculator;
        }
    }
}
