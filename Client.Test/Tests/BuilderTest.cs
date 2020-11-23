using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Client.Test
{
    [TestClass]
    public class BuilderTest
    {        
        [TestMethod]
        public void TestBuilderWithAllTypes()
        {
            ITankBuilder builder = new HeavyTankBuilder();
            TankDirector director = new TankDirector(builder);
            Transform tr = new Transform();
            director.Construct(tr.position.X, tr.position.Y);
            Tank tank = builder.GetResult();
            Assert.IsTrue(tank.transform.size.X == 20 && tank.transform.size.Y == 22);

            builder = new LightTankBuilder();
            director = new TankDirector(builder);
            tr = new Transform();
            director.Construct(tr.position.X, tr.position.Y);
            tank = builder.GetResult();
            Assert.IsTrue(tank.transform.size.X == 18 && tank.transform.size.Y == 20);
        }
    }
}
