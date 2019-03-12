using System;

namespace BowlingGame
{
    public class Game
    {
        private int gameScore;
        private int[] rolls;
        private int currentRoll;
        public Game()
        {
            gameScore = 0;
            rolls = new int[21];
            currentRoll = 0;
        }

        public void roll(int pins)
        {
            rolls[currentRoll++] = pins;
            gameScore += pins;
        }

        public int score()
        {
            return gameScore;
        }
    }
}