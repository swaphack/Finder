using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Object
{
    /// <summary>
    /// 对象事件处理委托
    /// </summary>
    /// <param name="obj"></param>
    public delegate void ObjectDelegate(AIObject obj);
    /// <summary>
    /// 对象基础
    /// </summary>
    public class AIObject
    {
        /// <summary>
        /// 成员变量
        /// </summary>
        private AIMember _member;
        /// <summary>
        /// 变量改变时处理
        /// </summary>
        private AIPropertyEvent _propertyEvent;

        public AIMember Member
        {
            get { return _member; }
        }

        public AIPropertyEvent PropertyEvent
        {
            get { return _propertyEvent; }
        }

        public AIObject()
        {
            _propertyEvent = new AIPropertyEvent();

            _member = new AIMember();
            _member.OnValueChanged = OnMemberValueChange;
        }

        public void OnMemberValueChange(IProperty property)
        {
            _propertyEvent.Match(property);
        }
    }
}
