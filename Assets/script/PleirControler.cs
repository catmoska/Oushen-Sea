using System;
using System.Collections;
using UnityEngine;

public class PleirControler : MonoBehaviour
{
    public float speed = 20;
    public float speedUP = 20;
    public float speedTriger = 30;
    public static float granisa = 65;
    public float granisaS = 65;
    public Animator an;
    public GameObject smert;

    public SpawnCoral spavnCor;
    public cameraControler cameraCon;
    private SpriteRenderer SR;

    private void Awake()
    {
        granisa = granisaS;
        SR = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "scola")
        {
            Res1();
        }
        else
        if (collision.gameObject.tag == "plus")
        {
            Destroy(collision.gameObject);
            barerV();
        }

    }

    private void Res1()
    {
        cameraCon.enabled = false;
        Instantiate(smert, transform.position, Quaternion.identity);
        spavnCor.Res2();
    }


    void barer()
    {
        BoxCollider2D e = GetComponent<BoxCollider2D>();
        e.enabled = !e.enabled;
    }

    void barerV()
    {
        StartCoroutine(barerc());
    }

    public IEnumerator barerc()
    {
        barer();
        yield return new WaitForSeconds(5f);
        barer();
    }

    private bool yt;
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.F6))
            {
                barer();
            }
            if (Input.GetKeyDown(KeyCode.F7))
            {
                speedUP -= 10;
            }
            else if (Input.GetKeyDown(KeyCode.F8))
            {
                speedUP += 10;
            }
        }
    }

    float nirm(float i)
    {
        if (i > 0) i = 1;
        else if (i < 0) i = -1;
        return i;
    }


    private bool L;
    private bool N;
    public void l()
    {
        L = true;
    }
    public void n()
    {
        N = true;
    }

    public void lN()
    {
        L = false;
    }
    public void nN()
    {
        N = false;
    }

    void FixedUpdate()
    {
        float xMovv;
        if (L && N) xMovv = 0;
        else if (L) xMovv = -1;
        else if (N) xMovv = 1;
        else xMovv = 0;

        float xMov = Input.GetAxisRaw("Horizontal");
        float xMovi = nirm(xMov + xMovv);
        transform.Translate(Vector2.right * xMovi * speed * Time.deltaTime);
        transform.Translate(Vector2.up * (speedUP - Math.Abs(xMovi) * (speedUP / 20)) * Time.deltaTime);

        if (Math.Abs(transform.position.x) > granisa)
        {
            Res1();
        }

        if (xMovi > 0)
        {
            an.SetBool("N", true);
            an.SetBool("L", false);
        }
        else if (xMovi < 0)
        {
            an.SetBool("L", true);
            an.SetBool("N", false);
        }
        else
        {
            an.SetBool("N", false);   // плохая идея
            an.SetBool("L", false);
            if(speedTriger< speedUP)
                an.SetBool("spid", true);
        }
    }
}
