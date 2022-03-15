using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Analtic : MonoBehaviour
{
    private bool PP = false;


    void Start()
    {
        Analytics.CustomEvent("start");
    }

    public void FooPP()
    {
        if (!PP)
        {
            Analytics.CustomEvent("PPT");
            PP = true;
        }
    }

    public void gemOv(string rec,int tin)
    {
        Analytics.CustomEvent("record", new Dictionary<string, object> {
            {"levelMax",rec},
            {"levelTin", tin.ToString()}
        });
    }
}
