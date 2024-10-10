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
            MapGenerator.Instance.CreateLevel(2);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[2].onClick.AddListener(() => {
            MapGenerator.Instance.CreateLevel(3);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[3].onClick.AddListener(() => {
            MapGenerator.Instance.CreateLevel(4);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[4].onClick.AddListener(() => {
            MapGenerator.Instance.CreateLevel(5);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[5].onClick.AddListener(() => {
            MapGenerator.Instance.CreateLevel(6);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[6].onClick.AddListener(() => {
            MapGenerator.Instance.CreateLevel(7);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[7].onClick.AddListener(() => {
            MapGenerator.Instance.CreateLevel(8);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[8].onClick.AddListener(() => {
            MapGenerator.Instance.CreateLevel(9);
            GameManager.Instance.InvokeOnEndLevelSelect();
        });
        levelBtn[9].onClick.AddListener(() => {
            MapGenerator.Instance.CreateLevel(10);
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
