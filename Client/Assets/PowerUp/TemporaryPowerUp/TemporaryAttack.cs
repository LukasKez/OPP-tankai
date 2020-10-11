using Client;
using System.Drawing;
/**
* @(#) TemporaryAttack.cs
*/
namespace PowerUp
{
	public class TemporaryAttack : TemporaryPowerUp
	{
        public TemporaryAttack(float x, float y, float w, float h) : base(x, y, w, h)
        {
			brush = Brushes.Tomato;
		}

		public override void Use(Tank tank)
		{
			tank.attack += 2;
		}

		public override void Unuse(Tank tank)
		{
			tank.attack -= 2;
		}
	}
	
}
