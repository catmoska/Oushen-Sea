using System;
using UnityEngine;

public class Render3D : MonoBehaviour
{
    public Transform Cam;
    public float Mnozetel = 20;
    private BoxCollider2D BC;
    private bool BC_B;
    public float Dalnast;
    private Render3D rD;


    void Start()
    {
        BC = GetComponent<BoxCollider2D>();
        rD = GetComponent<Render3D>();
    }

    float kvadr(float i)
    { return i * i; }


    void FixedUpdate()
    {
        float dalnast = (float)Math.Sqrt(kvadr(Cam.position.x - transform.position.x) + 
            kvadr(Cam.position.y - transform.position.y) + kvadr(Cam.position.z - transform.position.z));

        dalnast = 1 / dalnast* Mnozetel;
        if (transform.position.y- Cam.position.y < -5)
        {
            BC.enabled = false;
            BC_B = true;
        }
        if (BC_B && dalnast> Dalnast)
        {
            rD.enabled = false;
        }

        transform.localScale = new Vector3(dalnast/1.3f, dalnast, 0);
    }


}
