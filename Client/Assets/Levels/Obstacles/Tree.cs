using System.Drawing;

namespace Client
{
    public class Tree : ObstacleDecorator
    {
        public Tree(GameObject decoredObject)
            : base(decoredObject)
        {
        }
        public override void Decorate()
        {
            base.Decorate();
            adapter.SetFields(this);
            GenerateAABB();

            MakeTree();
        }
        private void MakeTree()
        {
            shape = Shape.Ellipse;
            brush = Brushes.DarkGreen;
        }
    }
}
