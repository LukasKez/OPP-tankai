/**
 * @(#) AbstractPowerUpFactory.cs
 */

namespace PowerUp
{
	public abstract class AbstractPowerUpFactory
	{
		public abstract PermanentPowerUp CreatePermanentPowerUp(float x, float y, float w, float h);
		
		public abstract TemporaryPowerUp CreateTemporaryPowerUp(float x, float y, float w, float h);
		
	}
	
}
