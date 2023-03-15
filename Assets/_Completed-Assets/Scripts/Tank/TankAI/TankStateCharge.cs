using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Complete
{
    public class TankStateCharge : TankState
    {
        private Transform target;

        public TankStateCharge(TankAI owner) : base(owner)
        {

        }

        public override void EnterState()
        {
            base.EnterState();
            Owner.MoveAI.SetNavSpeed(ConstDefine.NAV_SPEED_CHARGE, ConstDefine.NAV_ACCE_CHARGE);
            Owner.Dummy.transform.position = GameManager.Instance.GetPlayerGO().transform.position;
            target = Owner.Dummy.transform;

            Debug.Log("AI坦克 " + Owner.InstanceId + " 号进入冲锋状态");
        }

        public override void ProcessState()
        {
            base.ProcessState();

            // 进状态瞄准当前瞬间的玩家位置创过去，然后进入等待状态
            Owner.MoveAI.SetNavTarget(target);
            if(Vector3.Distance(Owner.transform.position, target.position) < 1)
            {
                TriggerTransition(TransKeyDefine.ChargeDone);
            }
        }

        public override void ExitState()
        {
            base.ExitState();
            Owner.MoveAI.SetNavSpeed(ConstDefine.NAV_SPEED_INIT, ConstDefine.NAV_ACCE_INIT);
            target = null;

            Debug.Log("AI坦克 " + Owner.InstanceId + " 号离开冲锋状态");
        }
    }
}
