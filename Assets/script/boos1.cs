using System.Collections.Generic;
using UnityEngine;

public class Boos1 : MonoBehaviour
{
    public bool obectt = false;
    public GameObject FairBool;
    GameObject FairBoolV;
    public List<GameObject> dell;
    Transform t;
    float o;

    public void startt(Transform ti, float o2)
    {
        obectt = false;
        o = o2;
        t = ti;
    }

    public List<GameObject> delll()
    {
        obectt = false;
        return dell;
    }

    void FixedUpdate()
    {
        if (!obectt && t !=null)
        {
            if ((o -t.position.x)>80) 
            {
                float i;
                if (Random.Range(0, 2) == 0)
                    i = (Random.Range((int)(-PleirControler.Boundary * 50), (int)(PleirControler.Boundary * 50)) / 50) / Random.Range(1, 4) * Random.Range(1, 2);
                else
                    i = t.position.x;
                transform.localPosition = new Vector3(i, 21.8f, 10.8f);
                FairBoolV = Instantiate(FairBool, new Vector2(i, transform.position.y), Quaternion.identity);
                Supolso s = FairBoolV.GetComponent<Supolso>();
                s.Pleir = t;
                dell.Add(FairBoolV);
                obectt = true;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            Supolso p = FairBoolV.GetComponent<Supolso>();
            if (!p.enabled) obectt = false;
        }
    }
}
