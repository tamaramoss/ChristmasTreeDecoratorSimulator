using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinDecoWithTree : MonoBehaviour
{
    private bool attached = false;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }   

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision col) 
    {
        if(!attached)
        {
            if(col.gameObject.tag == "tree")
            {
                FixedJoint joint = col.gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = rb;
                rb.mass = 0.0f;
                attached = true;
            }
        }
    }
}
