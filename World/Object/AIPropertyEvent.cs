using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Object
{
    public class AIPropertyEvent
    {
        private Dictionary<string, PropertyDelegate> _propertyEvent;

        public AIPropertyEvent()
        {
            _propertyEvent = new Dictionary<string, PropertyDelegate>();
        }

        public void Set(string name, PropertyDelegate handler)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            _propertyEvent[name] = handler;
        }

        public void Match(IProperty property)
        {
            if (property == null)
            {
                return;
            }

            PropertyDelegate hander;
            if (_propertyEvent.TryGetValue(property.Name, out hander))
            {
                hander(property);
            }
        }

        public PropertyDelegate this[string name]
        {
            set { Set(name, value); }
        }
    }
}
