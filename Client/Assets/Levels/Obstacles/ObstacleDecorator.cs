
namespace Client
{
    abstract class ObstacleDecorator : GameObject
    { 
        protected GameObject obstacle;
        public ObstacleDecorator(GameObject decoredObject)
        {           
            obstacle = decoredObject;
        }


        public override void Decorate()
        {
            obstacle.Decorate();
        }
    }
}
