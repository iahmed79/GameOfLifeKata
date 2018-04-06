namespace GameOfLifeKata
{
    using System;
    using System.Text;

    public class GameOfLife
    {
        private Cell[,] grid;
        private int xCord;
        private int yCord;

        public Cell[,] Grid => this.grid;
        
        public void Seed(int x, int y)
        {
            this.xCord = x;
            this.yCord = y;

            var random = new Random(5);

            this.grid = new Cell[x,y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    var nextNumber = random.Next();

                    if (nextNumber % 2 == 0)
                    {
                        this.grid[i, j] = new Cell(CellState.Alive);
                    }
                    else
                    {
                        this.grid[i, j] = new Cell(CellState.Dead);
                    }
                }
            }
        }

        public string PrintState()
        {
            var output = new StringBuilder();
            for (int i = 0; i < this.grid.GetUpperBound(0); i++)
            {
                for (int j = 0; j < this.grid.GetUpperBound(1); j++)
                {
                    output.Append(this.grid[i, j] + ", ");
                }

                output.AppendLine();
            }

            return output.ToString();
        }

        public void Tick()
        {
            var gridBeforeTick = this.grid;
            var gridAfterTick = this.MoveOnTick();
            this.grid = gridAfterTick;
        }

        private Cell[,] MoveOnTick()
        {
            return new Cell[this.xCord, this.yCord];
        }

        public class Cell
        {
            private readonly CellState state;

            public Cell(CellState state)
            {
                this.state = state;
            }

            public CellState State { get; set; }

            public override string ToString()
            {
                return this.state == CellState.Dead ? "D" : "A";
            }
        }

        public enum CellState
        {
            Dead,
            Alive
        }
    }
}