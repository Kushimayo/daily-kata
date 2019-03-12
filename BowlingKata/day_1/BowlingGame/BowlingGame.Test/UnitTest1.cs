using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Test
{
    [TestClass]
    public class UnitTest1
    {
        private Game game;
        [TestMethod]
        public void 인스턴스를생성할수있다()
        {
            game = new Game();
        }

        private void rollMany(int count, int pins)
        {
            for (int i = 0; i < count; i++)
            {
                game.roll(pins);
            }
        }

        [TestMethod]
        public void 한핀도못맞추면0점()
        {
            game = new Game();
            rollMany(20, 0);
            Assert.AreEqual(0, game.score());
        }

        [TestMethod]
        public void 계속1핀만맞추면20점()
        {
            game = new Game();
            rollMany(20, 1);
            Assert.AreEqual(20, game.score());
        }

        [TestMethod]
        public void 스페어처리하면_다음프레임으로보너스()
        {
            game = new Game();
            game.roll(9);
            game.roll(1);
            game.roll(5);
            rollMany(17, 0);
            Assert.AreEqual(20, game.score());
        }
    }
}
