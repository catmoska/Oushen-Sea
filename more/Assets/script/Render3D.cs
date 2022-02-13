using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Render3D : MonoBehaviour
{
    public Transform cam;
    public float mnozetel = 20;
    private BoxCollider2D bc;
    private bool bcB;
    private float dalnas = 20;
    public float dalnasis;
    private Render3D rD;


    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        rD = GetComponent<Render3D>();
    }

    float kvadr(float i)
    { return i * i; }


    void FixedUpdate()
    {
        float dalnast = (float)Math.Sqrt(kvadr(cam.position.x - transform.position.x) + 
            kvadr(cam.position.y - transform.position.y) + kvadr(cam.position.z - transform.position.z));

        dalnast = 1 / dalnast* mnozetel;
        if (transform.position.y- cam.position.y < -5)
        {
            bc.enabled = false;
            bcB = true;
        }
        if (bcB && dalnast> dalnasis)
        {
            rD.enabled = false;
        }

        dalnas = dalnast;
        transform.localScale = new Vector3(dalnast/1.3f, dalnast, 0);
    }


}
