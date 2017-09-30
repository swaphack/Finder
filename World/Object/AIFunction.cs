using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Object
{
    public delegate void FuncDelegate(object obj);
    /// <summary>
    /// 对象事件管理
    /// </summary>
    public class AIFunction
    {
        private event FuncDelegate _funcEvent;

        public AIFunction()
        {
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="e"></param>
        public void AddFunc(FuncDelegate e)
        {
            if (e != null)
            {
                _funcEvent += e;
            }
        }

        /// <summary>
        /// 移除方法
        /// </summary>
        /// <param name="e"></param>
        public void RemoveFunc(FuncDelegate e)
        {
            if (e != null)
            {
                _funcEvent -= e;
            }
        }

        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="obj"></param>
        public void DoFunc(object obj)
        {
            if (obj != null && _funcEvent != null)
            {
                _funcEvent(obj);
            }
        }
    }
}
