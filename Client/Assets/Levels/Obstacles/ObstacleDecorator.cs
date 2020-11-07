
namespace Client
{
    abstract class ObstacleDecorator : GameObject
    { 
        protected GameObject obstacle;
        protected IAdapter adapter;
        public ObstacleDecorator(GameObject decoredObject)
        {           
            obstacle = decoredObject;
        }


        public override void Decorate()
        {
            obstacle.Decorate();
            AdapterContainer adapterContainer = new AdapterContainer();
            adapterContainer.SetGameObject(obstacle);
            adapter = new ObstacleAdapter(adapterContainer);
        }
    }
}
