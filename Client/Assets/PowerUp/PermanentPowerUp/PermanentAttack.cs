using Client;
using System.Drawing;
/**
* @(#) PermanentAttack.cs
*/
namespace PowerUp
{
	public class PermanentAttack : PermanentPowerUp
	{
        public PermanentAttack(float x, float y, float w, float h) : base(x, y, w, h)
        {
			brush = Brushes.Tomato;
		}

		public override void Use(Tank tank)
		{
			tank.attack += 1f;
		}
	}
	
}
