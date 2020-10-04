

using Client;
/**
* @(#) PermanentDefense.cs
*/
namespace PowerUp
{
	public class PermanentDefense : PermanentPowerUp
	{
		public override void Use(Tank tank)
		{
			tank.defense += 10f;
		}
	}
	
}
