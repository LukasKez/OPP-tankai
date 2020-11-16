using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerUp;
using System;
using System.Diagnostics;
using System.Numerics;

namespace Client.Test
{
    [TestClass]
    public class FixedSpawnTest
    {
        [TestMethod]
        public void TestSpawnedTypeFirst()
        {
            FixedSpawn fixedSpawn = new FixedSpawn();
            GameObjectStub gameObject = new GameObjectStub();

            fixedSpawn.Spawn(gameObject);
            Assert.AreEqual(0, fixedSpawn.getCurrentType());
        }

        [TestMethod]
        public void TestSpawnedTypeSecond()
        {
            FixedSpawn fixedSpawn = new FixedSpawn();
            GameObjectStub gameObject = new GameObjectStub();

            fixedSpawn.Spawn(gameObject);
            fixedSpawn.Spawn(gameObject);
            Assert.AreEqual(1, fixedSpawn.getCurrentType());
        }

        [TestMethod]
        public void TestSpawnedTypeThird()
        {
            FixedSpawn fixedSpawn = new FixedSpawn();
            GameObjectStub gameObject = new GameObjectStub();

            fixedSpawn.Spawn(gameObject);
            fixedSpawn.Spawn(gameObject);
            fixedSpawn.Spawn(gameObject);
            Assert.AreEqual(2, fixedSpawn.getCurrentType());
        }

        [TestMethod]
        public void TestSpawnedTypeFourth()
        {
            FixedSpawn fixedSpawn = new FixedSpawn();
            GameObjectStub gameObject = new GameObjectStub();

            fixedSpawn.Spawn(gameObject);
            fixedSpawn.Spawn(gameObject);
            fixedSpawn.Spawn(gameObject);
            fixedSpawn.Spawn(gameObject);
            Assert.AreEqual(-1, fixedSpawn.getCurrentType());
        }

        [TestMethod]
        public void TestSpawnedTypeFifth()
        {
            FixedSpawn fixedSpawn = new FixedSpawn();
            GameObjectStub gameObject = new GameObjectStub();

            fixedSpawn.Spawn(gameObject);
            fixedSpawn.Spawn(gameObject);
            fixedSpawn.Spawn(gameObject);
            fixedSpawn.Spawn(gameObject);
            fixedSpawn.Spawn(gameObject);
            Assert.AreEqual(0, fixedSpawn.getCurrentType());
        }

        [TestMethod]
        public void TestRandomnessOfPowerUp()
        {
            FixedSpawn fixedSpawn = new FixedSpawn();
            GameObjectStub gameObject = new GameObjectStub();
            int timesOfPermamentPowerup = 0;
            for (int i = 0; i < 1000; i++)
            {
                var powerUp = fixedSpawn.Spawn(gameObject);
                if (powerUp.GetType() == typeof(PermanentAttack) || powerUp.GetType() == typeof(PermanentDefense) || powerUp.GetType() == typeof(PermanentHealth) || powerUp.GetType() == typeof(PermanentSpeed))
                {
                    timesOfPermamentPowerup++;
                }
            }
            Assert.IsTrue(timesOfPermamentPowerup >= 450 && timesOfPermamentPowerup <= 550);
        }
    }
}

