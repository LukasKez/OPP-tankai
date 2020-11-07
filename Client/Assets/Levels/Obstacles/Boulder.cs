using System.Drawing;

namespace Client
{
    class Boulder : ObstacleDecorator
    {

        public Boulder(GameObject decoredObject)
            : base(decoredObject)
        {
        }
        public override void Decorate()
        {
            base.Decorate();
            adapter.SetFields(this);
            GenerateAABB();

            MakeBoulder();
        }
        private void MakeBoulder()
        {
            shape = Shape.Ellipse;
            brush = Brushes.Gray;
        }



    }
}
