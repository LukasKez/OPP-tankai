
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace Client
{
    class ObstacleAdapter : IAdapter
    {
        AdapterContainer adapterContainer;

        public ObstacleAdapter(AdapterContainer adapterContainer)
        {
            this.adapterContainer = adapterContainer;
        }
        public void SetFields(GameObject gameObject)
        {
            Dictionary<string, object> fields = adapterContainer.GetObjectFields(typeof(GameObject));

            gameObject.collider = fields.ContainsKey("collider") ? (ColliderType)fields["collider"] : throw new ArgumentNullException();
            gameObject.isShadowCaster = (bool)fields["isShadowCaster"];
            gameObject.damage = (float)fields["damage"];
            gameObject.shape = (Shape)fields["shape"];
            gameObject.brush = (Brush)fields["brush"];
            gameObject.outlineBrush =(Brush)fields["outlineBrush"];
            gameObject.transform = (Transform)fields["transform"];
        }
    }
}
