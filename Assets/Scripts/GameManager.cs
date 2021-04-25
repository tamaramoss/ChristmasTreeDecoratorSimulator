using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Cinemachine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float remainingTime = 100f;
    // Start is called before the first frame update
    int score = 0;
    public TextMeshProUGUI TMPtimer;
    public TextMeshProUGUI TMPscore;

    public AudioClip clip;
    public AudioSource audioSource;

    public GameObject canvas;
    public GameObject canvasOther;
    public GameObject player;
    public GameObject VirtualCamera;
    public Camera cam;
    private bool levelEnded = false;


    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (levelEnded)
            return;
        
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;   
            TMPtimer.text =  ((int)Math.Round(remainingTime, 0)).ToString();
        } else
        {
            levelEnded = true;
            canvas.SetActive(true);
            //canvasOther.SetActive(false);
            cam.GetComponent<RaytraceScript>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            VirtualCamera.SetActive(true);
        }
    }
    public void addScore(int value)
    {
        score += value;
        TMPscore.text = score.ToString();
        audioSource.clip = clip;
        if(!audioSource.isPlaying)
        {
            audioSource.time = 1.9f;
            audioSource.Play();
        }
    }
}
