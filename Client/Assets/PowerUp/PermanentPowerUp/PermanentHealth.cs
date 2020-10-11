using Client;
using System.Drawing;
/**
* @(#) PermanentHealth.cs
*/
namespace PowerUp
{
	public class PermanentHealth : PermanentPowerUp
	{
        public PermanentHealth(float x, float y, float w, float h) : base(x, y, w, h)
        {
			brush = Brushes.Crimson;
		}

		public override void Use(Tank tank)
		{
			tank.health += 10f;
		}
	}
	
}
