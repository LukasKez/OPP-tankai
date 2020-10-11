using Client;
using System.Drawing;
/**
* @(#) PermanentSpeed.cs
*/
namespace PowerUp
{
	public class PermanentSpeed : PermanentPowerUp
	{
        public PermanentSpeed(float x, float y, float w, float h) : base(x, y, w, h)
        {
			brush = Brushes.Gold;
        }

		public override void Use(Tank tank)
        {
			tank.speed += 10f;
        }
	}
	
}
