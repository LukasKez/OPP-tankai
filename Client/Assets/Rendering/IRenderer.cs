using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Client
{
    interface IRenderer
    {
        void RenderGameobjects(Graphics g, IEnumerable<GameObject> stuff, bool drawShadows);
        void RenderGameobject(Graphics g, GameObject obj);
        void RenderShape(Graphics g, Brush brush, Transform transform, Shape shape, Vector2 offset = default);
        void RenderShape(Graphics g, Pen pen, Transform transform, Shape shape, Vector2 offset = default);
    }
}
