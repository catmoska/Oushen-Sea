using System;
using UnityEngine;

public class supolso : MonoBehaviour
{
    public Transform pleir;
    public float distons;
    private Animator an;
    private bool i;
    private supolso skrit;

    void Start()
    {
        an = GetComponent<Animator>();
        skrit = GetComponent<supolso>();
    }

    void FixedUpdate()
    {
        an.SetBool("blis", pleir != null && Math.Abs(pleir.position.y - transform.position.y) <= distons);


        if (i && !(pleir != null && Math.Abs(pleir.position.y - transform.position.y) <= distons)) skrit.enabled = false;

        i = pleir != null && Math.Abs(pleir.position.y - transform.position.y) <= distons;

    }
}
