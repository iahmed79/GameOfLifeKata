namespace GameOfLifeKata
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class GameOfLifeKataTests
    {
        private GameOfLife gameOfLife;

        [SetUp]
        public void SetUp()
        {
            this.gameOfLife = new GameOfLife();

            this.gameOfLife.Seed(8, 8);
        }

        [Test]
        public void SeedGrid()
        {
            Assert.That(this.gameOfLife.Grid, Is.Not.Null);
            Assert.That(this.gameOfLife.Grid.GetLength(0), Is.EqualTo(8));
            Assert.That(this.gameOfLife.Grid.GetLength(1), Is.EqualTo(8));
        }

        [Test]
        public void CellsAreSeeded()
        {
            Assert.That(this.gameOfLife.Grid[0, 1], Is.Not.Null);
        }

        [Test]
        public void PrintStateOfGrid()
        {
            var printOut = this.gameOfLife.PrintState();

            Assert.That(printOut, Is.Not.Null);

            Console.WriteLine(printOut);
        }

        [Test]
        public void EvolveAfterFirstTick()
        {
            var initialState = this.gameOfLife.Grid;
            this.gameOfLife.Tick();
            var nextState = this.gameOfLife.Grid;

            Assert.That(nextState, Is.Not.EqualTo(initialState));
        }
    }
}
