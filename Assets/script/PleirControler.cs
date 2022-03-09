using System;
using System.Collections;
using UnityEngine;

public class PleirControler : MonoBehaviour
{
    public float Speed = 20;//speed
    public float SpeedUP = 20;//speedUP
    public float SpeedTrigger = 30;//speedTriger
    public static float Boundary = 65;//granisa
    public float BoundaryS = 65;//granisaS
    private Animator AN;//an
    public GameObject Death;//smert

    public SpawnCoral SpawnCoral;//spavnCor
    public CameraControler cameraCon;//cameraCon

    private void Awake()
    {
        Boundary = BoundaryS;
    }

    private void Start()
    {
        AN = GetComponent<Animator>();
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
        Instantiate(Death, transform.position, Quaternion.identity);
        SpawnCoral.Res2();
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
                barer();
            if (Input.GetKeyDown(KeyCode.F7))
                SpeedUP -= 10;
            else if (Input.GetKeyDown(KeyCode.F8))
                SpeedUP += 10;
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
        transform.Translate(Vector2.right * xMovi * Speed * Time.deltaTime);
        transform.Translate(Vector2.up * (SpeedUP - Math.Abs(xMovi) * (SpeedUP / 20)) * Time.deltaTime);

        if (Math.Abs(transform.position.x) > Boundary)
        {
            Res1();
        }

        if (xMovi > 0)
        {
            AN.SetBool("N", true);
            AN.SetBool("L", false);
        }
        else if (xMovi < 0)
        {
            AN.SetBool("L", true);
            AN.SetBool("N", false);
        }
        else
        {
            AN.SetBool("N", false);   // плохая идея
            AN.SetBool("L", false);
            if(SpeedTrigger < SpeedUP)
                AN.SetBool("spid", true);
        }
    }
}
