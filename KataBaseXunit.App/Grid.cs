using System.Collections.Generic;
using System.Linq;

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
                foreach (var (x, y) in aliveCellCoords)
                {
                    _cells[x, y] = new AliveCell();
                }
            }
        }

        public int Width { get; }
        public int Height { get; }

        public bool IsCellAliveAt(int x, int y)
        {
            if (IsCellOutOfBound(x, y))
                return false;

            return _cells[x, y].IsAlive;
        }

        public void AdvanceGeneration()
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfAliveNeighbours(int x, int y)
        {
            return new[]
            {
                (x - 1, y),
                (x + 1, y),
                (x, y - 1),
                (x, y + 1),
                (x + 1, y + 1),
                (x - 1, y - 1),
                (x + 1, y - 1),
                (x - 1, y + 1)
            }.Count(coord =>
                IsCellAliveAt(coord.Item1, coord.Item2));
        }

        private bool IsCellOutOfBound(int x, int y)
        {
            return x < 0 || x > Width - 1 || y > Height - 1 || y < 0;
        }
    }
}