using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")){
            var player = other.gameObject.GetComponent<Player>();
            if (player == null) return;
            PlayerStay(other, player);
        }
    }

    protected virtual void PlayerStay(Collider other, Player player)
    {
    }
}
