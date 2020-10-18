using System;

namespace Client
{
    interface ITankBuilder
    {
        ITankBuilder AddHull(float x, float y);
        ITankBuilder AddEngine();
        ITankBuilder AddGun();
        ITankBuilder AddSuspension();
        ITankBuilder AddTurret();
        Tank GetResult();
    }
}
