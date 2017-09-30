using Foundation.Console;
using Foundation.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        class ConsoleCommandPath : IConsoleHandler
        {
            private ConsoleParser _parser;

            public ConsoleCommandPath()
            {
                _parser = new ConsoleParser();
               
            }
            public void Hand(string msg)
            {
                _parser.Parse(msg);
            }
        }

        static void Main(string[] args)
        {
            ConsoleListener.Instance.Dispatcher.RegisterConsoleHandler(new ConsoleCommandPath());
            ConsoleListener.Instance.Listen();
        }
    }
}
