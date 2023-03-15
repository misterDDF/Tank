using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Complete
{
    public class TankStatePatrol : TankState
    {
        private Transform target;

        public TankStatePatrol(TankAI owner) : base(owner)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
            target = Owner.GetRandomPatrolTransform();
            Owner.MoveAI.SetNavTarget(target);

            Debug.Log("AI坦克 " + Owner.InstanceId + " 号进入巡逻状态");
        }

        public override void ProcessState()
        {
            base.ProcessState();
            // 接近当前巡逻点后随机挑选另一个巡逻点
            if(Vector3.Distance(Owner.transform.position, target.position) < 1)
            {
                target = Owner.GetRandomPatrolTransform();
                Owner.MoveAI.SetNavTarget(target);

                Debug.Log("AI坦克 " + Owner.InstanceId + " 号到达预定巡逻点，向下一个随机巡逻点移动");
            }

            // 距离玩家够近时进入搜索状态
            if (!GameManager.Instance.GetPlayerGO().GetComponent<TankHealth>().Dead && 
                Vector3.Distance(Owner.transform.position, GameManager.Instance.GetPlayerGO().transform.position) < 30)
            {
                TriggerTransition(TransKeyDefine.InspectPlayer);

                Debug.Log("玩家在附近， AI坦克" + Owner.InstanceId + " 号进入搜索状态");
            }
        }

        public override void ExitState()
        {
            base.ExitState();
            Debug.Log("AI坦克 " + Owner.InstanceId + " 号离开巡逻状态");
        }
    }
}
