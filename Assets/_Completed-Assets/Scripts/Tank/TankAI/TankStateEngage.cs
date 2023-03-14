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
        private Transform target;

        public TankStateEngage(TankAI owner): base(owner)
        {

        }

        public override void EnterState()
        {
            base.EnterState();

            Debug.Log("AI坦克进入接敌状态");
        }

        public override void ProcessState()
        {
            base.ProcessState();
            target = GameManager.Instance.GetPlayerGO().transform;

            // 在视野范围内则指向目标，否则退回搜索状态
            if (Vector3.Distance(Owner.transform.position, target.transform.position) > 15)
            {
                TriggerTransition(TransKeyDefine.LostPlayer);
            }
            else
            {
                Owner.transform.LookAt(target.transform.position);
            }
        }

        public override void ExitState()
        {
            base.ExitState();

            Debug.Log("AI坦克离开接敌状态");
        }
    }
}
