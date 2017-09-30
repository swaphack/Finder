using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.Command
{
    public class CommandCondition
    {
        /// <summary>
        /// 关键字
        /// </summary>
        private string _key;
        /// <summary>
        /// 参数
        /// </summary>
        private CommandParameters _parameters;

        public const string KeyOperator = "-";

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

        public CommandCondition()
        {
            _parameters = new CommandParameters();
        }

        /// <summary>
        /// 加载文本行
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public bool Load(string line)
        {
            if (string.IsNullOrEmpty(line)) 
            {
                return false;
            }
            if (!line.StartsWith(KeyOperator))
            {
                return false;
            }

            string strLine = line.Substring(KeyOperator.Length, line.Length - KeyOperator.Length);
            if (String.IsNullOrWhiteSpace(strLine)) 
            {
                return false;
            }

            string[] strAry = strLine.Split(' ');
            if(strAry == null || strAry.Length == 0) 
            {
                return false;
            }

            _key = strAry[0];
            List<string> value = strAry.ToList();
            value.RemoveAt(0);
            _parameters.Set(value);

            return true;
        }
    }
}
