using System;

namespace Client
{
    public class TankDirector
    {
        private ITankBuilder tankBuilder;

        public TankDirector(ITankBuilder tankBuilder)
        {
            this.tankBuilder = tankBuilder;
        }

        public void Construct(float x, float y)
        {
            tankBuilder.AddHull(x, y).AddEngine().AddSuspension().AddTurret().AddGun();
        }
    }
}
