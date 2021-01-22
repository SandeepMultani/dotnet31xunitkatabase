namespace KataBaseXunit.App
{
    public class DeadCell : Cell
    {
        private const int NoOfAliveNeighboursForBirth = 3;
        public override bool IsAlive => false;

        public Cell Age(int noOfAliveNeighbours)
        {
            if(noOfAliveNeighbours == NoOfAliveNeighboursForBirth)
                return new AliveCell();
            
            return this;
        }
    }
}