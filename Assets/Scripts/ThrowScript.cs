using System;
using UnityEngine;
using System.Collections;
using Cinemachine;
using UnityEngine.UI;

public class ThrowScript : MonoBehaviour
{
    public int scoreValue = 10;
    public Transform player;
    public Transform playerCam;
    public float throwForce = 400.0f;
    public float pickUpDistance = 2.5f;
    public bool hasPlayer = false;
    bool beingCarried = false;
    // public AudioClip[] soundToPlay;
    // private AudioSource audio;
    public int dmg;
    private bool touched = false;
    private bool attached = false;
    private Rigidbody rb;
    private GameManager gameManager;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        playerCam = GameObject.Find("PlayerCam").transform;
        rb = GetComponent<Rigidbody>();
        gameManager = GameManager.instance;

        //audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // float dist = Vector3.Distance(gameObject.transform.position, player.position);

        if (hasPlayer && Input.GetMouseButtonDown(1) && !beingCarried && !attached)
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
        hasPlayer = false;

    }
    void RandomAudio()
    {
        // if (audio.isPlaying){
        //     return;
        //         }
        // audio.clip = soundToPlay[Random.Range(0, soundToPlay.Length)];
        // audio.Play();

    }

    void OnCollisionEnter(Collision col) 
    {
        if(!attached)
        {
            if(col.gameObject.tag == "tree")
            {
                FixedJoint joint = col.gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = rb;
                // rb.mass = 0.0f;
                attached = true;
                gameManager.addScore(scoreValue);
            }
        }
    }
}