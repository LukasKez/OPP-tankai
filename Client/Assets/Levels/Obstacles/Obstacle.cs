namespace Client
{
    class Obstacle : GameObject
    {
        public Obstacle(float x, float y, float width, float height)
            : base(x, y, width, height)
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
