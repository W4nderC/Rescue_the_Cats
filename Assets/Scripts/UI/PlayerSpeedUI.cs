using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSpeedUI : MonoBehaviour
{
    public TextMeshProUGUI playerSpdTxt;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnEndLevelSelect += GameManager_OnEndLevelSelect;

        Hide();
    }

    private void GameManager_OnEndLevelSelect(object sender, EventArgs e)
    {
        Show();
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
        GameManager.Instance.OnEndLevelSelect -= GameManager_OnEndLevelSelect;
    }
}
