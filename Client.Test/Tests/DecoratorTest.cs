using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Client.Test
{
    [TestClass]
    public class DecoratorTest
    {
        GameObject baseObject;

        [TestInitialize]
        public void TestInitialize()
        {
            baseObject = new Obstacle(0, 0, 0, 0);
        }
        [TestMethod]
        public void TestDecoratorToMakeObstacle()
        {
            GameObject obstacle = new DamageObstacle(baseObject);
            obstacle.Decorate();

            Assert.IsTrue(obstacle.damage > 0);

            obstacle = new Tree(obstacle);
            obstacle.Decorate();

            Assert.IsTrue(obstacle.shape == Shape.Ellipse);
            Assert.IsTrue(obstacle.brush == Brushes.DarkGreen);

            obstacle = new Wall(obstacle);
            obstacle.Decorate();

            Assert.IsTrue(obstacle.shape == Shape.Rectangle);
            Assert.IsTrue(obstacle.brush == Brushes.DarkGray);

            obstacle = new Water(obstacle);
            obstacle.Decorate();

            Assert.IsTrue(obstacle.shape == Shape.Rectangle);
            Assert.IsTrue(obstacle.brush == Brushes.DarkSlateBlue);

            obstacle = new Boulder(obstacle);
            obstacle.Decorate();

            Assert.IsTrue(obstacle.shape == Shape.Ellipse);
            Assert.IsTrue(obstacle.brush == Brushes.Gray);

            obstacle = new OutlineObstacle(obstacle);
            obstacle.Decorate();

            Color color = (obstacle.brush as SolidBrush).Color;
            Assert.IsTrue(obstacle.outlinePen.Color.Equals(color.Tint(Color.FromArgb(64, Color.Black))));

        }
    }
}
