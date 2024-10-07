using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    public event EventHandler OnStartGamePhase1;
    public event EventHandler OnEndGamePhase1;
    public event EventHandler OnGameFinished;
    public event EventHandler OnSpeedUp;

    [HideInInspector] public float countDownToStartTimer = 3f; 
    private float timeConsumed;

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
        OnGameFinished += GameManager_OnGameFinished;
        OnStartGamePhase1 += GameManager_OnStartGamePhase1;
    }

    private void GameManager_OnStartGamePhase1(object sender, EventArgs e)
    {
        SetGameState(GameState.GamePhase1);
    }

    private void GameManager_OnGameFinished(object sender, EventArgs e)
    {
        print("Game finished ");
    }

    private void Update()
    {
        GameStateHandler();
        // print("current gameState: "+gameState);
    }

    private void GameStateHandler () 
    {
        switch(gameState)
        {
            case GameState.GameCountDownToStart:
                countDownToStartTimer -= Time.deltaTime;
                if(countDownToStartTimer <= 0) 
                {
                    OnStartGamePhase1?.Invoke(this, EventArgs.Empty);
                }
                break;
            case GameState.GamePhase1:
            timeConsumed += Time.deltaTime;
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

    public void InvokeOnEndGamePhase1()
    {
        OnEndGamePhase1?.Invoke(this, EventArgs.Empty);
        SetGameState(GameState.GamePhase2);
        // print("Time need to end phase 1: "+timeConsumed);
    }

    public void InvokeOnSpeedUpEvt () 
    {
        OnSpeedUp?.Invoke(this, EventArgs.Empty);
    }
}
