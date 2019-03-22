using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Test
{
    [TestClass]
    public class UnitTest1
    {
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            game = new Game();
        }

        private void rollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                game.roll(pins);
        }

        [TestMethod]
        public void 모두0점이면점수도0점()
        {
            rollMany(20, 0);
            Assert.AreEqual(0, game.score());
        }

        [TestMethod]
        public void 모두1점이면점수는20점()
        {
            rollMany(20, 1);
            Assert.AreEqual(20, game.score());
        }

        private void rollSpare()
        {
            game.roll(5);
            game.roll(5);
        }

        private void rollStrike()
        {
            game.roll(10);
        }

        [TestMethod]
        public void 스페어처리하면뒤에한번은점수보너스()
        {
            rollSpare();
            game.roll(8);
            rollMany(17, 0);
            Assert.AreEqual(26, game.score());
        }

        [TestMethod]
        public void 스트라익치면_뒤에두번이_점수보너스()
        {
            rollStrike();
            game.roll(5);
            game.roll(3);
            rollMany(16, 0);
            Assert.AreEqual(26, game.score());
        }

        [TestMethod]
        public void 퍼펙트게임()
        {
            rollMany(12, 10);
            Assert.AreEqual(300, game.score());
        }
    }
}
