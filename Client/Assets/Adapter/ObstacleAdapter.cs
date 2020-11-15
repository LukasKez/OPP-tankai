using System;
using System.Collections.Generic;
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
            Dictionary<string, object> properties = adapterContainer.GetObjectProperties(typeof(GameObject));

            gameObject.collider = fields.ContainsKey("collider") ? (ColliderType)fields["collider"] : throw new ArgumentNullException();
            gameObject.isStatic = (bool)fields["isStatic"];
            gameObject.isShadowCaster = (bool)fields["isShadowCaster"];
            gameObject.damage = (float)fields["damage"];
            gameObject.shape = (Shape)fields["shape"];
            gameObject.brush = (Brush)fields["brush"];
            gameObject.outlinePen = (Pen)fields["outlinePen"];
            gameObject.transform = (Transform)properties["transform"];
        }
    }
}
