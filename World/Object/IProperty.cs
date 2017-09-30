using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Object
{
    /// <summary>
    /// 属性事件处理委托
    /// </summary>
    /// <param name="t"></param>
    public delegate void PropertyDelegate(IProperty t);

    /// <summary>
    /// 属性接口
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 值
        /// </summary>
        object Value { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        Type Type { get; }
        /// <summary>
        /// 属性改变处理
        /// </summary>
        PropertyDelegate OnValueChanged { get; set; }
    }
}
