using System.Collections.Generic;

namespace KataBaseXunit.App
{
    public class AliveCell : Cell
    {
        public override bool IsAlive => true;

        public Cell Age(IEnumerable<AliveCell> liveNeighbours)
        {
            return new DeadCell();
        }
    }
}