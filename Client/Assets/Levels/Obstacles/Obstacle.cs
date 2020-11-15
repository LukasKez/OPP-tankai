namespace Client
{
    class Obstacle : GameObject
    {
        public Obstacle(float x, float y, float width, float height)
            : base(new Transform(x, y, width, height))
        {
        }

        public override void Decorate()
        {
            collider = ColliderType.Collider;
            isStatic = true;
            isShadowCaster = true;
        }
    }
}
