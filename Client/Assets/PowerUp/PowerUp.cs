

using Client;
/**
* @(#) PowerUp.cs
*/
namespace PowerUp
{
	public class PowerUp
	{
        public virtual void Use(Tank tank)
        {
            if (tank is null)
            {
                throw new System.ArgumentNullException(nameof(tank));
            }
        }
	}
	
}
