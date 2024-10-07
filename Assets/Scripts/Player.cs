using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        IDealDmgToPlayer dealDmgToPlayer = other.gameObject.GetComponent<IDealDmgToPlayer>();
        if (dealDmgToPlayer != null)
        {
            dealDmgToPlayer.DealDamage();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        IEndOfPhase endOfPhase = other.gameObject.GetComponent<IEndOfPhase>();
        if (endOfPhase != null)
        {
            endOfPhase.EndGamePhase();
        } 
    }
}
