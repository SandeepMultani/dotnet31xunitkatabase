using System.Collections.Generic;

namespace KataBaseXunit.App
{
    public class Grid
    {
        private readonly Cell[,] _cells;
        public Grid(int width, int height, List<(int x, int y)> aliveCellCoords = null)
        {
            Width = width;
            Height = height;
            _cells = new Cell[Width, Height];

            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    _cells[i, j] = new DeadCell();
                }
            }

            if (aliveCellCoords != null)
            {
                foreach (var (x,y) in aliveCellCoords)
                {
                    _cells[x,y] = new AliveCell();
                }
            }
        }

        public int Width { get; }
        public int Height { get; }

        public bool IsCellAliveAt(int x, int y)
        {
            return _cells[x, y].IsAlive;
        }

        public void AdvanceGeneration()
        {
            throw new System.NotImplementedException();
        }
    }
}