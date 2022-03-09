using System;
using UnityEngine;

public class Supolso : MonoBehaviour
{
    public Transform Pleir;
    public float Distons;
    private Animator AN;
    private bool i;
    private Supolso Skript;

    void Start()
    {
        AN = GetComponent<Animator>();
        Skript = GetComponent<Supolso>();
    }

    void FixedUpdate()
    {
        AN.SetBool("blis", Pleir != null && Math.Abs(Pleir.position.y - transform.position.y) <= Distons);


        if (i && !(Pleir != null && Math.Abs(Pleir.position.y - transform.position.y) <= Distons)) Skript.enabled = false;

        i = Pleir != null && Math.Abs(Pleir.position.y - transform.position.y) <= Distons;

    }
}
