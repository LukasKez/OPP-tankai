using System;
using System.Numerics;

namespace Client.Test
{
    class GameObjectStub : GameObject
    {
        public GameObjectStub()
        {
        }

        public GameObjectStub(Vector2 position) : base(new Transform(position.X, position.Y))
        {
        }
    }
}
