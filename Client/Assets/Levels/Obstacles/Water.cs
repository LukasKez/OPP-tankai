using System.Drawing;

namespace Client
{
    class Water : ObstacleDecorator
    {
        public Water(GameObject decoredObject)
            :base(decoredObject)
        {
        }
        public override void Decorate()
        {
            base.Decorate();
            adapter.SetFields(this);

            MakeWater();
        }
        private void MakeWater()
        {
            shape = Shape.Rectangle;
            brush = Brushes.DarkSlateBlue;
        }
    }
}
