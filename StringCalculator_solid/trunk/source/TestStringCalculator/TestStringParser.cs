using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using NUnit.Framework;
using StringKata;

namespace TestStringCalculator
{
    [TestFixture]
    public class TestStringParser
    {
        [Test]
        public void Construct_ShouldNotError()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            Assert.DoesNotThrow(()=>new StringParser());
        }

        [Test]
        public void ParseDelimiters_WhenHasNoCustomDelimiters_ShouldReturnDefaultDelimiters()
        {
            //---------------Set up test pack-------------------
            var stringParser = new StringParser();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var delimiters = stringParser.ParseDelimiters("1,2,3");
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(new string[] {",","\n"}, delimiters);
        }

        [Test]
        public void ParseDelimiters_WhenHasHasCustomDelimiterOfSemiColon_ShouldReturnCustomDelimiter()
        {
            //---------------Set up test pack-------------------
            var stringParser = new StringParser();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var delimiters = stringParser.ParseDelimiters("//;\n1;2");
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(new string[] {";"}, delimiters);
        }

        [Test]
        public void ParseDelimiters_WhenHasHasCustomDelimiterOfDollar_ShouldReturnCustomDelimiter()
        {
            //---------------Set up test pack-------------------
            var stringParser = new StringParser();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var delimiters = stringParser.ParseDelimiters("//$\n4$5");
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(new[] {"$"}, delimiters);
        } 

        [Test]
        public void ParseDelimiters_WhenHasHasMultiCharCustomDelimiter_ShouldReturnCustomDelimiter()
        {
            //---------------Set up test pack-------------------
            var stringParser = new StringParser();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var delimiters = stringParser.ParseDelimiters("//[***]\n1***2");
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(new[] {"***"}, delimiters);
        }

        [Test]
        public void ParseDelimiters_WhenHasHasManyCustomDelimiters_ShouldReturnCustomDelimiters()
        {
            //---------------Set up test pack-------------------
            var stringParser = new StringParser();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var delimiters = stringParser.ParseDelimiters("//[*][$][#]\n1*2");
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(new[] {"*", "$", "#"}, delimiters);
        }        
        
        [Test]
        public void ParseNumbers_WhenHasCustomDelimiter_ShouldReturnDelimitedNumbersList()
        {
            //---------------Set up test pack-------------------
            var stringParser = new StringParser();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var numbers = stringParser.ParseNumbers("//$\n4$5");
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(new List<int> {4,5}, numbers);
        }
    }
}