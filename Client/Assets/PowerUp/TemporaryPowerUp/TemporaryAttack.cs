

using Client;
/**
* @(#) TemporaryAttack.cs
*/
namespace PowerUp
{
	public class TemporaryAttack : TemporaryPowerUp
	{
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
