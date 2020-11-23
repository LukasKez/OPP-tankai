using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Client.Test
{ 
    [TestClass]
    public class AdapterTest
    {
        [TestMethod]
        public void TestContainerWithBadObject()
        {
            AdapterContainer adapterContainer = new AdapterContainer();
            adapterContainer.SetGameObject(null);

            Dictionary<string, object> expected = new Dictionary<string, object>();

            var actual1 = adapterContainer.GetObjectFields();
            Assert.AreEqual(expected.GetType(), actual1.GetType());

            var actual2 = adapterContainer.GetObjectProperties();
            Assert.AreEqual(expected.GetType(), actual2.GetType());
        }
        [TestMethod]
        public void TestWithBadAdapterContainer()
        {
            AdapterContainer adapterContainer = new AdapterContainer();
            adapterContainer.SetGameObject(null);

            IAdapter adapter = new ObstacleAdapter(adapterContainer);

            GameObjectStub stub = new GameObjectStub();
            adapter.SetFields(stub);
        }
        [TestMethod]
        public void TestWithNullContainer()
        {
            IAdapter adapter = new ObstacleAdapter(null);

            GameObjectStub stub = new GameObjectStub();
            adapter.SetFields(stub);
        }


    }
}
