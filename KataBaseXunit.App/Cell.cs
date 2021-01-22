using System;

namespace KataBaseXunit.App
{
    public abstract class Cell
    {
        protected Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public int X { get; }
        public int Y { get; }
        public virtual bool IsAlive { get; }
        
    }
}