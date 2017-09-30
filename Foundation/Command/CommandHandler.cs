using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.Command
{
    public abstract class CommandHandler : ICommandHandler
    {
        private CommandLine _commandLine;

        public virtual string Name
        {
            get { return ""; }
        }

        /// <summary>
        /// 参数
        /// </summary>
        public List<CommandString> Parameters
        {
            get 
            {
                if (_commandLine == null)
                {
                    return null;
                }

                return _commandLine.Parameters.Value;
            }
        }

        public Dictionary<string, CommandCondition> Conditions
        {
            get {
                if (_commandLine == null)
                {
                    return null;
                }

                return _commandLine.Conditions;
            }
        }

        public List<CommandString> GetConditionParameters(string key)
        {
            if (_commandLine == null)
            {
                return null;
            }

            if (!_commandLine.Conditions.ContainsKey(key))
            {
                return null;
            }

            return _commandLine.Conditions[key].Parameters.Value;
        }

        public virtual bool Hand(CommandLine commandLine)
        {
            _commandLine = commandLine;

            return true;
        }
    }
}
