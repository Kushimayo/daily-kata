﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Test
{
    [TestClass]
    public class UnitTest1
    {
        private Game g;
        [TestInitialize]
        public void Initialize()
        {
            g = new Game();
        }

        private void rollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                g.roll(pins);
        }

        private void rollSpare()
        {
            g.roll(5);
            g.roll(5);
        }

        [TestMethod]
        public void testGutterGame()
        {
            rollMany(20, 0);
            Assert.AreEqual(0, g.score());
        }

        [TestMethod]
        public void testAllOnes()
        {
            rollMany(20, 1);
            Assert.AreEqual(20, g.score());
        }

        [TestMethod]
        public void testOneSpare()
        {
            rollSpare();
            g.roll(3);
            rollMany(17, 0);
            Assert.AreEqual(16, g.score());
        }

        [TestMethod]
        public void testOneStrike()
        {
            g.roll(10);
            g.roll(3);
            g.roll(4);
            rollMany(16, 0);
            Assert.AreEqual(24, g.score());
        }
    }
}
