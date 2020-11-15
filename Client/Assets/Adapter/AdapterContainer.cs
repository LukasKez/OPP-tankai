using System;
using System.Collections.Generic;

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
                fields.Add(field.Name, field.GetValue(gameObject));
            }

            return fields;
        }

        public Dictionary<string, object> GetObjectProperties(Type objectType)
        {

            Dictionary<string, object> fields = new Dictionary<string, object>();

            foreach (var field in gameObject.GetType().GetProperties())
            {
                fields.Add(field.Name, field.GetValue(gameObject));
            }

            return fields;
        }
    }
}
