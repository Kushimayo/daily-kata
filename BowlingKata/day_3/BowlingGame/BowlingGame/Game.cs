namespace BowlingGame
{
    public class Game
    {
        private const int TEN_FRAME = 9;
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
            for (int i = 0; i < 10; i++)
            {
                if (i == TEN_FRAME)
                    rollPins[i] = new int[3] { 0, 0, 0 };
                else
                    rollPins[i] = new int[2] { 0, 0 };
            }
        }

        public void roll(int pins)
        {
            rollPins[currentFrame][currentRoll++] = pins;
            if (currentFrame != TEN_FRAME && (currentRoll == 2 || pins == 10))
            {
                currentFrame++;
                currentRoll = 0;
            }
        }

        public int score()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i != TEN_FRAME)
                    gameScore += NormalFrameScore(i);
                else
                    gameScore += TenFrameScore();

                if (i > 0 && i < TEN_FRAME)
                {
                    if (PreFrameIsStrike(i - 1))
                    {
                        gameScore += NormalFrameScore(i);
                        if (i > 1 && PreFrameIsStrike(i - 2))
                        {
                            gameScore += NormalFrameScore(i);
                        }
                    }
                    else if (PreFrameIsSpare(i - 1))
                    {
                        gameScore += rollPins[i][0];
                    }
                } else if (i == TEN_FRAME)
                {
                    if (PreFrameIsStrike(i - 1))
                    {
                        if (rollPins[i][0] == 10)
                        {
                            gameScore += 10;
                            if (PreFrameIsStrike(i - 2))
                                gameScore += 10;
                        } else
                        {
                            gameScore += NormalFrameScore(TEN_FRAME);
                        }
                    }
                }
            }
            return gameScore;
        }

        private int NormalFrameScore(int frame)
        {
            return rollPins[frame][0] + rollPins[frame][1];
        }

        private int TenFrameScore()
        {
            return rollPins[TEN_FRAME][0] + rollPins[TEN_FRAME][1] + rollPins[TEN_FRAME][2];
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