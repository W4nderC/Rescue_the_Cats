using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameJoyStickUI : MonoBehaviour
{

    private void Start() 
    {
        GameManager.Instance.OnStartGamePhase1 += GameManager_OnStartGamePhase1;
        Hide();
    }

    private void GameManager_OnStartGamePhase1(object sender, EventArgs e)
    {
        Show();
    }

    private void Update()
    {
        // if(Input.touchCount > 0) 
        // {
            // for (int i = 0; i < Input.touchCount; i++)
            // {
                // if (Input.GetTouch(0).phase == TouchPhase.Began)
                // {
                //     Touch touch = Input.GetTouch(0);
                //     // gameObject.transform.position = new Vector3 (Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, transform.position.z);    
                //     gameObject.transform.position = Input.GetTouch(0).position;
                // }
            // }

        // }
    }

    private void Hide () 
    {
        gameObject.SetActive(false);        
    }

    private void Show () 
    {
        gameObject.SetActive(true);        
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnStartGamePhase1 -= GameManager_OnStartGamePhase1;
    }
}
