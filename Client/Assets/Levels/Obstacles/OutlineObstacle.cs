using System.Drawing;
using System.Windows.Forms;
namespace Client
{
    class OutlineObstacle: ObstacleDecorator
    {

        public OutlineObstacle(GameObject decoredObject)
            : base(decoredObject)
        {
        }
        public override void Decorate()
        {
            base.Decorate();
            adapter.SetFields(this);

            MakeOutline();
        }
        private void MakeOutline()
        {
            outlineBrush = Brushes.Black;
        }



    }
}
