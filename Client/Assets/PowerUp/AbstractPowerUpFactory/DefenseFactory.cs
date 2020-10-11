/**
 * @(#) DefenseFactory.cs
 */

namespace PowerUp
{
	public class DefenseFactory : AbstractPowerUpFactory
	{
		public override PermanentPowerUp CreatePermanentPowerUp(float x, float y, float w, float h)
		{
			return new PermanentDefense(x, y, w, h);
		}

		public override TemporaryPowerUp CreateTemporaryPowerUp(float x, float y, float w, float h)
		{
			return new TemporaryDefense(x, y, w, h);
		}

	}
	
}
