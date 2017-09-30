using Foundation.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using Foundation.Net;
using Foundation.Console;

namespace Console
{
    /// <summary>
    /// 控制台解析处理
    /// </summary>
    public class ConsoleParser : CommandParser
    {

        public ConsoleParser()
        {
            this.RegisterCommandParser(new ConsoleParser.Exithandler());
            this.RegisterCommandParser(new ConsoleParser.ScanPortHandler());
        }
        /// <summary>
        /// 退出处理
        /// 输入：exit
        /// </summary>
        public class Exithandler : ICommandHandler
        {
            public string Name
            {
                get { return "exit"; }
            }

            public bool Hand(CommandLine commandLine)
            {
                Process.GetCurrentProcess().Kill();

                return true;
            }
        }
        /// <summary>
        /// 端口扫描
        /// 输入: scan port -startip 127.0.0.1 -endip 127.0.0.1 -startport 0 -endport 65536
        /// </summary>
        public class ScanPortHandler : CommandHandler
        {
            public const string ParameterPort = "port";

            public readonly string[] ConditionKeys = {"startip", "endip", "startport", "endport" };
            public override string Name
            {
                get { return "scan"; }
            }

            private Dictionary<string, List<int>> _matches;

            public ScanPortHandler()
            {
                _matches = new Dictionary<string, List<int>>();
            }

            private void AddHostPort(string host, int port)
            {
                if (!_matches.ContainsKey(host))
                {
                    _matches[host] = new List<int>();
                }

                if (!_matches[host].Contains(port))
                {
                    _matches[host].Add(port);
                }
            }

            private void CheckSocket(string host, int port)
            {
                System.Console.WriteLine("Connect to {0}->{1}", host, port);
                Client client = new Client();
                client.StateChangedCallback = (Client.State status) =>
                {
                    if (status == Client.State.Connect)
                    {
                        System.Console.WriteLine("Connect to {0}->{1} successful", host, port);
                    }

                    client.Close();
                    System.Console.WriteLine("Disconnect to {0}->{1}", host, port);
                };
                client.Connect(host, port, 1000);
            }

            public override bool Hand(CommandLine commandLine)
            {
                if (!base.Hand(commandLine))
                {
                    return false;
                }

                if (Parameters.Count != 1)
                {
                    return false;
                }

                if (Parameters[0].Value != ParameterPort)
                {
                    return false;
                }

                foreach (string key in Conditions.Keys)
                {
                    if (!ConditionKeys.Contains(key)) 
                    {
                        return false;
                    }

                    if (GetConditionParameters(key).Count == 0)
                    {
                        return false;
                    }
                }

                string startIP = GetConditionParameters(ConditionKeys[0])[0].Value;
                string endIP = GetConditionParameters(ConditionKeys[1])[0].Value;

                int startPort = GetConditionParameters(ConditionKeys[2])[0].ToInt();
                int endPort = GetConditionParameters(ConditionKeys[3])[0].ToInt();

                _matches.Clear();

                for (int i = startPort; i <= endPort; i++)
                {
                    CheckSocket(startIP, i);
                }

                return true;
            }
        }
    }
}
