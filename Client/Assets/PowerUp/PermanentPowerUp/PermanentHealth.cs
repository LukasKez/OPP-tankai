

using Client;
/**
* @(#) PermanentHealth.cs
*/
namespace PowerUp
{
	public class PermanentHealth : PermanentPowerUp
	{
		public override void Use(Tank tank)
		{
			tank.health += 10f;
		}
	}
	
}
