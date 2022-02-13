using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dvizeniaCasen : MonoBehaviour
{
    public static List<GameObject> tranPers;

    static public dvizeniaCasen instance;

    void Awake()
    {
        instance = this;
    }

    public static void dvizeniaPers(GameObject kogo, Vector3 otkuda, Vector3 kuda, float timer, string formula, bool l = false)
    {
        int o;
        switch (formula){
            case "lin": o = 0; break;
            case "Squared": o = 1; break;
            case "Cube": o = 2; break;
            case "InverseSquared": o = 3; break;
            case "SmoothSquared": o = 4; break;
            case "SquaredSglad": o = 5; break;
            case "CubDorg": o = 6; break;
            default:Debug.LogError("не обнарузен резим: " + formula);kogo.transform.position = kuda;
                return;
        }
        dvizeniaPers(kogo, otkuda, kuda, timer, o,l);
    }
    
    public static void dvizeniaPers(int kogo, Vector3 otkuda, Vector3 kuda, float timer, string formula, bool l = false)
    { dvizeniaPers(tranPers[kogo], otkuda, kuda, timer, formula, l); }
    public void dvizeniaPers(int kogo, Vector3 otkuda, Vector3 kuda, float timer, int formula, bool l = false)
    { dvizeniaPers(tranPers[kogo], otkuda, kuda, timer, formula, l); }
    public static void dvizeniaPers(int kogo, Vector3 kuda, float timer, string formula, bool l = false)
    { dvizeniaPers(tranPers[kogo], !l ? tranPers[kogo].transform.position : tranPers[kogo].transform.localPosition, kuda, timer, formula, l); }
    public static void dvizeniaPers(GameObject kogo, Vector3 kuda, float timer, int formula, bool l = false)
    { dvizeniaPers(kogo, !l ? kogo.transform.position : kogo.transform.localPosition, kuda, timer, formula, l); }
    public static void dvizeniaPers(int kogo, Vector3 kuda, float timer, int formula, bool l = false)
    { dvizeniaPers(tranPers[kogo], !l ? tranPers[kogo].transform.position : tranPers[kogo].transform.localPosition, kuda, timer, formula, l); }
    public static void dvizeniaPers(GameObject kogo, Vector3 otkuda, Vector3 kuda, float timer, int formula,bool l = false)
    { instance.StartCoroutine(dvizeniaPersF(kogo, otkuda, kuda, timer, formula, l));}

    private static IEnumerator dvizeniaPersF(GameObject kogo, Vector3 otkuda, Vector3 kuda, float timer, int formula, bool l)
    {
        if (!l)
        {
            kogo.transform.position = otkuda;

            if (otkuda == kuda) Debug.Log("тазе точка");

            float x = (kuda.x - otkuda.x) / (25 * timer);
            float y = (kuda.y - otkuda.y) / (25 * timer);
            float z = (kuda.z - otkuda.z) / (25 * timer);

            for (int i = 0; i < timer * 25; i++)
            {
                kogo.transform.position = new Vector3(kogo.transform.position.x + x, kogo.transform.position.y + y, kogo.transform.position.z + z);
                yield return new WaitForSeconds(timer / 25);
            }
            kogo.transform.position = kuda;
        }
        else
        {
            kogo.transform.localPosition = otkuda;

            if (otkuda == kuda) Debug.Log("тазе точка");

            float x = (kuda.x - otkuda.x) / (25 * timer);
            float y = (kuda.y - otkuda.y) / (25 * timer);
            float z = (kuda.z - otkuda.z) / (25 * timer);

            for (int i = 0; i < timer * 25; i++)
            {
                kogo.transform.localPosition = new Vector3(kogo.transform.localPosition.x + x, kogo.transform.localPosition.y + y, kogo.transform.localPosition.z + z);
                yield return new WaitForSeconds(timer / 25);
            }
            kogo.transform.localPosition = kuda;
        }
    }

    float EasingSquared(float x)
    {return x*x;}
    float EasingCube(float x)
    {return x*x*x;}
    float EasingInverseSquared(float x)
    { return 1 - (1 - x) * (1 - x); }
    float EasingSmoothSquared(float x)
    { return x < 0.5 ? x * x * 2 : (1 - (1 - x) * (1 - x) * 2); }
    float EasingSquaredSglad(float x)
    { return -(x - 1) * (x - 1) * 3 + 2.8f; }
    float EasingCubDorg(float x)
    { return -(x - 1) * (x - 1) * (x - 5) * 3 + 2.8f; }
}
