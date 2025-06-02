using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.ConsoleKata
{
    public class BowlingGame
    {
        ArrayList throws;
        ArrayList frames;

        public BowlingGame()
        {
            // Initialize the game state here
            frames = new ArrayList();
            throws = new ArrayList();
        }
        public void OpenFrame(int firstThrow, int secondThrow)
        {
            throws.Add(firstThrow);
            throws.Add(secondThrow);
            frames.Add(new OpenFrame(firstThrow, secondThrow));
        }
        public void Spare(int firstThrow, int secondThrow)
        {
            frames.Add(new SpareFrame(firstThrow, secondThrow));
        }
        public int Score()
        {
            int total = 0;
            foreach (IFrame frame in frames)
                total += frame.Score();
            return total;
        }
    }
    public interface IFrame
    {
        int Score();
    }
    public class OpenFrame : IFrame
    {
        int score;

        public OpenFrame(int firstThrow, int secondThrow)
        {
            score = firstThrow + secondThrow;
        }

        public int Score()
        {
            return score;
        }
    }
    public class SpareFrame : IFrame
    {
        int score;

        public SpareFrame(int firstBall, int secondBall)
        {
            score = 10 + NextBall();
        }

        private int NextBall()
        {
            return 3;
        }

        public int Score()
        {
            return score;
        }
    }
}
