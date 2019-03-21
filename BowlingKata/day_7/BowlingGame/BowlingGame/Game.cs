using System;

namespace BowlingGame
{
    public class Game
    {
        private const int MAX_GAME_FRAME = 10;
        private const int ONE_FRAME_CLEAR_SCORE = 10;
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
            for (int i = 0; i < MAX_GAME_FRAME; i++)
            {
                if (IsStrike(frameIndex))
                {
                    gameScore += StrikeFrameScore(frameIndex);
                    frameIndex++;
                } else if (IsSpare(frameIndex))
                {
                    gameScore += SpareFrameScore(frameIndex);
                    frameIndex += 2;
                } else
                {
                    gameScore += NormalFrameScore(frameIndex);
                    frameIndex += 2;
                }
            }

            return gameScore;
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == ONE_FRAME_CLEAR_SCORE;
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == ONE_FRAME_CLEAR_SCORE;
        }

        private int NormalFrameScore(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private int SpareFrameScore(int frameIndex)
        {
            return ONE_FRAME_CLEAR_SCORE + SpareBonus(frameIndex);
        }

        private int StrikeFrameScore(int frameIndex)
        {
            return ONE_FRAME_CLEAR_SCORE + StrikeBonus(frameIndex);
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }
    }
}