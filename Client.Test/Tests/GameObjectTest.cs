using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace Client.Test
{
    [TestClass]
    public class GameObjectTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            GameLevelStub gameLevel = new GameLevelStub();
        }

        [TestMethod]
        public void TestInstantiateAndDestroy()
        {
            GameLevel gameLevel = GameState.Instance.gameLevel;

            GameObjectStub gameObject = new GameObjectStub();
            GameObject.Instantiate(gameObject);

            gameLevel.Update(0);
            Assert.AreEqual(1, GameState.Instance.gameLevel.Find<GameObjectStub>().Count);

            gameObject.Destroy();
            gameLevel.Update(0);
            Assert.AreEqual(0, GameState.Instance.gameLevel.Find<GameObjectStub>().Count);
        }

        [TestMethod]
        public void TestGameObjectInstantiateAndDestroyWithParent()
        {
            GameLevel gameLevel = GameState.Instance.gameLevel;

            GameObjectStub parent = new GameObjectStub();
            GameObjectStub child = new GameObjectStub();

            GameObject.Instantiate(parent);
            GameObject.Instantiate(child, parent);

            gameLevel.Update(0);
            Assert.AreEqual(2, GameState.Instance.gameLevel.Find<GameObjectStub>().Count);

            parent.Destroy();
            gameLevel.Update(0);
            Assert.AreEqual(0, GameState.Instance.gameLevel.Find<GameObjectStub>().Count);
        }

        [TestMethod]
        public void TestGameObjectTransform()
        {
            GameObjectStub parent = new GameObjectStub();
            GameObjectStub child = new GameObjectStub();
            GameObject.Instantiate(child, parent);

            parent.transform.position = Vector2.One;
            Assert.AreEqual(Vector2.One, child.transform.WorldPosition);

            parent.transform.rotation = 180;
            child.transform.position = Vector2.One;
            Assert.AreEqual(Vector2.Zero, child.transform.WorldPosition);

            child.transform.WorldPosition = -Vector2.One;
            Assert.AreEqual(Vector2.Zero, child.transform.position);

            child.transform.WorldRotation = 0;
            Assert.AreEqual(-180, child.transform.rotation);
        }
    }
}
