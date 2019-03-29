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

        private void rollMany(int count, int pins)
        {
            for (int i = 0; i < count; i++)
                game.roll(pins);
        }

        [TestMethod]
        public void 전부0점굴리면0점()
        {
            rollMany(20, 0);
            Assert.AreEqual(0, game.score());
        }

        [TestMethod]
        public void 전부1점굴리면20점()
        {
            rollMany(20, 1);
            Assert.AreEqual(20, game.score());
        }

        [TestMethod]
        public void 스페어처리하면_뒤에한번은_보너스점수()
        {
            game.roll(5);
            game.roll(5);
            game.roll(5);
            rollMany(17, 0);
            Assert.AreEqual(20, game.score());
        }

        [TestMethod]
        public void 스트라익치면_뒤에_두번이_보너스점수()
        {
            game.roll(10);
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
