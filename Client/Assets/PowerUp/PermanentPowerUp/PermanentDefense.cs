using Client;
using System.Drawing;
/**
* @(#) PermanentDefense.cs
*/
namespace PowerUp
{
	public class PermanentDefense : PermanentPowerUp
	{
        public PermanentDefense(float x, float y, float w, float h) : base(x, y, w, h)
        {
			brush = Brushes.DodgerBlue;
		}

		public override void Use(Tank tank)
		{
			tank.defense += 10f;
		}
	}
	
}
