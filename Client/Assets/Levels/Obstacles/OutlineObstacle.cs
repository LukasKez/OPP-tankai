using System.Drawing;

namespace Client
{
    public class OutlineObstacle: ObstacleDecorator
    {

        public OutlineObstacle(GameObject decoredObject)
            : base(decoredObject)
        {
        }
        public override void Decorate()
        {
            base.Decorate();
            adapter.SetFields(this);
            GenerateAABB();

            MakeOutline();
        }
        private void MakeOutline()
        {
            outlinePen = new Pen(Color.FromArgb(64, Color.Black), 2);
        }



    }
}
