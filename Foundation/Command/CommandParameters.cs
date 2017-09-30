using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.Command
{
    public class CommandParameters
    {
        /// <summary>
        /// 参数
        /// </summary>
        private List<CommandString> _value;

        public CommandParameters()
        {
            _value = new List<CommandString>();
        }

        public List<CommandString> Value
        {
            get
            {
                return _value;
            }
        }

        public void Set(List<string> lstString)
        {
            if (lstString == null || lstString.Count == 0)
            {
                return;
            }

            _value.Clear();
            for (int i = 0; i < lstString.Count; i++)
            {
                CommandString str = new CommandString();
                str.Value = lstString[i];
                _value.Add(str);
            }
        }
    }
}
