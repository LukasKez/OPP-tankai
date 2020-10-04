

using Client;
/**
* @(#) TemporaryDefense.cs
*/
namespace PowerUp
{
	public class TemporaryDefense : TemporaryPowerUp
	{
		public override void Use(Tank tank)
		{
			tank.defense += 20f;
		}

		public override void Unuse(Tank tank)
		{
			tank.defense -= 20f;
		}
	}
	
}
