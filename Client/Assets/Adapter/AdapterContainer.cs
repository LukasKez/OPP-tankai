using System;
using System.Collections.Generic;

namespace Client
{
    public class AdapterContainer
    {
        object gameObject;

        public AdapterContainer()
        {
        }
        public void SetGameObject(object gameObject)
        {
            this.gameObject = gameObject;
        }

        public Dictionary<string, object> GetObjectFields()
        {

            Dictionary<string, object> fields = new Dictionary<string, object>();
            if(this.gameObject==null)
            {
                return fields;
            }

            foreach (var field in gameObject.GetType().GetFields())
            {
                fields.Add(field.Name, field.GetValue(gameObject));
            }

            return fields;
        }

        public Dictionary<string, object> GetObjectProperties()
        {

            Dictionary<string, object> fields = new Dictionary<string, object>();
            if (this.gameObject == null)
            {
                return fields;
            }

            foreach (var field in gameObject.GetType().GetProperties())
            {
                fields.Add(field.Name, field.GetValue(gameObject));
            }

            return fields;
        }
    }
}
