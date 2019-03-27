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

        private void RollMany(int count, int pins)
        {
            for (int i = 0; i < count; i++)
                game.roll(pins);
        }

        [TestMethod]
        public void 전부0점치면0점()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, game.score());
        }

        [TestMethod]
        public void 전부1점치면20점()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, game.score());
        }

        [TestMethod]
        public void 스페어처리시뒤에한번은스페어보너스()
        {
            RollSpare();
            game.roll(8);
            RollMany(17, 0);
            Assert.AreEqual(26, game.score());
        }

        private void RollSpare()
        {
            game.roll(3);
            game.roll(7);
        }
        private void RollStrike()
        {
            game.roll(10);
        }

        [TestMethod]
        public void 스트라익처리시뒤에두번이보너스()
        {
            RollStrike();
            game.roll(2);
            game.roll(6);
            RollMany(16, 0);
            Assert.AreEqual(26, game.score());
        }

        [TestMethod]
        public void 퍼펙트게임()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, game.score());
        }
    }
}
