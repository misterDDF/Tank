using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complete
{
    public class TankTransition
    {
        public TankAI Owner;
        private TankState fromState;
        private TankState toState;

        public TankTransition(TankAI owner, TankState fromState, TankState toState)
        {
            Owner = owner;
            this.fromState = fromState;
            this.toState = toState;
        }

        public void ExecuteTrans()
        {
            fromState.ExitState();
            toState.EnterState();
            Owner.CurState = toState;
        }
    }
}
