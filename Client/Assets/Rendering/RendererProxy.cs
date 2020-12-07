using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace Client
{
    class RendererProxy : IRenderer
    {
        private Bitmap cacheLayer;
        private int cacheHash;

        public void RenderGameobjects(Graphics g, IEnumerable<GameObject> stuff, bool drawShadows)
        {
            var groups = stuff.GroupBy(x => new { x.isStatic });
            var group1 = groups.FirstOrDefault(x => x.Key.isStatic);
            var group2 = groups.FirstOrDefault(x => !x.Key.isStatic);

            int newHash = stuff.GetHashCode() + group1.Count();
            if (cacheHash != newHash)
            {
                Console.WriteLine("Caching graphics");

                var groups2 = group1.GroupBy(x => new { x.isShadowCaster });
                var group3 = groups2.FirstOrDefault(x => !x.Key.isShadowCaster);
                var group4 = groups2.FirstOrDefault(x => x.Key.isShadowCaster);

                if (cacheLayer == null)
                {
                    Vector2 size = GameState.Instance.mapSize;
                    cacheLayer = new Bitmap((int)size.X, (int)size.Y, g);
                }

                using (Graphics gLayer = Graphics.FromImage(cacheLayer))
                {
                    gLayer.Clear(Color.Transparent);
                    gLayer.SmoothingMode = g.SmoothingMode;
                    gLayer.PixelOffsetMode = g.PixelOffsetMode;

                    if (group3 != null)
                    {
                        Renderer.RendererInstance.RenderGameobjects(gLayer, group3);
                    }

                    if (group4 != null)
                    {
                        if (drawShadows)
                        {
                            Renderer.RendererInstance.RenderShadows(gLayer, group4);
                        }
                        Renderer.RendererInstance.RenderGameobjects(gLayer, group4);
                    }
                }

                cacheHash = newHash;
            }

            g.DrawImage(cacheLayer, Point.Empty);

            if (group2 != null)
            {
                Renderer.RendererInstance.RenderGameobjects(g, group2, drawShadows);
            }
        }

        public void RenderGameobject(Graphics g, GameObject obj)
        {
            Renderer.RendererInstance.RenderGameobject(g, obj);
        }

        public void RenderShape(Graphics g, Brush brush, Transform transform, Shape shape, Vector2 offset = default)
        {
            Renderer.RendererInstance.RenderShape(g, brush, transform, shape, offset);
        }

        public void RenderShape(Graphics g, Pen pen, Transform transform, Shape shape, Vector2 offset = default)
        {
            Renderer.RendererInstance.RenderShape(g, pen, transform, shape, offset);
        }

        public void Invalidate()
        {
            cacheHash = 0;
        }
    }
}
