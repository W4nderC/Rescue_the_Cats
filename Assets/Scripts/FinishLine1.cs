using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine1 : MonoBehaviour, IEndOfPhase
{
    public void EndGamePhase()
    {
        GameManager.Instance.InvokeOnEndGamePhase1();
    }

}
