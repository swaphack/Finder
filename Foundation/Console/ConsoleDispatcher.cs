using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.Console
{
    /// <summary>
    /// 控制台消息派发
    /// </summary>
    public class ConsoleDispatcher
    {
        private List<IConsoleHandler> _handlers;

        public ConsoleDispatcher()
        {
            _handlers = new List<IConsoleHandler>();
        }


        public void RegisterConsoleHandler(IConsoleHandler handler)
        {
            if (handler == null)
            {
                return;
            }

            if (_handlers.Contains(handler))
            {
                return;
            }

            _handlers.Add(handler);
        }

        public void UnregisterConsoleHandler(IConsoleHandler handler)
        {
            if (handler == null)
            {
                return;
            }

            if (!_handlers.Contains(handler))
            {
                return;
            }

            _handlers.Remove(handler);
        }

        public void Dispatch(string msg)
        {
            for (int i = 0; i < _handlers.Count; i++)
            {
                _handlers[i].Hand(msg);
            }
        }
    }
}
