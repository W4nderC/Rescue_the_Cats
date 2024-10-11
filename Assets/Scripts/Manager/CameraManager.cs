using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnEndGamePhase1 += GameManager_OnEndGamePhase1;
        cameras[0].SetActive(true);
        cameras[1].SetActive(false);
    }

    private void GameManager_OnEndGamePhase1(object sender, EventArgs e)
    {
        cameras[0].SetActive(false);
        cameras[1].SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
