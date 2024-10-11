using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovementControl playerMovementControl;

    private void Start()
    {
        FollowPlayer.OnAnyCatTouched += FollowPlayer_OnAnyCatTouched;
    }

    private void FollowPlayer_OnAnyCatTouched(object sender, EventArgs e)
    {
        FollowPlayer followPlayer = sender as FollowPlayer;
        followPlayer.isFollow = true;
    }

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
        FollowPlayer followPlayer = other.gameObject.GetComponent<FollowPlayer>();
        if (followPlayer != null)
        {
            followPlayer.InvokeOnAnyCatTouched();
            followPlayer.player = this;
            followPlayer.followSpd = playerMovementControl.moveSpd;
            followPlayer.IncreaseCatNum();
        }
    }

    private void OnDestroy()
    {
        FollowPlayer.OnAnyCatTouched -= FollowPlayer_OnAnyCatTouched;
    }
}
