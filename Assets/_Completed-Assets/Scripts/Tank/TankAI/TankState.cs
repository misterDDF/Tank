using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complete
{
    public class TankState
    {
        public TankAI Owner;
        public float StateTime;
        public Dictionary<string, TankTransition> TransDict;

        public TankState(TankAI owner)
        {
            TransDict = new Dictionary<string, TankTransition>();
            Owner = owner;
        }

        public virtual void EnterState()
        {
            StateTime = 0;
        }

        public virtual void ProcessState()
        {

        }

        public virtual void ExitState()
        {
            StateTime = 0;
        }

        public void RegisterTransistion(string transKey, TankState toState)
        {
            TransDict.Add(transKey, new TankTransition(Owner, this, toState));
        }

        public void TriggerTransition(string transKey)
        {
            TankTransition trans;
            if (TransDict.TryGetValue(transKey, out trans))
            {
                trans.ExecuteTrans();
            }
            else
            {
                UnityEngine.Debug.LogError("未知的转移条件: " + transKey);
            }
        }
    }
}
