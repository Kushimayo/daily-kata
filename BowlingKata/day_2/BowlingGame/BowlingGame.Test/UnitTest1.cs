using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Test
{
    [TestClass]
    public class UnitTest1
    {
        private Game game;
        [TestMethod]
        public void Game_인스턴스를_생성할수있다()
        {
            game = new Game();
        }

        private void RollManyTimes(int count, int pins)
        {
            for (int i = 0; i < count; i++)
            {
                game.roll(pins);
            }
        }

        [TestMethod]
        public void 전부0을굴리면0점()
        {
            game = new Game();
            RollManyTimes(20, 0);
            Assert.AreEqual(0, game.score());
        }

        [TestMethod]
        public void 전부1을굴리면20점()
        {
            game = new Game();
            RollManyTimes(20, 1);
            Assert.AreEqual(20, game.score());
        }

        [TestMethod]
        public void 스페어처리를하면첫점수는보너스()
        {
            game = new Game();
            game.roll(3);
            game.roll(7);
            game.roll(3);
            RollManyTimes(17, 0);
            Assert.AreEqual(16, game.score());
        }

        [TestMethod]
        public void 스트라익치면다음프레임점수는보너스()
        {
            game = new Game();
            game.roll(10);
            game.roll(3);
            game.roll(4);
            RollManyTimes(16, 0);
            Assert.AreEqual(24, game.score());
        }

    }
}
