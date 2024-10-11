using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFailedUI : MonoBehaviour
{
    [SerializeField] private Button returnButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        returnButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.PlayingScene);
        });
        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });
        
    }

    void Start()
    {
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;

        Hide();
    }

    private void GameManager_OnGameOver(object sender, EventArgs e)
    {
        Show();
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
        GameManager.Instance.OnGameOver -= GameManager_OnGameOver;
    }
}
