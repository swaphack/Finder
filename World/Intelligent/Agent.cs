using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Object;

namespace World.Intelligent
{
    /// <summary>
    /// 对象状态
    /// </summary>
    public enum AgentStatus
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknow,
        /// <summary>
        /// 出生
        /// </summary>
        Alive,
        /// <summary>
        /// 死亡
        /// </summary>
        Dead,
    }

    /// <summary>
    /// 智能体
    /// </summary>
    public class Agent : AIObject
    {
        public Agent()
        {
        }

        public void InitMember()
        {
            Member["ID"] = 0;
            Member["Name"] = "";
            Member["CreateTime"] = DateTime.Now;
            Member["DestoryTime"] = DateTime.Now;
            Member["Status"] = AgentStatus.Unknow;
        }
    }
}
