using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complete
{
    public class TankStateAwait : TankState
    {
        public TankStateAwait(TankAI owner) : base(owner)
        {

        }

        public override void EnterState()
        {
            base.EnterState();
            Owner.MoveAI.SetNavActive(false);
        }

        public override void ProcessState()
        {
            base.ProcessState();

            if(StateTime > ConstDefine.CHARGE_AWAIT_TIME)
            {
                TriggerTransition(TransKeyDefine.LostPlayer);
            }
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}
