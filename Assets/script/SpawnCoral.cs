using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using System;


public class SpawnCoral : MonoBehaviour
{
    public List<GameObject> Coral;
    public List<GameObject> Coral3D;
    public List<GameObject> CoralSwamp;
    public List<GameObject> Tentacles1;
    public List<GameObject> Tentacles2;
    public List<GameObject> Boat;
    public List<GameObject> Ice;
    public List<GameObject> Shark;
    public List<GameObject> Bonus;
    public List<GameObject> F4;
    public List<GameObject> boss;
    public GameObject Player;
    public float Border = 65;
    public float OffPlayer = 80;
    public float Distance = 10;
    public float DistanceLine = 10;
    public float DistanceCoral = 10;
    public float DistanceTentacles = 10;
    public float DistanceIce = 10;
    public float DistanceShark = 10;
    public float OffIce = 10;
    public float BonusChance = 5;
    public float YOff = 3;
    public float SpeedUpdate = 5;
    public List<GameObject> Dell;
    private float IntervalFromZero = 30;
    public float Interval = 30;
    public float RaznesaSUPS = 2;
    public int Cluster = 30;

    private bool F4B;
    public bool Android;
    public GameObject AndroidPlei;

    public PleirControler PleirControle;
    public CameraControler cameraCon;
    public GameObject buton;
    public GameObject paus;
    public GameObject pausB;
    public List<GameObject> pausStop;
    public Text textt;
    public GameObject textt2G;
    public Text textt2;
    private bool stop;
    private ParticleSystem ps;
    public GameObject psF;
    public GameObject fpsO;
    private Text fps;
    public Animator anVolna;
    public GameObject cam;
    private Boos1 boos1;
    private bool boos1B;
    public PostProcessVolume PPV;
    public PostProcessLayer PPL;
    private ParticleSystem.MainModule psm;
    private int tin = 0;
    private Analtic analtic;
    public AdsCore AdsCores;

    public void reset()
    {
        analtic.gemOv(textt.text, tin);
        SceneManager.LoadScene("SampleScene");
    }

    public void Res2() { StartCoroutine(Res3()); }
    public IEnumerator Res3()
    {
        textt.text = ((int)Player.transform.position.y / 5).ToString();
        textt2G.SetActive(false);
        Destroy(Player);
        yield return new WaitForSeconds(1);
        AndroidPlei.SetActive(false);
        buton.SetActive(true);
    }

    public void yvi(float i) { StartCoroutine(yviN(i)); spidEfect(i); }
    private IEnumerator yviN(float u)
    {
        float y = u / 10;
        for (int i = 0; i < 10; i++)
        {
            PleirControle.SpeedUP += y;
            PleirControle.Speed += y / RaznesaSUPS;
            yield return new WaitForSeconds(0.5f);
        }
    }

    void spidEfect(float spid)
    {psm.startSpeed = PleirControle.Speed + spid+10;}


    void sistka()
    {
        for (int i = 0; i < Dell.Count; i++)
        {
            if (Math.Abs(Dell[i].transform.position.x) >= Border + 10)
            {
                Destroy(Dell[i]);
            }
        }
        Cluster += 5;
    }

    float vibar(float i1, float i2)
    {
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            return i2;
        }
        else
            return i1;
    }

    void xuina()
    {
        for (int i = 0; i < Dell.Count; i++)
        {
            if (Dell[i].tag != "plus")
            {
                Supolso s = Dell[i].GetComponent<Supolso>();
                if (s!=null)
                    s.Pleir = Player.GetComponent<Transform>();
                else
                {
                    Debug.LogError("����� �� ����� ������� ������ 'spavnCoral/xuina()'");
                }
            }
        }
    }

    void xuina2()
    {
        for (int i = 0; i < Dell.Count; i++)
        {
            if (Dell[i].tag != "plus")
            {
                Render3D s = Dell[i].GetComponent<Render3D>();
                s.Cam = cam.GetComponent<Transform>();
                if (s == null)
                {
                    Debug.LogError("����� �� ����� ������� ������ 'spavnCoral/xuina()'");
                }
            }
        }
    }

    public void spavnStandart(float trans, List<GameObject> standart, float smemenia, float ySme, float rasto, float bonu) {spavnStandart(trans, standart, smemenia, ySme, rasto, bonu, new Vector3(0, 0, 0), false,true);}
    public void spavnStandart(float trans, List<GameObject> standart, float smemenia, float ySme, float rasto, float bonu, bool xuin) {spavnStandart(trans, standart, smemenia, ySme, rasto, bonu, new Vector3(0, 0, 0), xuin, true);}
    public void spavnStandart(float trans, List<GameObject> standart, float smemenia, float ySme, float rasto, float bonu, Vector3 nova) {spavnStandart(trans, standart, smemenia, ySme, rasto, bonu, new Vector3(0, 0, 0), false, true);}
    public void spavnStandart(float trans, List<GameObject> standart, float smemenia, float ySme, float rasto,float bonus, Vector3 nova,bool xuin,bool dablSpavn)
    {
        Vector3 novarott = new Vector3(0, vibar(0, 180),0)+nova;


        for (int i = 0; i < Cluster; i++)
        {
            float c1 = UnityEngine.Random.Range(-Border, Border);

            Dell.Add(Instantiate(standart[UnityEngine.Random.Range(0, standart.Count)],
                new Vector2(c1, trans + smemenia + (i * rasto)),
                Quaternion.Euler(new Vector3(0, vibar(0, 180), 0)+nova)));

            if (dablSpavn)
            {
                float c2;
                do
                {
                    c2 = UnityEngine.Random.Range(-Border * 2, Border * 2);
                } while (Math.Abs(c2 - c1) <= DistanceLine);

                Dell.Add(Instantiate(standart[UnityEngine.Random.Range(0, standart.Count)],
                    new Vector2(c2, trans + smemenia + (i * rasto) + UnityEngine.Random.Range(0, ySme)),
                    Quaternion.Euler(new Vector3(0, vibar(0, 180), 0) + nova)));
            }

            if (UnityEngine.Random.Range(0, (int)(100 / bonus)) == 0)
            {
                float c3;
                do
                {
                    c3 = UnityEngine.Random.Range(-Border - 10, Border - 10);
                } while (Math.Abs(c3 - c1) <= DistanceLine);

                Dell.Add(Instantiate(Bonus[UnityEngine.Random.Range(0, Bonus.Count)],
                    new Vector2(c3, trans + smemenia + (i * rasto) + UnityEngine.Random.Range(0, ySme)),
                     Quaternion.Euler(new Vector3(0, vibar(0, 180), 0) + nova)));
            }
        }
        IntervalFromZero = Dell[Dell.Count - 1].transform.position.y - Player.transform.position.y + Interval;

        if (xuin)
            xuina();

        sistka();
    }

    public void spavn1(float trans)
    {
        for (int i = 0; i < Cluster; i++)
        {
            float c1 = UnityEngine.Random.Range(-Border, Border);

            Dell.Add(Instantiate(
                Coral[UnityEngine.Random.Range(0, Coral.Count)],
                new Vector2(c1, trans + OffPlayer + (i * DistanceCoral)),
                Quaternion.Euler(new Vector2(0, vibar(0, 180)))));

            float c2;
            do
            {
                c2 = UnityEngine.Random.Range(-Border * 2, Border * 2);
            } while (Math.Abs(c2 - c1) <= DistanceLine);

            Dell.Add(Instantiate(Coral[UnityEngine.Random.Range(0, Coral.Count)],
                new Vector2(c2, trans + OffPlayer + (i * DistanceCoral) + UnityEngine.Random.Range(0, YOff)),
                Quaternion.Euler(new Vector2(0, vibar(0, 180)))));

            if (UnityEngine.Random.Range(0, (int)(100 / BonusChance)) == 0)
            {
                float c3;
                do
                {
                    c3 = UnityEngine.Random.Range(-Border - 10, Border - 10);
                } while (Math.Abs(c3 - c1) <= DistanceLine);

                Dell.Add(Instantiate(Bonus[UnityEngine.Random.Range(0, Bonus.Count)],
                    new Vector2(c3, trans + OffPlayer + (i * DistanceCoral) + UnityEngine.Random.Range(0, YOff)),
                     Quaternion.Euler(new Vector2(0, vibar(0, 180)))));
            }
        }
        IntervalFromZero = Dell[Dell.Count - 1].transform.position.y - Player.transform.position.y + Interval;

        sistka();
    }

    public void spavn2(float trans)
    {
        int clasterV = (int)(Cluster / 3)+10;

        for (int i = 0; i < clasterV; i++)
        {
            float c1 = UnityEngine.Random.Range(-Border, Border);

            Dell.Add(Instantiate(Tentacles1[UnityEngine.Random.Range(0, Tentacles1.Count)],
                new Vector2(c1, trans + OffPlayer + (i * DistanceCoral)),
                 Quaternion.Euler(new Vector2(0, vibar(0, 180)))));

            float c2;
            do
            {
                c2 = UnityEngine.Random.Range(-Border * 2, Border * 2);
            } while (Math.Abs(c2 - c1) <= DistanceLine);

            Dell.Add(Instantiate(Tentacles1[UnityEngine.Random.Range(0, Tentacles1.Count)],
                new Vector2(c2, trans + OffPlayer + (i * DistanceCoral) + UnityEngine.Random.Range(0, YOff)),
                 Quaternion.Euler(new Vector2(0, vibar(0, 180)))));

            if (UnityEngine.Random.Range(0, (int)(100 / BonusChance)) == 0)
            {
                float c3;
                do
                {
                    c3 = UnityEngine.Random.Range(-Border - 10, Border - 10);
                } while (Math.Abs(c3 - c1) <= DistanceLine);

                Dell.Add(Instantiate(Bonus[UnityEngine.Random.Range(0, Bonus.Count)],
                    new Vector2(c3, trans + OffPlayer + (i * DistanceCoral) + UnityEngine.Random.Range(0, YOff)),
                     Quaternion.Euler(new Vector2(0, vibar(0, 180)))));
            }
        }


        for (int i = 0; i < clasterV; i++)
        {
            float T = 1;
            if (UnityEngine.Random.Range(0, 2) == 1)
                T *= 0;

            float granisa2 = Border - 30;

            Dell.Add(Instantiate(Tentacles2[UnityEngine.Random.Range(0, Tentacles2.Count)],
                new Vector2(granisa2 * 2 * T - granisa2, trans + OffPlayer + (i * DistanceShark) + (clasterV * DistanceCoral) +30 + UnityEngine.Random.Range(0, (int)(YOff / 3))),
                Quaternion.Euler(new Vector3(0, 0, 180 * (T - 1)))));
        }


        for (int i = 0; i < clasterV; i++)
        {
            float c1 = UnityEngine.Random.Range(-Border, Border);

            Dell.Add(Instantiate(Tentacles1[UnityEngine.Random.Range(0, Tentacles1.Count)],
                new Vector2(c1, trans + OffPlayer + 30 + ((i + clasterV) * DistanceCoral) + (clasterV * DistanceShark)),
                 Quaternion.Euler(new Vector2(0, vibar(0, 180)))));

            float c2;
            do
            {
                c2 = UnityEngine.Random.Range(-Border * 2, Border * 2);
            } while (Math.Abs(c2 - c1) <= DistanceLine);

            Dell.Add(Instantiate(Tentacles1[UnityEngine.Random.Range(0, Tentacles1.Count)],
                new Vector2(c2, trans + OffPlayer + ((i + clasterV) * DistanceCoral) + 30 + (clasterV * DistanceShark) + UnityEngine.Random.Range(0, YOff)),
                 Quaternion.Euler(new Vector2(0, vibar(0, 180)))));

            if (UnityEngine.Random.Range(0, (int)(100 / BonusChance)) == 0)
            {
                float c3;
                do
                {
                    c3 = UnityEngine.Random.Range(-Border - 10, Border - 10);
                } while (Math.Abs(c3 - c1) <= DistanceLine);

                Dell.Add(Instantiate(Bonus[UnityEngine.Random.Range(0, Bonus.Count)],
                    new Vector2(c3, trans + OffPlayer + (i * DistanceCoral) + UnityEngine.Random.Range(0, YOff)),
                    Quaternion.Euler(new Vector2(0, vibar(0, 180)))));
            }
        }

        xuina();
        IntervalFromZero = Dell[Dell.Count - 1].transform.position.y - Player.transform.position.y + Interval;
        sistka();
    }

    
    public void spavn3(float trans)
    {
        IntervalFromZero += 100;
        boos1 = boss[1].GetComponent<Boos1>();
        boos1.startt(Player.GetComponent<Transform>(), IntervalFromZero);
        boos1B = true;
    }

    public void spavn4(float trans)
    {
        float Poloz = UnityEngine.Random.Range(-Border * 50, Border * 50)/100;
        for (int i = 0; i < Cluster; i++)
        {
            Dell.Add(Instantiate(Ice[UnityEngine.Random.Range(0, Ice.Count)],
                    new Vector2(Poloz, trans + OffPlayer + (i * DistanceIce)),
                    Quaternion.Euler(new Vector2(vibar(0, 180), vibar(0, 180)))));
            Poloz += UnityEngine.Random.Range(-OffIce * 50, OffIce * 50) / 50f;
        }

        Cluster += 5;
        IntervalFromZero = Dell[Dell.Count - 1].transform.position.y - Player.transform.position.y + Interval;
    }

    public void respavn(float trans, bool w = true, int y = -100)
    {
        AdsCores.rec();
        if (boos1B)
        {
            Dell = boos1.delll();
            boos1B = false;
        }

        for (int i = 0; i < Dell.Count; i++)
        {
            Destroy(Dell[i]);
        }

        Dell = new List<GameObject>();

        if (y == -100)
            y = UnityEngine.Random.Range(0, 20);
        for (int i = 0; i < boss.Count; i++)
            boss[i].SetActive(false);
        if (anVolna != null)
            for (int i = 1; i <= 2; i++)
                anVolna.SetBool("biom" + i, false);
        CameraControler cami = cam.GetComponent<CameraControler>();

        cami.D = true;
        if(psF.activeInHierarchy)
            psm.startLifetime = 3.51f;

        if (F4B)
            spavnStandart(Distance, F4, OffPlayer, YOff, DistanceCoral, 0.5f, true);  // 0
        else if (y == 0)
        {
            tin = 1;
            boss[0].SetActive(true);
            spavn2(Distance); // kalmar
        }
        else if (y == 1)
        {
            tin = 2;
            boss[1].SetActive(true);
            spavn3(Distance); // boss 1
        }
        else if (y == 2)
        {
            tin = 3;
            spavnStandart(Distance, Boat, OffPlayer, YOff, DistanceCoral, BonusChance, new Vector3(vibar(0, 180), 0, 0)); // lodki
        }
        else if (y == 3)
        {
            tin = 4;
            anVolna.SetBool("biom1", true);
            boss[2].SetActive(true);
            spavn4(Distance); // lod
        }
        else if (y == 4)
        {
            tin = 5;
            anVolna.SetBool("biom2", true);
            spavnStandart(Distance, CoralSwamp, OffPlayer, YOff, DistanceCoral, BonusChance); // bolota
        }
        else if (y == 5)
        {
            tin = 6;
            if (UnityEngine.Random.Range(0, 2) == 1)
                anVolna.SetBool("biom2", true);
            boss[3].SetActive(true);
            spavnStandart(Distance, Shark, OffPlayer, YOff, DistanceShark, BonusChance, Vector3.zero, true, false); //acula
        }
        else if (y == 6)
        {
            tin = 7;
            if (psF.activeInHierarchy)
                psm.startLifetime = 7f;
            cami.D = false;
            spavnStandart(Distance, Coral3D, OffPlayer, YOff, DistanceCoral, BonusChance, new Vector3(0, 0, 0)); //Coral3D
            xuina2();
        }
        else
        {
            tin = 0;
            spavn1(Distance);
        }

        if (w)
            yvi(SpeedUpdate);
    }

    private void Start()
    {
        Distance = Player.transform.position.y;
        spavn1(0);
        ps = psF.GetComponent<ParticleSystem>();
        psm = ps.main;
        fps = fpsO.GetComponent<Text>();

        AndroidPlei.SetActive(Android);
        pausB.SetActive(Android);
        PleirControle = Player.GetComponent<PleirControler>();
        analtic = GetComponent<Analtic>();
        AdsCores = GetComponent<AdsCore>();
    }


    public void stopp()
    {
        if(Player != null)
        {
        stop = !stop;
        cameraCon.enabled = !stop;
        PleirControle.enabled = !stop;
        paus.SetActive(stop);
        for (int i = 0; i< pausStop.Count && Android; i++)
            pausStop[i].SetActive(stop);
        }
    }

    public void FPS()
    {fpsO.SetActive(!fpsO.activeInHierarchy);}

    public void FunctionF4()
    {
        F4B = !F4B;
        Distance = Player.transform.position.y;
        respavn(Distance);
        stop = true;
        stopp();
    }

    public void pp()
    {
        PPV.enabled = !PPV.enabled;
        PPL.enabled = !PPL.enabled;
        analtic.FooPP();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            stopp();
        

        if (Input.GetKeyDown(KeyCode.F5))
            reset();
        else if (Input.GetKeyDown(KeyCode.F4))
            FunctionF4();
        else if (Input.GetKeyDown(KeyCode.F11))
            FPS();
        else if (Input.GetKeyDown(KeyCode.F2))
            pp();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(Input.GetKeyDown(KeyCode.F9))
            {
                Cluster -= 3;
                respavn(Distance, false);
            }
            else if (Input.GetKeyDown(KeyCode.F10))
            {
                Cluster -= 3;
                Distance = Player.transform.position.y;
                respavn(Distance, false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1)){Cluster -= 3; respavn(Distance, false, 0);
            }else if (Input.GetKeyDown(KeyCode.Alpha2)){Cluster -= 3; respavn(Distance, false, 1);
            }else if (Input.GetKeyDown(KeyCode.Alpha3)){Cluster -= 3; respavn(Distance, false, 2);
            }else if (Input.GetKeyDown(KeyCode.Alpha4)){Cluster -= 3; respavn(Distance, false, 3);
            }else if (Input.GetKeyDown(KeyCode.Alpha5)){Cluster -= 3; respavn(Distance, false, 4);
            }else if (Input.GetKeyDown(KeyCode.Alpha6)){Cluster -= 3; respavn(Distance, false, 5);
            }else if (Input.GetKeyDown(KeyCode.Alpha7)){Cluster -= 3; respavn(Distance, false, 6);
            }else if (Input.GetKeyDown(KeyCode.Alpha8)){Cluster -= 3; respavn(Distance, false, 7);
            }else if (Input.GetKeyDown(KeyCode.Alpha9)){Cluster -= 3; respavn(Distance, false, 8);
            }else if (Input.GetKeyDown(KeyCode.Alpha0)){Cluster -= 3; respavn(Distance, false, 9); }
        }

        if ((1f / Time.unscaledDeltaTime) < 10)
            psF.SetActive(false);
        else if ((1f / Time.unscaledDeltaTime) > 60)
            psF.SetActive(true);

        if (fpsO.activeInHierarchy)
            fps.text = ((int)(1f / Time.unscaledDeltaTime)).ToString();
    }

    void FixedUpdate()
    {
        if (Player != null)
        {
            textt2.text = ((((int)Player.transform.position.y / 5))>0?
                ((int)Player.transform.position.y / 5):0
                ).ToString();
            if (Distance + IntervalFromZero <= Player.transform.position.y)
            {
                Distance = Player.transform.position.y;
                respavn(Distance);

            }
        }
    }
}
