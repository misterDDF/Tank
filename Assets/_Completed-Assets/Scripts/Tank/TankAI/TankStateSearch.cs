﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Complete
{
    public class TankStateSearch : TankState
    {
        private Transform target;

        public TankStateSearch(TankAI owner) : base(owner)
        {

        }

        public override void EnterState()
        {
            base.EnterState();
            Owner.MoveAI.SetNavActive(true);

            Debug.Log("AI坦克进入搜索状态");
        }

        public override void ProcessState()
        {
            base.ProcessState();
            target = GameManager.Instance.GetPlayerGO().transform;
            Owner.MoveAI.SetNavTarget(target);
            // 距离足够近且两车中间无障碍物时进入接敌状态
            if (Vector3.Distance(Owner.transform.position, target.transform.position) < 10)
            {
                // TODO 射线检测

                Owner.MoveAI.SetNavActive(false);
                TriggerTransition(TransKeyDefine.FindPlayer);
            }

            // 搜索时间过长则转回巡逻状态
            if(StateTime >= 10)
            {
                TriggerTransition(TransKeyDefine.LostPlayer);
            }
        }

        public override void ExitState()
        {
            base.ExitState();
            target = null;
            Owner.MoveAI.SetNavTarget(null);

            Debug.Log("AI坦克离开搜索状态");
        }
    }
}
