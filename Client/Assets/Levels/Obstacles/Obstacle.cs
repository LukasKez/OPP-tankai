namespace Client
{
    class Obstacle : GameObject
    {
        public Obstacle(float x, float y, float width, float height)
            : base(x, y, width, height)
        {
            collider = ColliderType.Collider;
            isShadowCaster = true;
        }

        public override void Decorate()
        {
        }
    }
}
