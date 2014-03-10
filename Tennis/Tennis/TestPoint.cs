using System;
using NUnit.Framework;

namespace Tennis
{
    [TestFixture]
    public class TestPoint
    {
        // ReSharper disable InconsistentNaming
        [Test]
        public void NewPoint_ShouldSetToString_0()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var point = new Point();
            //---------------Test Result -----------------------
            Assert.IsNotNull(point);
            Assert.AreEqual(Point.LOVE, point.ToString());
        }

        [Test]
        public void Score_When_0_ShouldSetToString_15()
        {
            //---------------Set up test pack-------------------
            var point = new Point();
            //---------------Assert Precondition----------------
            Assert.AreEqual(Point.LOVE, point.ToString(), "PRE CONDITION");
            //---------------Execute Test ----------------------
            point.Score(new Point());
            //---------------Test Result -----------------------
            Assert.AreEqual(Point.FIFTEEN, point.ToString());
        }

        [Test]
        public void Score_When_15_ShouldSetToString_30()
        {
            //---------------Set up test pack-------------------
            var point = new Point();
            point.Score(new Point());
            //---------------Assert Precondition----------------
            Assert.AreEqual(Point.FIFTEEN, point.ToString(), "PRE CONDITION");
            //---------------Execute Test ----------------------
            point.Score(new Point());
            //---------------Test Result -----------------------
            Assert.AreEqual(Point.THIRTY, point.ToString());
        }

        [Test]
        public void Score_When_30_ShouldSetToString_40()
        {
            //---------------Set up test pack-------------------
            var point = new Point();
            point.Score(new Point());
            point.Score(new Point());
            //---------------Assert Precondition----------------
            Assert.AreEqual(Point.THIRTY, point.ToString(), "PRE CONDITION");
            //---------------Execute Test ----------------------
            point.Score(new Point());
            //---------------Test Result -----------------------
            Assert.AreEqual(Point.FORTY, point.ToString());
        }

        [Test]
        public void Score_When_40_ShouldSetToString_GAME()
        {
            //---------------Set up test pack-------------------
            var point = new Point();
            point.Score(new Point());
            point.Score(new Point());
            point.Score(new Point());
            //---------------Assert Precondition----------------
            Assert.AreEqual(Point.FORTY, point.ToString(), "PRE CONDITION");
            //---------------Execute Test ----------------------
            point.Score(new Point());
            //---------------Test Result -----------------------
            Assert.AreEqual(Point.GAME, point.ToString());
        }

        [Test]
        public void Score_When_40_40_ShouldSetToString_ADV()
        {
            //---------------Set up test pack-------------------
            var point = new Point();
            var opponentPoint = new Point();
            point.Score(opponentPoint);
            point.Score(opponentPoint);
            point.Score(opponentPoint);
            opponentPoint.Score(point);
            opponentPoint.Score(point);
            opponentPoint.Score(point);
            //---------------Assert Precondition----------------
            Assert.AreEqual(Point.FORTY, point.ToString(), "PRE CONDITION");
            Assert.AreEqual(Point.FORTY, opponentPoint.ToString(), "PRE CONDITION");
            //---------------Execute Test ----------------------
            point.Score(opponentPoint);
            //---------------Test Result -----------------------
            Assert.AreEqual(Point.ADVANTAGE, point.ToString());
        }

        [Test]
        public void Score_When_40_ADV_ShouldSetToString_40()
        {
            //---------------Set up test pack-------------------
            var point = new Point();
            var opponentPoint = new Point();
            point.Score(opponentPoint);
            point.Score(opponentPoint);
            point.Score(opponentPoint);
            opponentPoint.Score(point);
            opponentPoint.Score(point);
            opponentPoint.Score(point);
            opponentPoint.Score(point);
            //---------------Assert Precondition----------------
            Assert.AreEqual(Point.FORTY, point.ToString(), "PRE CONDITION");
            Assert.AreEqual(Point.ADVANTAGE, opponentPoint.ToString(), "PRE CONDITION");
            //---------------Execute Test ----------------------
            point.Score(opponentPoint);
            //---------------Test Result -----------------------
            Assert.AreEqual(Point.FORTY, point.ToString());
        }

        [Test]
        public void Score_When_ADV_40_ShouldSetToString_GAME()
        {
            //---------------Set up test pack-------------------
            var point = new Point();
            var opponentPoint = new Point();
            point.Score(opponentPoint);
            point.Score(opponentPoint);
            point.Score(opponentPoint);
            opponentPoint.Score(point);
            opponentPoint.Score(point);
            opponentPoint.Score(point);
            point.Score(opponentPoint);
            //---------------Assert Precondition----------------
            Assert.AreEqual(Point.ADVANTAGE, point.ToString(), "PRE CONDITION");
            Assert.AreEqual(Point.FORTY, opponentPoint.ToString(), "PRE CONDITION");
            //---------------Execute Test ----------------------
            point.Score(opponentPoint);
            //---------------Test Result -----------------------
            Assert.AreEqual(Point.GAME, point.ToString());
        }

        [Test]
        public void Score_When_GAME_0_ShouldError()
        {
            //---------------Set up test pack-------------------
            var point = new Point();
            var opponentPoint = new Point();
            point.Score(opponentPoint);
            point.Score(opponentPoint);
            point.Score(opponentPoint);
            point.Score(opponentPoint);
            //---------------Assert Precondition----------------
            Assert.AreEqual(Point.GAME, point.ToString(), "PRE CONDITION");
            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ApplicationException>(() => point.Score(opponentPoint));
            //---------------Test Result -----------------------
            StringAssert.Contains("Game already completed!", ex.Message);
        }
    }
}