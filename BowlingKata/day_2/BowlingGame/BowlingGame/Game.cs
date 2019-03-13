using System;

namespace BowlingGame
{
    public class Game
    {
        private int gameScore;
        private int[][] rollPins;
        private int currentFrame;
        private int currentRoll;
        public Game()
        {
            gameScore = 0;
            currentFrame = 0;
            currentRoll = 0;
            rollPins = new int[10][];
            for (int i = 0; i < 10; i ++)
            {
                if (i == 9)
                    rollPins[i] = new int[3] { 0, 0, 0 };
                else
                    rollPins[i] = new int[2] { 0, 0 };
            }
        }

        public void roll(int pins)
        {
            rollPins[currentFrame][currentRoll++] = pins;
            if (currentRoll == 2 || pins == 10)
            {
                currentFrame++;
                currentRoll = 0;
            }
        }

        public int score()
        {
            for (int i = 0; i < 10; i++)
            {
                gameScore += rollPins[i][0];
                gameScore += rollPins[i][1];
                if (i > 0)
                {
                    if (PreFrameIsStrike(i - 1))
                    {
                        gameScore += rollPins[i][0];
                        gameScore += rollPins[i][1];
                    } else if (PreFrameIsSpare(i - 1))
                    {
                        gameScore += rollPins[i][0];
                    }
                }
            }
            return gameScore;
        }

        private bool PreFrameIsStrike(int frame)
        {
            return rollPins[frame][0] == 10 ? true : false;
        }

        private bool PreFrameIsSpare(int frame)
        {
            return rollPins[frame][0] + rollPins[frame][1] == 10 ? true : false;
        }
    }
}