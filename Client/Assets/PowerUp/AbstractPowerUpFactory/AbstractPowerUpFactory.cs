/**
 * @(#) AbstractPowerUpFactory.cs
 */

namespace PowerUp
{
	public abstract class AbstractPowerUpFactory
	{
		public abstract PermanentPowerUp CreatePermanentPowerUp(  );
		
		public abstract TemporaryPowerUp CreateTemporaryPowerUp(  );
		
	}
	
}
