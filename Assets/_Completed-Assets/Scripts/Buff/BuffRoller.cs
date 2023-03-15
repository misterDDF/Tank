using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class BuffRoller : MonoBehaviour
    {
        public GameObject BuffCapsulePrefab;

        public BuffRoller()
        {

        }

        public void RollBuff(Transform genTrans)
        {
            float dropRand = UnityEngine.Random.Range(0, 100);
            if (dropRand < ConstDefine.BUFF_DROP_RATE)
            {
                GameObject buffCapsuleGO = Instantiate(BuffCapsulePrefab, genTrans.position, genTrans.rotation);
                buffCapsuleGO.transform.parent = GameObject.Find("BuffParent").transform;

                float buffRand = UnityEngine.Random.Range(0, 100);
                  if (CheckInBuffange(buffRand, BuffType.Freeze))
                {
                    BuffCapcule buff = buffCapsuleGO.AddComponent<BuffCapcule>();
                    buff.Type = BuffType.Freeze;
                }
                else
                {
                    BuffCapcule buff = buffCapsuleGO.AddComponent<BuffCapcule>();
                    buff.Type = BuffType.BKB;
                }
            }
        }

        public bool CheckInBuffange(float buffRand, BuffType buffType)
        {
            bool flag = false;
            switch (buffType)
            {
                case BuffType.Freeze:
                    if (buffRand >= ConstDefine.BUFF_FREEZE_RATE[0] && buffRand < ConstDefine.BUFF_FREEZE_RATE[1])
                    {
                        flag = true;
                    }
                    break;
                case BuffType.BKB:
                    if (buffRand >= ConstDefine.BUFF_BKB_RATE[0] && buffRand < ConstDefine.BUFF_BKB_RATE[1])
                    {
                        flag = true;
                    }
                    break;
                default:
                    flag = false;
                    break;
            }
            return flag;
        }
    }
}
