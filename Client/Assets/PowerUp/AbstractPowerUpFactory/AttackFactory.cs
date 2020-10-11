/**
 * @(#) AttackFactory.cs
 */

namespace PowerUp
{
	public class AttackFactory : AbstractPowerUpFactory
	{
		public override PermanentPowerUp CreatePermanentPowerUp(float x, float y, float w, float h)
		{
			return new PermanentAttack(x, y, w, h);
		}

		public override TemporaryPowerUp CreateTemporaryPowerUp(float x, float y, float w, float h)
		{
			return new TemporaryAttack(x, y, w, h);
		}
		
	}
	
}
