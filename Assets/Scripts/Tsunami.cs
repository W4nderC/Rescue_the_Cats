using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tsunami : MonoBehaviour, IDealDmgToPlayer
{
    private Vector3 targetPos;
    private float moveSpd = 10f;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1550f);
    }

    private void Update()
    {
        if(!GameManger.Instance.CheckGameState(GameManger.GameState.GameCountDownToStart)
        && !GameManger.Instance.CheckGameState(GameManger.GameState.GameFinished)) 
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpd * Time.deltaTime);
        }
        
    }

    public void DealDamage()
    {
        GameManger.Instance.InvokeOnGameFinished();
    }
}
