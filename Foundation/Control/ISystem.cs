using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.Control
{
    public enum SystemState
    { 
        Init,
        Pause,
        Play,
        Stop,
    }
    /// <summary>
    /// 系统接口
    /// </summary>
    public interface ISystem
    {
        /// <summary>
        /// 开始
        /// </summary>
        void Start();
        /// <summary>
        /// 结束
        /// </summary>
        void Stop();
        /// <summary>
        /// 暂停
        /// </summary>
        void Pause();
        /// <summary>
        /// 恢复
        /// </summary>
        void Resume();
        /// <summary>
        /// 是否正在运行
        /// </summary>
        bool Playing { get; }
        /// <summary>
        /// 是否暂停
        /// </summary>
        bool Paused { get; }
    }
}
