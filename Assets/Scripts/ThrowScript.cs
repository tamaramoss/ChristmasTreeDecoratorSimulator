using System;
using UnityEngine;
using System.Collections;
using Cinemachine;
using UnityEngine.UI;

public class ThrowScript : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public Image Aim;
    public float throwForce = 10;
    public float pickUpDistance = 2.5f;
    bool hasPlayer = false;
    bool beingCarried = false;
    // public AudioClip[] soundToPlay;
    // private AudioSource audio;
    public int dmg;
    private bool touched = false;

    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (Aim.color == Color.green)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        if (hasPlayer && Input.GetMouseButtonDown(1) && !beingCarried)
        {
            Debug.Log("Pick up");
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = player.Find("HoldPosition").position;
            transform.parent = playerCam;
            
            playerCam.GetComponent<CinemachineVirtualCamera>().LookAt = transform;
            beingCarried = true;
        }
        if (beingCarried)
        {
            // if (touched)
            // {
            //     GetComponent<Rigidbody>().isKinematic = false;
            //     transform.parent = null;
            //     beingCarried = false;
            //     touched = false;
            // }
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
                RandomAudio();
            }
            // else if (Input.GetMouseButtonDown(1))
            // {
            //     GetComponent<Rigidbody>().isKinematic = false;
            //     transform.parent = null;
            //     beingCarried = false;
            // }
        }
    }
    void RandomAudio()
    {
        // if (audio.isPlaying){
        //     return;
        //         }
        // audio.clip = soundToPlay[Random.Range(0, soundToPlay.Length)];
        // audio.Play();

    }

    }