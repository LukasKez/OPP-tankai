﻿using System;

namespace Client
{
    interface ITankBuilder
    {
        ITankBuilder AddHull(float x, float y);
        ITankBuilder AddEngine();
        ITankBuilder AddSuspension();
        ITankBuilder AddTurret();
        ITankBuilder AddGun();
        Tank GetResult();
    }
}
