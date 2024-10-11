using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine1 : MonoBehaviour, IEndOfPhase
{
    private void Start()
    {
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
        GameManager.Instance.OnEndGamePhase1 += GameManager_OnEndGamePhase1;
        Show();
    }

    private void GameManager_OnEndGamePhase1(object sender, EventArgs e)
    {
        Hide();
    }

    private void GameManager_OnGameOver(object sender, EventArgs e)
    {
        Hide();
    }

    public void EndGamePhase()
    {
        GameManager.Instance.InvokeOnGameOver();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameOver -= GameManager_OnGameOver;
        GameManager.Instance.OnGameFinished -= GameManager_OnEndGamePhase1;
    }
}
