using Client;
using System.Drawing;
/**
* @(#) TemporaryDefense.cs
*/
namespace PowerUp
{
	public class TemporaryDefense : TemporaryPowerUp
	{
        public TemporaryDefense(float x, float y, float w, float h) : base(x, y, w, h)
		{
			brush = Brushes.DodgerBlue;
		}

		public override void Use(Tank tank)
		{
			tank.defense += 5f;
		}

		public override void Unuse(Tank tank)
		{
			tank.defense -= 5f;
		}
	}
	
}
