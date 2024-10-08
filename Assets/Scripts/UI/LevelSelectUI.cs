using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUI : MonoBehaviour
{
    [SerializeField] private Button[] levelBtn;

    void Start()
    {
        for(int i = 0; i < levelBtn.Length; i++) 
        {
            if(i == 0) // First level
            {
                levelBtn[i].onClick.AddListener(() => {
                    MapGenerator.Instance.FirstLevel();
                    GameManager.Instance.InvokeOnEndLevelSelect();
                });
            }
        }

        GameManager.Instance.OnEndLevelSelect += GameManager_OnEndLevelSelect;

        Show();
    }

    private void GameManager_OnEndLevelSelect(object sender, EventArgs e)
    {
        Hide();
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
