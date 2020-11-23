using System;
using System.Collections.Generic;
using System.Drawing;

namespace Client
{
    public class ObstacleAdapter : IAdapter
    {
        AdapterContainer adapterContainer;

        public ObstacleAdapter(AdapterContainer adapterContainer)
        {
            this.adapterContainer = adapterContainer;
        }
        public void SetFields(GameObject gameObject)
        {
            if(adapterContainer==null)
            {
                return;
            }

            Dictionary<string, object> fields = adapterContainer.GetObjectFields();
            Dictionary<string, object> properties = adapterContainer.GetObjectProperties();


            if (!fields.ContainsKey("collider"))
            {
                return;
            }

            gameObject.collider = (ColliderType)fields["collider"];
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
