using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace Client
{
    class Renderer : IRenderer
    {
        public static Renderer RendererInstance { get; } = new Renderer();
        public static RendererProxy RendererProxyInstance { get; } = new RendererProxy();
        public static IRenderer Instance
        {
            get
            {
                if (Options.renderingProxy)
                {
                    return RendererProxyInstance;
                }
                return RendererInstance;
            }
        }

        readonly Brush shadowBrush = new SolidBrush(Color.FromArgb(64, Color.Black));
        readonly Vector2 sunDirection = new Vector2(2, 2);

        public void RenderGameobjects(Graphics g, IEnumerable<GameObject> stuff, bool drawShadows)
        {
            var groups = stuff.GroupBy(x => new { x.isShadowCaster });
            var group1 = groups.FirstOrDefault(x => !x.Key.isShadowCaster);
            var group2 = groups.FirstOrDefault(x => x.Key.isShadowCaster);

            if (group1 != null)
            {
                RenderGameobjects(g, group1);
            }

            if (group2 != null)
            {
                if (drawShadows)
                {
                    RenderShadows(g, group2);
                }

                RenderGameobjects(g, group2);
            }
        }

        public void RenderGameobjects(Graphics g, IEnumerable<GameObject> stuff)
        {
            foreach (var thing in stuff)
            {
                thing.Render(g);
            }
        }

        public void RenderShadows(Graphics g, IEnumerable<GameObject> stuff)
        {
            foreach (var thing in stuff)
            {
                if (thing.isShadowCaster)
                {
                    RenderShape(g, shadowBrush, thing.transform, thing.shape, sunDirection);
                }
            }
        }

        public void RenderGameobject(Graphics g, GameObject obj)
        {
            if (obj.brush != null)
            {
                RenderShape(g, obj.brush, obj.transform, obj.shape);
            }
            if (obj.outlinePen != null)
            {
                RenderShape(g, obj.outlinePen, obj.transform, obj.shape);
            }
        }

        public void RenderShape(Graphics g, Brush brush, TransformBase transform, Shape shape, Vector2 offset = default)
        {
            if (shape == Shape.None) return;

            Vector2 position = transform.WorldPosition;
            float rotation = transform.WorldRotation;

            if (rotation != 0)
            {
                Rotator.Rotate(g, position + offset, rotation);
            }

            switch (shape)
            {
                case Shape.Rectangle:
                    Rectangle.Draw(g, brush, position + offset, transform.size);
                    break;
                case Shape.Ellipse:
                    Ellipse.Draw(g, brush, position + offset, transform.size);
                    break;
                case Shape.Mesh:
                default:
                    throw new NotImplementedException("Shape not implemented");
            }

            if (rotation != 0)
            {
                g.ResetTransform();
            }
        }

        public void RenderShape(Graphics g, Pen pen, TransformBase transform, Shape shape, Vector2 offset = default)
        {
            if (shape == Shape.None) return;

            Vector2 position = transform.WorldPosition;
            float rotation = transform.WorldRotation;

            if (rotation != 0)
            {
                Rotator.Rotate(g, position + offset, rotation);
            }

            switch (shape)
            {
                case Shape.Rectangle:
                    Rectangle.Draw(g, pen, position + offset, transform.size.Substract(pen.Width));
                    break;
                case Shape.Ellipse:
                    Ellipse.Draw(g, pen, position + offset, transform.size.Substract(pen.Width));
                    break;
                case Shape.Mesh:
                default:
                    throw new NotImplementedException("Shape not implemented");
            }

            if (rotation != 0)
            {
                g.ResetTransform();
            }
        }
    }
}
