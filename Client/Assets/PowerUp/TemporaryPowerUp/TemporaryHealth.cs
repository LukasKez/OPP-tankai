using Client;
using System.Drawing;
/**
* @(#) TemporaryHealth.cs
*/
namespace PowerUp
{
	public class TemporaryHealth : TemporaryPowerUp
	{
        public TemporaryHealth(float x, float y, float w, float h) : base(x, y, w, h)
		{
			brush = Brushes.Crimson;
		}

		public override void Use(Tank tank)
		{
			tank.health += 20f;
		}

		public override void Unuse(Tank tank)
		{
			tank.health -= 20f;
		}
	}
	
}
