using Foundation.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.Console
{
    /// <summary>
    /// 命令解析
    /// </summary>
    public class CommandParser
    {
        private Dictionary<string, ICommandHandler> _commandHandlers;
        public CommandParser()
        {
            _commandHandlers = new Dictionary<string, ICommandHandler>();
        }

        /// <summary>
        /// 添加处理器
        /// </summary>
        /// <param name="handler"></param>
        public void RegisterCommandParser(ICommandHandler handler)
        {
            if (handler == null)
            {
                return;
            }

            _commandHandlers[handler.Name] = handler;
        }

        /// <summary>
        /// 移除处理器
        /// </summary>
        /// <param name="type"></param>
        public void UnregisterCommandParser(string type)
        {
            if (_commandHandlers.ContainsKey(type))
            {
                _commandHandlers.Remove(type);
            }
        }

        public void Clear()
        {
            _commandHandlers.Clear();
        }

        /// <summary>
        /// 处理输入行
        /// </summary>
        /// <param name="line"></param>
        public void Parse(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return;
            }

            CommandLine commandLine = new CommandLine();
            if (!commandLine.Load(line))
            {
                return;
            }

            ICommandHandler handler;
            if (_commandHandlers.TryGetValue(commandLine.Key, out handler))
            {
                handler.Hand(commandLine);
            }
        }

    }
}
