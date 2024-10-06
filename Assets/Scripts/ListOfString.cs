using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfString : MonoBehaviour
{
    public static ListOfString Instance { get; private set; }

    public const string GAME_COUNT_DOWN_TO_START = "GameCountDownToStart";
    public const string GAME_PHASE_1 = "GamePhase1";
    public const string GAME_PHASE_2 = "GamePhase2";
    public const string GAME_FINISHED = "GameFinished";

    public const string PLAYER = "Player";

    private void Awake() 
    {
        if(Instance != null && Instance != this) 
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
