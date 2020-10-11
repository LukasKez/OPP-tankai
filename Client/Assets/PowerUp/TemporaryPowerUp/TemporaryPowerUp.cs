using Client;
/**
* @(#) TemporaryPowerUp.cs
*/
namespace PowerUp
{
	public class TemporaryPowerUp : PowerUpBase
	{
		public float duration = 10f;

        public TemporaryPowerUp(float x, float y, float w, float h) : base(x, y, w, h)
        {

		}

		public virtual void Unuse(Tank tank)
        {

        }
	}
	
}
