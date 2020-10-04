/**
 * @(#) AttackFactory.cs
 */

namespace PowerUp
{
	public class AttackFactory : AbstractPowerUpFactory
	{
		public override PermanentPowerUp CreatePermanentPowerUp(  )
		{
			return new PermanentAttack();
		}

		public override TemporaryPowerUp CreateTemporaryPowerUp(  )
		{
			return new TemporaryAttack();
		}
		
	}
	
}
