using System.Collections.Generic;
using UnityEngine;

public class boos1 : MonoBehaviour
{
    public bool obectt = false;
    public GameObject fairBool;
    GameObject fairBoolV;
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
                    i = (Random.Range((int)(-PleirControler.granisa * 50), (int)(PleirControler.granisa * 50)) / 50) / Random.Range(1, 4) * Random.Range(1, 2);
                else
                    i = t.position.x;
                transform.localPosition = new Vector3(i, 21.8f, 10.8f);
                fairBoolV = Instantiate(fairBool, new Vector2(i, transform.position.y), Quaternion.identity);
                supolso s = fairBoolV.GetComponent<supolso>();
                s.pleir = t;
                dell.Add(fairBoolV);
                obectt = true;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            supolso p = fairBoolV.GetComponent<supolso>();
            if (!p.enabled) obectt = false;
        }
    }
}
