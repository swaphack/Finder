using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.Command
{
    /// <summary>
    /// 命令处理接口
    /// </summary>
    public interface ICommandHandler
    {
        /// <summary>
        /// 类型
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 处理
        /// </summary>
        bool Hand(CommandLine commandLine);

    }
}
