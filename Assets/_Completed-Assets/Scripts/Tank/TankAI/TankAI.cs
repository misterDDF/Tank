using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Complete
{
    public static class StateDefine
    {
        public const string Patrol = "Patrol";  // 巡逻状态
        public const string Search = "Search";  // 搜索状态
        public const string Engage = "Engage";  // 接敌人状态
        public const string Charge = "Charge";  // 冲锋状态
        public const string Await = "Await";    // 等待状态
    }

    public static class TransKeyDefine
    {
        public const string InspectPlayer = "InspectPlayer";    // 感知到玩家在附近
        public const string FindPlayer = "FindPlayer";  // 发现玩家
        public const string LostPlayer = "LostPlayer";  // 丢失玩家
        public const string ChargeDone = "ChargeDone";  // 冲锋结束（接一段等待时间）
    }

    public class TankAI : MonoBehaviour
    {
        [HideInInspector] public TankState CurState;
        [HideInInspector] public Dictionary<string, TankState> StateDict;

        public int InstanceId = 1;
        public TankMoveAI MoveAI;
        public Transform[] PatrolPoints;
        public GameObject Dummy;

        private void Start() {
            StateDict = new Dictionary<string, TankState>();
            BuildAI();

            MoveAI.SetNavSpeed(ConstDefine.NAV_SPEED_INIT, ConstDefine.NAV_ACCE_INIT);
        }

        private void Update()
        {
            this.CurState.ProcessState();
            this.CurState.StateTime += Time.deltaTime;
        }

        public virtual void BuildAI()
        {

        }

        public Transform GetRandomPatrolTransform()
        {
            return PatrolPoints[UnityEngine.Random.Range(0, PatrolPoints.Count())];
        }
    }
}
