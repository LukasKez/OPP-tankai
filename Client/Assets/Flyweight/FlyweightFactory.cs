using System;
using System.Collections.Concurrent;
using System.Drawing;

namespace Client
{
    static class FlyweightFactory
    {
        private static ConcurrentDictionary<int, IFlyweight> flyweights = new ConcurrentDictionary<int, IFlyweight>();

        public static IFlyweight GetFlyweight(int key)
        {
            return flyweights.GetOrAdd(key, k => GenerateFlyweight(k));
        }

        private static IFlyweight GenerateFlyweight(int key)
        {
            GameObjectFlyweight flyweight = new GameObjectFlyweight
            {
                outlinePen = new Pen(Color.FromArgb(key).Tint(Color.FromArgb(64, Color.Black)), 2)
            };

            return flyweight;
        }
    }
}
