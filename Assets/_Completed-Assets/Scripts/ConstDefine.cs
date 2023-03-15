using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complete
{
    public static class ConstDefine
    {
        public const float CAMERA_ORTH_SIZE = 10f;

        public const float NAV_SPEED_INIT = 8f; // 寻路机基础速度
        public const float NAV_ACCE_INIT = 10f;     // 寻路机基础加速度

        public const float NAV_SPEED_CHARGE = 16f;  // 寻路机创人时的速度
        public const float NAV_ACCE_CHARGE = 20f;   // 寻路机创人时的加速度

        public const float SHOOT_AWAIT_TIME = 1.5f;   // AI坦克射击间隔
        public const float CHARGE_MAX_TIME = 2f;
        public const float CHARGE_AWAIT_TIME = 1.2f;  // 一次冲锋后的等待时间

        public const float AI_SEARCH_DISTANCE = 15f;    // AI判定已锁定玩家的最大距离
        public const float AI_SHOOT_DISTANCE = 20f; // AI判定玩家仍在射击范围内的最大距离

        public const float ROUND_RESPAWN_TIME = 30f;    // 下一波AI重生时间
        public const int MAX_WAVE_COUNT = 5;    // 波次数上限

        public const float DAMAGE_AI_BASE = 1f; // AI基础伤害
        public const float DAMAGE_AI_ADD = 1f;  // AI每波增强伤害
        public const float DAMAGE_PLAYER_HITWALL = 5f;  // 玩家撞墙伤害
        public const float DAMAGE_PLAYER_HITAI = 10f; // 玩家撞AI伤害
        public const float DAMAGE_PLAYER_SHOOT = 20f;   // 玩家射击默认伤害

        public const string TAG_PLAYER = "Player";
        public const string TAG_AI = "AI";
        public const string TAG_GROUND = "Ground";
        public const string TAG_BUFF = "Buff";

        public const float BUFF_DROP_RATE = 70f;
        public static float[] BUFF_FREEZE_RATE = { 0f, 50f };
        public static float[] BUFF_BKB_RATE = { 50f, 100f };

        public const float FREEZE_DIS = 30f;    // 冻结判定距离
        public const float FREEZE_TIME = 5f;    // 冻结时间

        public const float BKB_TIME = 5f;   // 无敌时间
    }
}
