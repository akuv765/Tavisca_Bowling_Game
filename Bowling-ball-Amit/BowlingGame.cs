using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling_ball_Amit
{
    class BowlingGame
    {
        private readonly Frame[] frames = new Frame[10];
        private int totalScore;
        private int frameCounter = 0;

        public BowlingGame()
        {
            for (int i = 0; i < 10; i++)
            {
                Frame frame = new Frame();
                frames[i] = frame;
            }
        }
        public int GetTotalScore()
        {
            for (int frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                Frame frame = frames[frameIndex];
                int currentFrameScore = frame.GetFrameScore();
                if (frame.IsStrike() || frame.IsSpare())
                {
                    if (frameIndex == 9)
                    {
                        currentFrameScore += frames[frameIndex].LastRollScore;
                    }
                    else
                    {
                        currentFrameScore += GetBonusScore(frameIndex);
                    }
                }
                totalScore += currentFrameScore;
            }
            return totalScore;
        }

        private int GetBonusScore(int frameIndex)
        {
            int bonus = 0;
            if (frames[frameIndex].IsStrike())
            {
                bonus = frames[frameIndex + 1].GetFrameScore();
            }
            else if (frames[frameIndex].IsSpare())
            {
                bonus = frames[frameIndex + 1].GetFirstRollScore();
            }
            return bonus;
        }

        public void Roll(int pins)
        {
            Frame frame = frames[frameCounter];
            frame.SetFrameScores(pins);
            frames[frameCounter] = frame;
            if (frameCounter < 9 && (frame.IsStrike() || frame.FrameRollCount > 2))
                frameCounter++;
        }

        class Frame
        {
            public int LastRollScore { get; set; }
            public int FrameRollCount = 1;
            private int[] scores = new int[2];

            public void SetFrameScores(int pins)
            {
                if (FrameRollCount == 3)
                {
                    LastRollScore = pins;
                }
                else
                {
                    scores[FrameRollCount - 1] = pins;
                }
                //FrameScore += pins;
                FrameRollCount++;
            }

            internal int GetFrameScore()
            {
                return scores[0] + scores[1];
            }

            internal int GetFirstRollScore()
            {
                return scores[0];
            }

            internal bool IsStrike()
            {
                if (scores[0] == 10)
                    return true;
                else
                    return false;

            }

            internal bool IsSpare()
            {
                if (scores[0] + scores[1] == 10)
                    return true;
                else
                    return false;

            }
        }
    }
}
