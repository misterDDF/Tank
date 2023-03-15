using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Complete
{
    public class TankAICharger : TankAI
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

            TankPool<TankAICharger>.PushTank(this);
        }

        private void BuildStates()
        {
            StateDict.Add(StateDefine.Patrol, new TankStatePatrol(this));
            StateDict.Add(StateDefine.Search, new TankStateSearch(this));
            StateDict.Add(StateDefine.Charge, new TankStateCharge(this));
            StateDict.Add(StateDefine.Await, new TankStateAwait(this));
        }

        private void BuildTransitions()
        {
            // 巡逻状态转移条件定义
            StateDict[StateDefine.Patrol].RegisterTransistion(TransKeyDefine.InspectPlayer, StateDict[StateDefine.Search]);

            // 搜索状态转移条件定义
            StateDict[StateDefine.Search].RegisterTransistion(TransKeyDefine.FindPlayer, StateDict[StateDefine.Charge]);
            StateDict[StateDefine.Search].RegisterTransistion(TransKeyDefine.LostPlayer, StateDict[StateDefine.Patrol]);

            // 冲锋状态转移条件定义
            StateDict[StateDefine.Charge].RegisterTransistion(TransKeyDefine.ChargeDone, StateDict[StateDefine.Await]);
            StateDict[StateDefine.Await].RegisterTransistion(TransKeyDefine.LostPlayer, StateDict[StateDefine.Search]);
        }
    }
}
