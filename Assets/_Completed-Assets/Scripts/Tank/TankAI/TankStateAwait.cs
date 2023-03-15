using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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

            Vector3 direction = GameManager.Instance.GetPlayerGO().transform.position - Owner.transform.position;
            Quaternion toRotation = Quaternion.FromToRotation(Owner.transform.forward, direction);
            Owner.transform.rotation = Quaternion.Lerp(Owner.transform.rotation, toRotation, Time.deltaTime);
            if (StateTime > ConstDefine.CHARGE_AWAIT_TIME)
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
