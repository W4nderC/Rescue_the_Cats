using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tsunami : MonoBehaviour, IDealDmgToPlayer
{
    private Vector3 targetPos;
    private float moveSpd = 10f;

    private void Start()
    {
        targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1550f);
    }

    private void Update()
    {
        if(IsGamePlaying()) 
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpd * Time.deltaTime);
        }
        
    }

    private bool IsGamePlaying()
    {
        return GameManager.Instance.CheckGameState(GameManager.GameState.GamePhase1) 
        || GameManager.Instance.CheckGameState(GameManager.GameState.GamePhase2);
    }

    public void DealDamage()
    {
        GameManager.Instance.InvokeOnGameFinished();
    }
}
