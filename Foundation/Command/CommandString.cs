using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.Command
{
    public class CommandString
    {
        private string _value;

        public string Value
        {
            get 
            {
                return _value;
            }

            set 
            {
                _value = value;
            }
        }

        public byte ToByte()
        {
            byte result;
            byte.TryParse(_value, out result);
            return result;
        }

        public char ToChar()
        {
            char result;
            char.TryParse(_value, out result);
            return result;
        }

        public DateTime ToDateTime()
        {
            DateTime result;
            DateTime.TryParse(_value, out result);
            return result;
        }

        public double ToDouble()
        {
            double result;
            double.TryParse(_value, out result);
            return result;
        }

        public short ToShort()
        {
            short result;
            short.TryParse(_value, out result);
            return result;
        }

        public int ToInt()
        {
            int result;
            int.TryParse(_value, out result);
            return result;
        }

        public long ToLong()
        {
            long result;
            long.TryParse(_value, out result);
            return result;
        }

        public float ToFloat()
        {
            float result;
            float.TryParse(_value, out result);
            return result;
        }

        public sbyte ToSByte()
        {
            sbyte result;
            sbyte.TryParse(_value, out result);
            return result;
        }

        public ushort ToUShort()
        {
            ushort result;
            ushort.TryParse(_value, out result);
            return result;
        }

        public uint ToUInt()
        {
            uint result;
            uint.TryParse(_value, out result);
            return result;
        }

        public ulong ToULong()
        {
            ulong result;
            ulong.TryParse(_value, out result);
            return result;
        }

        public string[] ToArray(char separator)
        {
            if (string.IsNullOrEmpty(_value))
            {
                return null;
            }
            return _value.Split(separator);
        }
    }
}
