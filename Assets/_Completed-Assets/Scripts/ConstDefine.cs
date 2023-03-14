using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complete
{
    public static class ConstDefine
    {
        public const float NAV_SPEED_INIT = 8f; // 寻路机基础速度
        public const float NAV_ACCE_INIT = 10f;     // 寻路机基础加速度

        public const float NAV_SPEED_CHARGE = 16f;  // 寻路机创人时的速度
        public const float NAV_ACCE_CHARGE = 20f;   // 寻路机创人时的加速度

        public const float CHARGE_AWAIT_TIME = 1.2f;  // 一次冲锋后的等待时间
    }
}
