using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RaytraceScript : MonoBehaviour
{
    RaycastHit hitInfo;
    public Image Aim;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward, Color.magenta);
        Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo);
        ColorAim();
    }

    void ColorAim()
    {
        if (hitInfo.transform && hitInfo.transform.gameObject.CompareTag("decoration"))
        {
            Debug.Log(hitInfo.transform.gameObject.tag);
            hitInfo.collider.GetComponent<ThrowScript>().hasPlayer = true;
            Aim.color = Color.green;
        }
        else
        {
            Aim.color = Color.red;
        }
    }
    
}
