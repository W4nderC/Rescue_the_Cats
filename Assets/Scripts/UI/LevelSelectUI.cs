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

        levelBtn[0].onClick.AddListener(() => {
            MapGenerator.Instance.FirstLevel();
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[1].onClick.AddListener(() => {
            int level = 2;
            MapGenerator.Instance.CreateLevel(level);
            Tsunami.IncreaseTsunamiSpd(level);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[2].onClick.AddListener(() => {
            int level = 3;
            MapGenerator.Instance.CreateLevel(level);
            Tsunami.IncreaseTsunamiSpd(level);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[3].onClick.AddListener(() => {
            int level = 4;
            MapGenerator.Instance.CreateLevel(level);
            Tsunami.IncreaseTsunamiSpd(level);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[4].onClick.AddListener(() => {
            int level = 5;
            MapGenerator.Instance.CreateLevel(level);
            Tsunami.IncreaseTsunamiSpd(level);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[5].onClick.AddListener(() => {
            int level = 6;
            MapGenerator.Instance.CreateLevel(level);
            Tsunami.IncreaseTsunamiSpd(level);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[6].onClick.AddListener(() => {
            int level = 7;
            MapGenerator.Instance.CreateLevel(level);
            Tsunami.IncreaseTsunamiSpd(level);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[7].onClick.AddListener(() => {
            int level = 8;
            MapGenerator.Instance.CreateLevel(level);
            Tsunami.IncreaseTsunamiSpd(level);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[8].onClick.AddListener(() => {
            int level = 9;
            MapGenerator.Instance.CreateLevel(level);
            Tsunami.IncreaseTsunamiSpd(level);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[9].onClick.AddListener(() => {
            int level = 10;
            MapGenerator.Instance.CreateLevel(level);
            Tsunami.IncreaseTsunamiSpd(level);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });

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
