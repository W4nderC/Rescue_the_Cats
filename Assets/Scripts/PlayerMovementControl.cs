using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
    [SerializeField] private PlayerInputAction playerInputAction;
    [SerializeField] private float moveSpd = 10f;
    private float spdUpValue = .7f;
     
    private void Awake() 
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();
    }

    void Start()
    {
        GameManager.Instance.OnSpeedUp += GameManager_OnSpeedUp;
    }

    private void GameManager_OnSpeedUp(object sender, EventArgs e)
    {
        moveSpd += spdUpValue;
    }

    void Update()
    {
        if (IsGamePlaying())
        {
            Vector2 inputVector = GetInputVectorNormalized();

            Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
            transform.position += moveDir * Time.deltaTime * moveSpd;
        }
        print("current spd: "+moveSpd);
    }

    private bool IsGamePlaying()
    {
        return GameManager.Instance.CheckGameState(GameManager.GameState.GamePhase1) ||
        GameManager.Instance.CheckGameState(GameManager.GameState.GamePhase2);
    }

    private Vector2 GetInputVectorNormalized()
    {
        Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

        return inputVector;
    }
}
