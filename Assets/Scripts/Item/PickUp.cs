using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            PickUpItem(other);
        }
    }

    private void PickUpItem(Collider player)
    {

        Gun playerGun = player.GetComponentInChildren<Gun>();
        playerGun._reserves += playerGun._magazine;
        playerGun.updateText();

        Destroy(transform.parent.gameObject);
    }
}
