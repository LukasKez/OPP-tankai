using Client;
using System.Drawing;
/**
* @(#) TemporarySpeed.cs
*/
namespace PowerUp
{
	public class TemporarySpeed : TemporaryPowerUp
	{
        public TemporarySpeed(float x, float y, float w, float h) : base(x, y, w, h)
		{
			brush = Brushes.Gold;
		}

		public override void Use(Tank tank)
		{
			tank.speed += 20f;
		}

		public override void Unuse(Tank tank)
		{
			tank.speed -= 20f;
		}
	}
	
}
