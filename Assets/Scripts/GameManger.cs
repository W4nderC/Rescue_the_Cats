using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance { get; private set;}

    public event EventHandler OnGameFinished;

    private float countDownToStartTimer = 3f; 

    public enum GameState
    {
        GameCountDownToStart,
        GamePhase1,
        GamePhase2,
        GameFinished
    }

    public GameState gameState;

    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } 
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        OnGameFinished += GameManer_OnGameFinished;
    }

    private void GameManer_OnGameFinished(object sender, EventArgs e)
    {
        print("Game finished ");
    }

    private void Update()
    {
        GameStateHandler();
        print("current gameState: "+gameState);
    }

    private void GameStateHandler () 
    {
        switch(gameState)
        {
            case GameState.GameCountDownToStart:
                countDownToStartTimer -= Time.deltaTime;
                if(countDownToStartTimer <= 0) 
                {
                    SetGameState(GameState.GamePhase1);
                }
                break;
            case GameState.GamePhase1:
                break;
            case GameState.GamePhase2:
                break;
            case GameState.GameFinished:
                break;
        }   
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
    }

    public bool CheckGameState (GameState gameState) 
    {
        return this.gameState == gameState;
    }

    public void InvokeOnGameFinished()
    {
        OnGameFinished?.Invoke(this, EventArgs.Empty);
        SetGameState(GameState.GameFinished);
    }
}
