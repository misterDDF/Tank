using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public enum BuffType
    {
        None = 0,
        Freeze = 1,
        BKB = 2,
    }

    public class BuffCapcule : MonoBehaviour
    {
        public BuffType Type;

        public void ActivateBuff(TankPlayer player)
        {
            switch (Type)
            {
                case BuffType.Freeze:
                    GameManager.Instance.FreezeAITank(ConstDefine.FREEZE_DIS, ConstDefine.FREEZE_TIME);
                    break;
                case BuffType.BKB:
                    GameManager.Instance.ActivateBKB(ConstDefine.BKB_TIME);
                    break;
            }

            Destroy(this.gameObject);
        }
    }

}
