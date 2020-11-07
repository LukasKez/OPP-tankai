using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace Client
{
    class AdapterContainer
    {
        object gameObject;

        public AdapterContainer()
        {
        }
        public void SetGameObject(object gameObject)
        {
            this.gameObject = gameObject;
        }
        public Dictionary<string, object> GetObjectFields(Type objectType)
        {

            Dictionary<string, object> fields = new Dictionary<string, object>();

            foreach (var field in gameObject.GetType().GetFields())
            {
                Debug.WriteLine(field.Name);
                fields.Add(field.Name, field.GetValue(gameObject));
            }

            return fields;
        }
    }
}
