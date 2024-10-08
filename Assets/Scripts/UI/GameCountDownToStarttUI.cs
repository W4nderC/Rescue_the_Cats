using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCountDownToStarttUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownTxt;

    void Start()
    {
        GameManager.Instance.OnStartGamePhase1 += GameManager_OnStartGamePhase1;
        Show();
    }

    private void GameManager_OnStartGamePhase1(object sender, EventArgs e)
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.CheckGameState(GameManager.GameState.GameCountDownToStart)) 
        {
            countDownTxt.text = Convert.ToInt32(GameManager.Instance.countDownToStartTimer).ToString();
            // print("touchCount: "+Input.touchCount);

            if (Input.touchCount > 0)
            {
                GameManager.Instance.InvokeOnSpeedUpEvt();        
            }
        }

    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnStartGamePhase1 -= GameManager_OnStartGamePhase1;
    }
}
