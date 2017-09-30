using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Object
{
    /// <summary>
    /// 属性
    /// </summary>
    public class AIProperty : IProperty
    {
        /// <summary>
        /// 名称
        /// </summary>
        private string _name;
        /// <summary>
        /// 值
        /// </summary>
        private object _value;
        /// <summary>
        /// 值改变时处理
        /// </summary>
        private PropertyDelegate _valueChangedHandler;

        public string Name
        {
            get { return _name; }
        }

        public object Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (_valueChangedHandler != null)
                {
                    _valueChangedHandler(this);
                }
            }
        }

        public Type Type
        {
            get { return _value.GetType(); }
        }

        public PropertyDelegate OnValueChanged
        {
            get { return _valueChangedHandler; }
            set { _valueChangedHandler = value; }
        }

        public AIProperty(string name)
        {
            _name = name;
        }
    }

    public class AIProperty<T> : AIProperty
    {
        public T RealValue
        {
            get { return (T)Value; }
        }
    }
}
