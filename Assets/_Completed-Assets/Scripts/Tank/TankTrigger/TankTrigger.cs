using System;
using System.Collections;
using System.Collections.Generic;
using Complete;
using UnityEngine;

public class TankTrigger : MonoBehaviour
{
    public Action<Collider> onTriggerEnter;
    public Action<Collider> onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit?.Invoke(other);
    }

    public void SetTriggerActive(bool isActive)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = isActive;
    }
}
