using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Complete
{
    public class TankStateEngage : TankState
    {
        private int shootTimes;
        private Transform target;

        public TankStateEngage(TankAI owner): base(owner)
        {

        }

        public override void EnterState()
        {
            base.EnterState();
            shootTimes = 0;

            Debug.Log("AI坦克 " + Owner.InstanceId + " 号进入接敌状态");
        }

        public override void ProcessState()
        {
            base.ProcessState();
            target = GameManager.Instance.GetPlayerGO().transform;

            if (GameManager.Instance.IsPlayerDead())
            {
                TriggerTransition(TransKeyDefine.PlayerDead);
            }
            // 在视野范围内则指向目标，否则退回搜索状态
            else if (Vector3.Distance(Owner.transform.position, target.transform.position) > ConstDefine.AI_SHOOT_DISTANCE)
            {
                TriggerTransition(TransKeyDefine.LostPlayer);
            }
            else
            {
                Owner.transform.LookAt(target.transform.position);
                if(StateTime > shootTimes * ConstDefine.SHOOT_AWAIT_TIME)
                {
                    Owner.ShootingAI.Fire();
                    shootTimes++;
                }
            }
        }

        public override void ExitState()
        {
            base.ExitState();
            shootTimes = 0;

            Debug.Log("AI坦克 " + Owner.InstanceId + " 号离开接敌状态");
        }
    }
}
