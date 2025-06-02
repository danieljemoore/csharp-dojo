using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Kata.ConsoleKata; // Assuming the Bowling class is in this namespace

namespace Kata.UnitTests.ConsoleKata.Tests
{
    [TestFixture]
    public class BowlingTest 
    {
        BowlingGame game;

        public BowlingTest()
        {
            // Initialize any required resources or state here
        }

        [SetUp]
        public void Setup()
        {
            // This method is called before each test runs
            // You can use it to set up any common state or resources needed for the tests
            game = new BowlingGame();
        }

        [Test]
        public void Hookup()
        {
            Assert.That(true, Is.True, "This test is a placeholder to ensure the test framework is set up correctly.");
        }

        [Test]
        public void GutterBalls()
        {
            ManyOpenFrames(10, 0, 0);
            //AssertEquals(0, game.Score());
            Assert.That(game.Score(), Is.EqualTo(0), "The score should be 0 for 10 frames of gutter balls.");
        }

        [Test]
        public void Threes()
        {
            ManyOpenFrames(10, 3, 3);
            //AssertEquals(60, game.Score());
            Assert.That(game.Score(), Is.EqualTo(60), "The score should be 60 for 10 frames of three pins each.");
        }
        [Test]
        public void Spare()
        {
            game.Spare(4, 6);
            game.OpenFrame(3, 5);
            ManyOpenFrames(8, 0, 0);
            //AssertEquals(21, game.Score());
            Assert.That(game.Score(), Is.EqualTo(21), "The score should be 21 for a spare followed by an open frame with 3 and 5.");
        }

        [Test]
        public void Spare2()
        {
            game.Spare(4, 6);
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);
            Assert.That(game.Score(), Is.EqualTo(23), "The score should be 23 for a spare followed by an open frame with 5 and 3.");
        }

        private void ManyOpenFrames(int count, int firstThrow, int secondThrow)
        {
            for (int frameNumber = 0; frameNumber < count; frameNumber++)
                game.OpenFrame(firstThrow, secondThrow);
        }
    }
}
