/**
 * @(#) SpeedFactory.cs
 */

namespace PowerUp
{
	public class SpeedFactory : AbstractPowerUpFactory
	{
		public override PermanentPowerUp CreatePermanentPowerUp()
		{
			return new PermanentSpeed();
		}

		public override TemporaryPowerUp CreateTemporaryPowerUp(  )
		{
			return new TemporarySpeed();
		}

	}
	
}
