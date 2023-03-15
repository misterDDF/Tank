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
        public const string PlayerDead = "PlayerDead";  // 玩家已阵亡 
    }

    public class TankAI : MonoBehaviour
    {
        [HideInInspector] public TankState CurState;
        [HideInInspector] public Dictionary<string, TankState> StateDict;

        public int InstanceId = 1;
        public TankMoveAI MoveAI;
        public TankShootingAI ShootingAI;
        public TankHealth HealthAI;
        public TankTrigger TriggerAI;
        public Transform[] PatrolPoints;
        public GameObject Dummy;
        public GameObject FreezeEffect;

        private float damage;
        public float Damage
        {
            get { return damage; }
            set
            {
                damage = value;
                ShootingAI.Damage = value;
            }
        }
        private float freezeTime = 0;

        private void Start() {
            PatrolPoints = GameManager.Instance.AISpawnPoints;
            Dummy.transform.SetParent(GameManager.Instance.transform);

            StateDict = new Dictionary<string, TankState>();
            BuildAI();

            MoveAI.SetNavSpeed(ConstDefine.NAV_SPEED_INIT, ConstDefine.NAV_ACCE_INIT);
            TriggerAI.onTriggerEnter = (Collider other) =>
            {
                if (other.gameObject.tag == ConstDefine.TAG_PLAYER)
                {
                    HealthAI.TakeDamage(ConstDefine.DAMAGE_PLAYER_HITAI);
                }
            };
        }

        private void Update()
        {
            if (freezeTime > 0)
            {
                MoveAI.SetNavActive(false);
                FreezeEffect.SetActive(true);
                freezeTime -= Time.deltaTime;
                return;
            }
            freezeTime = 0;
            FreezeEffect.SetActive(false);

            this.CurState.ProcessState();
            this.CurState.StateTime += Time.deltaTime;
        }

        public virtual void BuildAI()
        {

        }

        public virtual void Dispose()
        {

        }

        public Transform GetRandomPatrolTransform()
        {
            return PatrolPoints[UnityEngine.Random.Range(0, PatrolPoints.Count())];
        }

        public void Freeze(float freezeTime)
        {
            this.freezeTime = freezeTime;
        }
    }
}
