

using Client;
/**
* @(#) TemporarySpeed.cs
*/
namespace PowerUp
{
	public class TemporarySpeed : TemporaryPowerUp
	{
		public override void Use(Tank tank)
		{
			tank.speed += 20f;
		}

		public override void Unuse(Tank tank)
		{
			tank.speed -= 20f;
		}
	}
	
}
