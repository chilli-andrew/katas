using NUnit.Framework;

namespace Tennis
{
    [TestFixture]
    public class TestGame
    {
        [Test]
        public void NewGame_ShouldSetScore_0_0()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var game = new Game();

            //---------------Test Result -----------------------
            Assert.IsNotNull(game);
            Assert.AreEqual("0-0", game.Score);
        }

        [Test]
        public void ScoreToService_When_0_0_ShouldSetScore_15_0()
        {
            //---------------Set up test pack-------------------
            var game = new Game();
            //---------------Assert Precondition----------------
            Assert.AreEqual("0-0", game.Score);

            //---------------Execute Test ----------------------
            game.ScoreToService();
            //---------------Test Result -----------------------
            Assert.AreEqual("15-0", game.Score);
        }

        [Test]
        public void ScoreToReceiver_When_0_0_ShouldSetScore_0_15()
        {
            //---------------Set up test pack-------------------
            var game = new Game();
            //---------------Assert Precondition----------------
            Assert.AreEqual("0-0", game.Score);

            //---------------Execute Test ----------------------
            game.ScoreToReceiver();
            //---------------Test Result -----------------------
            Assert.AreEqual("0-15", game.Score);
        }

        [Test]
        public void ScoreToReceiver_When_15_15_ShouldSetScore_15_30()
        {
            //---------------Set up test pack-------------------
            var game = new Game();
            game.ScoreToService();
            game.ScoreToReceiver();
            //---------------Assert Precondition----------------
            Assert.AreEqual("15-15", game.Score);

            //---------------Execute Test ----------------------
            game.ScoreToReceiver();
            //---------------Test Result -----------------------
            Assert.AreEqual("15-30", game.Score);
        }

        [Test]
        public void ScoreToService_When_40_15_ShouldSetScore_GAME_15()
        {
            //---------------Set up test pack-------------------
            var game = new Game();
            game.ScoreToService();
            game.ScoreToService();
            game.ScoreToService();
            game.ScoreToReceiver();
            //---------------Assert Precondition----------------
            Assert.AreEqual("40-15", game.Score);

            //---------------Execute Test ----------------------
            game.ScoreToService();
            //---------------Test Result -----------------------
            Assert.AreEqual("GAME-15", game.Score);
        }

        [Test]
        public void ScoreToService_When_30_40_ShouldSetScore_DEUCE()
        {
            //---------------Set up test pack-------------------
            var game = new Game();
            game.ScoreToService();
            game.ScoreToService();
            game.ScoreToReceiver();
            game.ScoreToReceiver();
            game.ScoreToReceiver();
            //---------------Assert Precondition----------------
            Assert.AreEqual("30-40", game.Score);

            //---------------Execute Test ----------------------
            game.ScoreToService();
            //---------------Test Result -----------------------
            Assert.AreEqual("DEUCE", game.Score);
        }

        [Test]
        public void ScoreToService_When_DEUCE_ShouldSetScore_ADV_40()
        {
            //---------------Set up test pack-------------------
            var game = new Game();
            game.ScoreToService();
            game.ScoreToService();
            game.ScoreToService();

            game.ScoreToReceiver();
            game.ScoreToReceiver();
            game.ScoreToReceiver();
            //---------------Assert Precondition----------------
            Assert.AreEqual("DEUCE", game.Score);

            //---------------Execute Test ----------------------
            game.ScoreToService();
            //---------------Test Result -----------------------
            Assert.AreEqual("ADV-40", game.Score);
        }

        [Test]
        public void ScoreToReceiver_When_40_ADV_ShouldSetScore_40_GAME()
        {
            //---------------Set up test pack-------------------
            var game = new Game();
            game.ScoreToService();
            game.ScoreToService();
            game.ScoreToService();

            game.ScoreToReceiver();
            game.ScoreToReceiver();
            game.ScoreToReceiver();
            game.ScoreToReceiver();
            //---------------Assert Precondition----------------
            Assert.AreEqual("40-ADV", game.Score);

            //---------------Execute Test ----------------------
            game.ScoreToReceiver();
            //---------------Test Result -----------------------
            Assert.AreEqual("40-GAME", game.Score);
        }

        [Test]
        public void ScoreToReceiver_When_DEUCE_ShouldSetScore_40_ADV()
        {
            //---------------Set up test pack-------------------
            var game = new Game();
            game.ScoreToService();
            game.ScoreToService();
            game.ScoreToService();

            game.ScoreToReceiver();
            game.ScoreToReceiver();
            game.ScoreToReceiver();
            //---------------Assert Precondition----------------
            Assert.AreEqual("DEUCE", game.Score);

            //---------------Execute Test ----------------------
            game.ScoreToReceiver();
            //---------------Test Result -----------------------
            Assert.AreEqual("40-ADV", game.Score);
        }
    }
}