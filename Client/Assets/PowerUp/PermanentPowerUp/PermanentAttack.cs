

using Client;
/**
* @(#) PermanentAttack.cs
*/
namespace PowerUp
{
	public class PermanentAttack : PermanentPowerUp
	{
		public override void Use(Tank tank)
		{
			tank.attack += 1f;
		}
	}
	
}
