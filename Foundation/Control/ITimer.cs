using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.Control
{
    /// <summary>
    /// 定时器
    /// </summary>
    public interface ITimer
    {
        void Update(float dt);
    }
}
