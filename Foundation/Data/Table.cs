using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.Data
{
    public class Table
    {
        private List<Record> _records;

        public Table()
        {
            _records = new List<Record>();
        }

        public void Add(Record record)
        {
            if (record == null)
            {
                return;
            }
            _records.Add(record);
        }

        public void Remove(Record record)
        {
            if (record == null)
            {
                return;
            }

            _records.Add(record);
        }

        public void Clear()
        {
            _records.Clear();
        }
    }
}
