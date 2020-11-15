using Client;
using System.Drawing;
/**
* @(#) PowerUp.cs
*/
namespace PowerUp
{
	public class PowerUpBase : GameObject
	{
        protected float speed = 100;

        public PowerUpBase(float x, float y, float w, float h) : base(new Transform(x, y, w, h))
        {
            isShadowCaster = true;
            shape = Shape.Ellipse;
            outlinePen = new Pen(Color.FromArgb(64, Color.Black), 2);
        }

        public override void Update(float deltaTime)
        {
            transform.rotation += speed * deltaTime;
        }

        public virtual void Use(Tank tank)
        {
            if (tank is null)
            {
                throw new System.ArgumentNullException(nameof(tank));
            }
        }
	}
	
}
