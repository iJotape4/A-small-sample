using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed = 10f;
    public float angle = 30f;
    Rigidbody rb ;
    
    void Awake()
    {
        rb=GetComponent<Rigidbody>();       
    }
    
    public void shotBall()
    {
        rb.velocity = transform.TransformDirection(new Vector3(0,Mathf.Clamp(angle,0f, 30f), Mathf.Clamp(ballSpeed,0f, 100f)));
    }
}
