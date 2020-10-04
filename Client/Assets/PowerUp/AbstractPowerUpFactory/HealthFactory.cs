/**
 * @(#) HealthFactory.cs
 */

namespace PowerUp
{
	public class HealthFactory : AbstractPowerUpFactory
	{
		public override PermanentPowerUp CreatePermanentPowerUp()
		{
			return new PermanentHealth();
		}

		public override TemporaryPowerUp CreateTemporaryPowerUp(  )
		{
			return new TemporaryHealth();
		}

	}
	
}
