using System.Drawing;

namespace Client
{
    public class Wall : ObstacleDecorator
    {
        public Wall(GameObject decoredObject)
            : base(decoredObject)
        {
        }
        public override void Decorate()
        {
            base.Decorate();
            adapter.SetFields(this);
            GenerateAABB();

            MakeWall();
        }
        private void MakeWall()
        {
            shape = Shape.Rectangle;
            brush = Brushes.DarkGray;
        }


    }
}
