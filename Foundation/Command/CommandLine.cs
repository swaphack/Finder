using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.Command
{
    public class CommandLine
    {
        /// <summary>
        /// 关键字
        /// </summary>
        private string _key;
        /// <summary>
        /// 参数
        /// </summary>
        private CommandParameters _parameters;
        /// <summary>
        /// 条件
        /// </summary>
        private Dictionary<string, CommandCondition> _conditions;

        public string Key
        {
            get
            {
                return _key;
            }
        }
        public CommandParameters Parameters
        {
            get
            {
                return _parameters;
            }
        }

        public Dictionary<string, CommandCondition> Conditions
        {
            get
            {
                return _conditions;
            }
        }

        public CommandLine()
        {
            _parameters = new CommandParameters();
            _conditions = new Dictionary<string, CommandCondition>();
        }


        private void ParseStringBuilder(StringBuilder sb)
        {
            if (sb == null)
            {
                return;
            }

            if (sb.Length > 0)
            {
                string strLine = sb.ToString();
                if (strLine.EndsWith(" "))
                {
                    strLine = strLine.Substring(0, strLine.Length - 1);
                }

                CommandCondition condition = new CommandCondition();
                if (condition.Load(strLine))
                {
                    _conditions[condition.Key] = condition;
                }
            }
        }

        public bool Load(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return false;
            }

            string[] strAry = line.Split(' ');
            if (strAry == null || strAry.Length == 0)
            {
                return false;
            }

            List<string> parameters = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strAry.Length; i++)
            {
                if (_key == null)
                {
                    _key = strAry[i];
                }
                else if (strAry[i].StartsWith(CommandCondition.KeyOperator))
                {
                    ParseStringBuilder(sb);

                    sb.Clear();
                    sb.Append(strAry[i]);
                    sb.Append(" ");
                }
                else
                {
                    if (sb.Length == 0)
                    {
                        parameters.Add(strAry[i]);
                    }
                    else
                    {
                        sb.Append(strAry[i]);
                        sb.Append(" ");
                    }
                }
            }
            ParseStringBuilder(sb);

            _parameters.Set(parameters);

            return true;
        }
    }
}
