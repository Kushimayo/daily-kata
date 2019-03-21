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
        public void 모두다0핀이면0점()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, game.score());
        }

        [TestMethod]
        public void 모두다1핀이면20점()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, game.score());
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
        public void 스페어처리하면_뒤에한번굴린건_스페어보너스()
        {
            RollSpare();
            game.roll(5);
            RollMany(17, 0);
            Assert.AreEqual(20, game.score());
        }

        [TestMethod]
        public void 스트라익처리하면_뒤에두번굴린건_스트라익보너스()
        {
            RollStrike();
            game.roll(5);
            game.roll(3);
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
