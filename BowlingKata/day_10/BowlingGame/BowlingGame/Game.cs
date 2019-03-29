using System;

namespace BowlingGame
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll;
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
                if(IsStrike(frameIndex))
                {
                    gameScore += SumStrikeScore(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    gameScore += SumSpareScore(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    gameScore += SumNormalScore(frameIndex);
                    frameIndex += 2;
                }
            }

            return gameScore;
        }

        private int SumNormalScore(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private int SumSpareScore(int frameIndex)
        {
            return 10 + SpareBonus(frameIndex);
        }

        private int SumStrikeScore(int frameIndex)
        {
            return 10 + StrikeBonus(frameIndex);
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }
    }
}