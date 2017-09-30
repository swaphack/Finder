using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Object
{
    /// <summary>
    /// 成员
    /// </summary>
    public class AIMember
    {
        /// <summary>
        /// 属性集合
        /// </summary>
        private Dictionary<string, IProperty> _properties;
        /// <summary>
        /// 值改变时处理
        /// </summary>
        private PropertyDelegate _valueChangedHandler;

        public PropertyDelegate OnValueChanged
        {
            get { return _valueChangedHandler; }
            set { _valueChangedHandler = value; }
        }

        public AIMember()
        {
            _properties = new Dictionary<string, IProperty>();
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Add(string name, IProperty value)
        {
            if (string.IsNullOrEmpty(name) || value == null)
            {
                return;
            }
            value.OnValueChanged = OnValueChanged;
            _properties[name] = value;
        }

        /// <summary>
        /// 移除属性
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            _properties.Remove(name);
        }

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IProperty Get(string name)
        {
            IProperty value = null;
            _properties.TryGetValue(name, out value);
            return value;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetValue(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            IProperty property = Get(name);
            if (property == null)
            {
                return null;
            }

            return property.Value;
        }
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetValue(string name, object value)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            IProperty property = Get(name);
            if (property == null)
            {
                property = new AIProperty(name);
                property.Value = value;
                this.Add(name, property);
            }
            else
            {
                property.Value = value;   
            }
        }

        public object this[string name]
        {
            get { return GetValue(name); }
            set { SetValue(name, value); }
        }
    }
}
