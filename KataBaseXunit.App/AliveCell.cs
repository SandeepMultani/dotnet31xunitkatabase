namespace KataBaseXunit.App
{
    public class AliveCell : Cell
    {
        public AliveCell(int x, int y) : base(x,y)
        {
        }

        public override bool IsAlive => true;
    }
}