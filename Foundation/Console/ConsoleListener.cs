using Foundation.Command;
using Foundation.Console;
using Foundation.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Foundation.Listener
{
    /// <summary>
    /// 控制台监听
    /// </summary>
    public class ConsoleListener
    {
        private ConsoleDispatcher _dispatcher;

        public ConsoleDispatcher Dispatcher
        {
            get 
            {
                return _dispatcher;
            }
        }

        private static ConsoleListener s_instance;

        public static ConsoleListener Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new ConsoleListener();
                }

                return s_instance;
            }
        }
        private ConsoleListener()
        {
            _dispatcher = new ConsoleDispatcher();
        }

        public void Listen()
        {
            this.Update();
        }

        public void BeginListen()
        {
            Thread thread = new Thread(() =>
            {
                this.Update();
            });
            thread.Name = this.ToString();
            thread.Start();
        }

        protected void Update()
        {
            while (true)
            {
                Thread.Sleep(10);
                string line = System.Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                _dispatcher.Dispatch(line);
            }
        }
    }
}
