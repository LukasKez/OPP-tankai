/**
 * @(#) SpeedFactory.cs
 */

namespace PowerUp
{
	public class SpeedFactory : AbstractPowerUpFactory
	{
		public override PermanentPowerUp CreatePermanentPowerUp(float x, float y, float w, float h)
		{
			return new PermanentSpeed(x, y, w, h);
		}

		public override TemporaryPowerUp CreateTemporaryPowerUp(float x, float y, float w, float h)
		{
			return new TemporarySpeed(x, y, w, h);
		}

	}
	
}
