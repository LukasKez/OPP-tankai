

using Client;
/**
* @(#) PermanentSpeed.cs
*/
namespace PowerUp
{
	public class PermanentSpeed : PermanentPowerUp
	{
		public override void Use(Tank tank)
        {
			tank.speed += 10f;
        }
	}
	
}
