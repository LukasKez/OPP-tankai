/**
 * @(#) PermanentPowerUp.cs
 */

namespace PowerUp
{
	public class PermanentPowerUp : PowerUpBase
	{
        public PermanentPowerUp(float x, float y, float w, float h) : base(x, y, w, h)
        {
            speed *= -1;
        }
	}
}
