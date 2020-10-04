

using Client;
/**
* @(#) TemporaryHealth.cs
*/
namespace PowerUp
{
	public class TemporaryHealth : TemporaryPowerUp
	{
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
