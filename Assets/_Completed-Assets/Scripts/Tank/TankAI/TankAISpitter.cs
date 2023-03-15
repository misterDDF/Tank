using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Complete
{
    public class TankAISpitter : TankAI
    {
        public override void BuildAI()
        {
            base.BuildAI();

            BuildStates();
            BuildTransitions();

            this.CurState = StateDict[StateDefine.Patrol];
            this.CurState.EnterState();
        }

        public override void Dispose()
        {
            base.Dispose();

            TankPool<TankAISpitter>.PushTank(this);
        }

        private void BuildStates()
        {
            StateDict.Add(StateDefine.Patrol, new TankStatePatrol(this));
            StateDict.Add(StateDefine.Search, new TankStateSearch(this));
            StateDict.Add(StateDefine.Engage, new TankStateEngage(this));
        }

        private void BuildTransitions()
        {
            // 巡逻状态转移条件定义
            StateDict[StateDefine.Patrol].RegisterTransistion(TransKeyDefine.InspectPlayer, StateDict[StateDefine.Search]);

            // 搜索状态转移条件定义
            StateDict[StateDefine.Search].RegisterTransistion(TransKeyDefine.FindPlayer, StateDict[StateDefine.Engage]);
            StateDict[StateDefine.Search].RegisterTransistion(TransKeyDefine.LostPlayer, StateDict[StateDefine.Patrol]);

            // 接敌状态转移条件定义
            StateDict[StateDefine.Engage].RegisterTransistion(TransKeyDefine.LostPlayer, StateDict[StateDefine.Search]);
            StateDict[StateDefine.Engage].RegisterTransistion(TransKeyDefine.PlayerDead, StateDict[StateDefine.Patrol]);
        }
    }
}
