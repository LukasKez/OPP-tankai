using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Numerics;

namespace Client.Test
{
    [TestClass]
    public class PhysicsTest
    {
        [TestMethod]
        public void HandleCollisionsWithEmptyList()
        {
            List<GameObject> list = new List<GameObject>();
            Physics.HandleCollisions(list);
        }

        [TestMethod]
        public void HandleCollisionsWithOneElement()
        {
            List<GameObject> list = new List<GameObject>
            {
                new GameObjectStub(Vector2.Zero)
                {
                    collider = ColliderType.Collider
                }
            };

            Physics.HandleCollisions(list);
            Assert.AreEqual(Vector2.Zero, list[0].transform.position);
        }

        [DataTestMethod]
        [DataRow(Shape.Rectangle, Shape.Rectangle, 0, -0.1f, 0, -1)] //North
        [DataRow(Shape.Rectangle, Shape.Rectangle, 0, 0.1f, 0, 1)]   //South
        [DataRow(Shape.Rectangle, Shape.Rectangle, 0.1f, 0, 1, 0)]   //East
        [DataRow(Shape.Rectangle, Shape.Rectangle, -0.1f, 0, -1, 0)] //West
        [DataRow(Shape.Ellipse, Shape.Ellipse, 0, -0.1f, 0, -1)] //North
        [DataRow(Shape.Ellipse, Shape.Ellipse, 0, 0.1f, 0, 1)]   //South
        [DataRow(Shape.Ellipse, Shape.Ellipse, 0.1f, 0, 1, 0)]   //East
        [DataRow(Shape.Ellipse, Shape.Ellipse, -0.1f, 0, -1, 0)] //West
        [DataRow(Shape.Ellipse, Shape.Rectangle, 0, -0.51f, 0, -1)] //North
        [DataRow(Shape.Ellipse, Shape.Rectangle, 0, 0.51f, 0, 1)]   //South
        [DataRow(Shape.Ellipse, Shape.Rectangle, 0.51f, 0, 1, 0)]   //East
        [DataRow(Shape.Ellipse, Shape.Rectangle, -0.51f, 0, -1, 0)] //West
        public void HandleCollisionsWithOverlappingObjects(Shape shape1, Shape shape2, float x1, float y1, float x2, float y2)
        {
            Vector2 start = new Vector2(x1, y1);
            Vector2 end = new Vector2(x2, y2);

            List<GameObject> list = new List<GameObject>
            {
                new GameObjectStub(Vector2.Zero)
                {
                    collider = ColliderType.Collider,
                    shape = shape1,
                    isStatic = true
                },
                new GameObjectStub(start)
                {
                    collider = ColliderType.Collider,
                    shape = shape2,
                    isStatic = false
                }
            };

            Physics.HandleCollisions(list);

            Assert.AreEqual(Vector2.Zero, list[0].transform.position);
            Assert.AreEqual(end, list[1].transform.position);
        }
    }
}
