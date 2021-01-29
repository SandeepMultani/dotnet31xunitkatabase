using System;
using System.Collections.Generic;
using System.Linq;

namespace KataBaseXunit.App
{
    public class Grid
    {
        private Cell[,] _cells;

        public Grid(int width, int height, List<(int x, int y)> aliveCellCoords = null)
        {
            Width = width;
            Height = height;
            _cells = new Cell[Width, Height];

            ForEachCell((x,y) => _cells[x, y] = new DeadCell());

            if (aliveCellCoords != null)
            {
                foreach (var (x, y) in aliveCellCoords)
                {
                    _cells[x, y] = new AliveCell();
                }
            }
        }

        private int Width { get; }
        private int Height { get; }

        public bool IsCellAliveAt(int x, int y)
        {
            if (IsCellOutOfBound(x, y))
                return false;

            return _cells[x, y].IsAlive;
        }

        private int GetNumberOfAliveNeighbours(int x, int y)
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

        public void AdvanceGeneration()
        {
            var nextGenCells = new Cell[Width, Height];
            void AgeCell(int x, int y)
            {
                var aliveNeighbours = GetNumberOfAliveNeighbours(x, y);
                nextGenCells[x, y] = _cells[x, y].Age(aliveNeighbours);
            }

            ForEachCell(AgeCell);

            _cells = nextGenCells;
        }

        private void ForEachCell(Action<int, int> action)
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    action(x, y);
                }
            }
        }
    }
}