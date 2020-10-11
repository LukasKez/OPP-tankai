/**
 * @(#) HealthFactory.cs
 */

namespace PowerUp
{
	public class HealthFactory : AbstractPowerUpFactory
	{
		public override PermanentPowerUp CreatePermanentPowerUp(float x, float y, float w, float h)
		{
			return new PermanentHealth(x, y, w, h);
		}

		public override TemporaryPowerUp CreateTemporaryPowerUp(float x, float y, float w, float h)
		{
			return new TemporaryHealth(x, y, w, h);
		}

	}
	
}
