using System;

namespace BowlingGame
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        public Game()
        {
        }

        public void roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int score()
        {
            int gameScore = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (rolls[frameIndex] == 10)
                {
                    gameScore += 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))  // spare
                {
                    gameScore += 10 + rolls[frameIndex + 2];
                    frameIndex += 2;
                }
                else
                {
                    gameScore += rolls[frameIndex] + rolls[frameIndex + 1];
                    frameIndex += 2;
                }
            }

            return gameScore;
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }
    }
}