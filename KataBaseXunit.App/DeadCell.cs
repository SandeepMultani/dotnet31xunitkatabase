namespace KataBaseXunit.App
{
    public class DeadCell : Cell
    {
        public DeadCell(int x, int y) : base(x,y)
        {
        }

        public override bool IsAlive => false;
    }
}