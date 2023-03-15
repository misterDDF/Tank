using System.Collections;
using System.Collections.Generic;
using Complete;
using UnityEngine;

public class TankPlayer : MonoBehaviour
{
    public TankMovement MovePlayer;
    public TankShooting ShootingPlayer;
    public TankHealth HealthPlayer;
    public TankTrigger TriggerPlayer;
    public GameObject BKBEffect;

    private float damage;
    public float Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
            ShootingPlayer.Damage = value;
        }
    }

    private float BKBTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        Damage = ConstDefine.DAMAGE_PLAYER_SHOOT;
        TriggerPlayer.onTriggerEnter = (Collider other) =>
        {
            if(other.gameObject.tag == ConstDefine.TAG_GROUND)
            {
                return;
            }

            if(other.gameObject.tag == ConstDefine.TAG_AI)
            {
                HealthPlayer.TakeDamage(other.GetComponent<TankAI>().Damage);
            }
            else if(other.gameObject.tag == ConstDefine.TAG_BUFF)
            {
                other.GetComponent<BuffCapcule>().ActivateBuff(this);
            }
            else
            {
                HealthPlayer.TakeDamage(ConstDefine.DAMAGE_PLAYER_HITWALL);
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(BKBTime > 0)
        {
            BKBTime -= Time.deltaTime;
            BKBEffect.SetActive(true);
            HealthPlayer.BKBState = true;
            return;
        }
        BKBTime = 0;
        BKBEffect.SetActive(false);
        HealthPlayer.BKBState = false;
    }

    public void ActivateBKB(float BKBTime)
    {
        this.BKBTime = BKBTime;
    }
}
