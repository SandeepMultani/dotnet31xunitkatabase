using System.Linq;
namespace KataBaseXunit.App
{    
    public class AliveCell : Cell
    {
        private readonly int[] _neighboursRequiredForSurvival = {2, 3};
        public override bool IsAlive => true;
        public Cell Age(int countOfLiveNeighbours)
        {
            if (_neighboursRequiredForSurvival.Contains(countOfLiveNeighbours))
                return this;
            return new DeadCell();
        }
    }
}