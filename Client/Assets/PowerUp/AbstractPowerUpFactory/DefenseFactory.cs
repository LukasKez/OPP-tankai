/**
 * @(#) DefenseFactory.cs
 */

namespace PowerUp
{
	public class DefenseFactory : AbstractPowerUpFactory
	{
		public override PermanentPowerUp CreatePermanentPowerUp()
		{
			return new PermanentDefense();
		}

		public override TemporaryPowerUp CreateTemporaryPowerUp(  )
		{
			return new TemporaryDefense();
		}

	}
	
}
