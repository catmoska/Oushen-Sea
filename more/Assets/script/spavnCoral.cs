using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using System;

public class spavnCoral : MonoBehaviour
{
    public List<GameObject> coral;
    public List<GameObject> coral3D;
    public List<GameObject> coralBooloto;
    public List<GameObject> supalsa1;
    public List<GameObject> supalsa2;
    public List<GameObject> faerBoll;
    public List<GameObject> lodka;
    public List<GameObject> lod;
    public List<GameObject> acul;
    public List<GameObject> plus;
    public List<GameObject> ut;
    public List<GameObject> boos;
    public GameObject pleir;
    public float granisa = 65;
    public float smemeniaPleir = 80;
    public float rasto = 10;
    public float rastoLin = 10;
    public float rastoCaral = 10;
    public float rastoSupols = 10;
    public float rastoLdom = 10;
    public float rastoAcul = 10;
    public float smemeniaLdom = 10;
    public float nrosentPlus = 5;
    public float ySmesenia = 3;
    public float speedUPDEIT = 5;
    public List<GameObject> dell;
    private float o = 30;
    public float smes = 30;
    public float RaznesaSUPS = 2;

    public int claster = 30;
    public bool utT;
    public bool andeoid;
    public GameObject andeoidPlei;

    public PleirControler PleirControl;
    public cameraControler cameraCon;
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
    private boos1 boos1;
    private bool boos1B;
    public PostProcessVolume ppV;
    public PostProcessLayer ppL;
    private ParticleSystem.MainModule psm;



    public void reset()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Res2() { StartCoroutine(Res3()); }
    public IEnumerator Res3()
    {
        textt.text = ((int)pleir.transform.position.y / 5).ToString();
        textt2G.SetActive(false);
        Destroy(pleir);
        yield return new WaitForSeconds(1);
        andeoidPlei.SetActive(false);
        buton.SetActive(true);
    }

    public void yvi(float i) { StartCoroutine(yviN(i)); spidEfect(i); }
    private IEnumerator yviN(float u)
    {
        float y = u / 10;
        for (int i = 0; i < 10; i++)
        {
            PleirControler.speedUP += y;
            PleirControler.speed += y / RaznesaSUPS;
            yield return new WaitForSeconds(0.5f);
        }
    }

    void spidEfect(float spid)
    {psm.startSpeed = PleirControler.speed+spid+10;}


    void sistka()
    {
        for (int i = 0; i < dell.Count; i++)
        {
            if (Math.Abs(dell[i].transform.position.x) >= granisa + 10)
            {
                Destroy(dell[i]);
            }
        }
        claster += 5;
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
        for (int i = 0; i < dell.Count; i++)
        {
            if (dell[i].tag != "plus")
            {
                supolso s = dell[i].GetComponent<supolso>();
                if (s!=null)
                    s.pleir = pleir.GetComponent<Transform>();
                else
                {
                    Debug.LogError("����� �� ����� ������� ������ 'spavnCoral/xuina()'");
                }
            }
        }
    }

    void xuina2()
    {
        for (int i = 0; i < dell.Count; i++)
        {
            if (dell[i].tag != "plus")
            {
                Render3D s = dell[i].GetComponent<Render3D>();
                s.cam = cam.GetComponent<Transform>();
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


        for (int i = 0; i < claster; i++)
        {
            float c1 = UnityEngine.Random.Range(-granisa, granisa);

            dell.Add(Instantiate(standart[UnityEngine.Random.Range(0, standart.Count)],
                new Vector2(c1, trans + smemenia + (i * rasto)),
                Quaternion.Euler(new Vector3(0, vibar(0, 180), 0)+nova)));

            if (dablSpavn)
            {
                float c2;
                do
                {
                    c2 = UnityEngine.Random.Range(-granisa * 2, granisa * 2);
                } while (Math.Abs(c2 - c1) <= rastoLin);

                dell.Add(Instantiate(standart[UnityEngine.Random.Range(0, standart.Count)],
                    new Vector2(c2, trans + smemenia + (i * rasto) + UnityEngine.Random.Range(0, ySme)),
                    Quaternion.Euler(new Vector3(0, vibar(0, 180), 0) + nova)));
            }

            if (UnityEngine.Random.Range(0, (int)(100 / bonus)) == 0)
            {
                float c3;
                do
                {
                    c3 = UnityEngine.Random.Range(-granisa - 10, granisa - 10);
                } while (Math.Abs(c3 - c1) <= rastoLin);

                dell.Add(Instantiate(plus[UnityEngine.Random.Range(0, plus.Count)],
                    new Vector2(c3, trans + smemenia + (i * rasto) + UnityEngine.Random.Range(0, ySme)),
                     Quaternion.Euler(new Vector3(0, vibar(0, 180), 0) + nova)));
            }
        }
        o = dell[dell.Count - 1].transform.position.y - pleir.transform.position.y + smes;

        if (xuin)
            xuina();

        sistka();
    }

    public void spavn1(float trans)
    {
        for (int i = 0; i < claster; i++)
        {
            float c1 = UnityEngine.Random.Range(-granisa, granisa);

            dell.Add(Instantiate(coral[UnityEngine.Random.Range(0, coral.Count)],
                new Vector2(c1, trans + smemeniaPleir + (i * rastoCaral)),
                Quaternion.Euler(new Vector2(0, vibar(0, 180)))));

            float c2;
            do
            {
                c2 = UnityEngine.Random.Range(-granisa * 2, granisa * 2);
            } while (Math.Abs(c2 - c1) <= rastoLin);

            dell.Add(Instantiate(coral[UnityEngine.Random.Range(0, coral.Count)],
                new Vector2(c2, trans + smemeniaPleir + (i * rastoCaral) + UnityEngine.Random.Range(0, ySmesenia)),
                Quaternion.Euler(new Vector2(0, vibar(0, 180)))));

            if (UnityEngine.Random.Range(0, (int)(100 / nrosentPlus)) == 0)
            {
                float c3;
                do
                {
                    c3 = UnityEngine.Random.Range(-granisa-10, granisa-10);
                } while (Math.Abs(c3 - c1) <= rastoLin);

                dell.Add(Instantiate(plus[UnityEngine.Random.Range(0, plus.Count)],
                    new Vector2(c3, trans + smemeniaPleir + (i * rastoCaral) + UnityEngine.Random.Range(0, ySmesenia)),
                     Quaternion.Euler(new Vector2(0, vibar(0, 180)))));
            }
        }
        o = dell[dell.Count - 1].transform.position.y - pleir.transform.position.y + smes;

        sistka();
    }

    public void spavn2(float trans)
    {
        int clasterV = (int)(claster / 3)+10;

        for (int i = 0; i < clasterV; i++)
        {
            float c1 = UnityEngine.Random.Range(-granisa, granisa);

            dell.Add(Instantiate(supalsa1[UnityEngine.Random.Range(0, supalsa1.Count)],
                new Vector2(c1, trans + smemeniaPleir + (i * rastoCaral)),
                 Quaternion.Euler(new Vector2(0, vibar(0, 180)))));

            float c2;
            do
            {
                c2 = UnityEngine.Random.Range(-granisa * 2, granisa * 2);
            } while (Math.Abs(c2 - c1) <= rastoLin);

            dell.Add(Instantiate(supalsa1[UnityEngine.Random.Range(0, supalsa1.Count)],
                new Vector2(c2, trans + smemeniaPleir + (i * rastoCaral) + UnityEngine.Random.Range(0, ySmesenia)),
                 Quaternion.Euler(new Vector2(0, vibar(0, 180)))));

            if (UnityEngine.Random.Range(0, (int)(100 / nrosentPlus)) == 0)
            {
                float c3;
                do
                {
                    c3 = UnityEngine.Random.Range(-granisa - 10, granisa - 10);
                } while (Math.Abs(c3 - c1) <= rastoLin);

                dell.Add(Instantiate(plus[UnityEngine.Random.Range(0, plus.Count)],
                    new Vector2(c3, trans + smemeniaPleir + (i * rastoCaral) + UnityEngine.Random.Range(0, ySmesenia)),
                     Quaternion.Euler(new Vector2(0, vibar(0, 180)))));
            }
        }


        for (int i = 0; i < clasterV; i++)
        {
            float T = 1;
            if (UnityEngine.Random.Range(0, 2) == 1)
                T *= 0;

            float granisa2 = granisa - 30;

            dell.Add(Instantiate(supalsa2[UnityEngine.Random.Range(0, supalsa2.Count)],
                new Vector2(granisa2 * 2 * T - granisa2, trans + smemeniaPleir + (i * rastoSupols) + (clasterV * rastoCaral)+30 + UnityEngine.Random.Range(0, (int)(ySmesenia / 3))),
                Quaternion.Euler(new Vector3(0, 0, 180 * (T - 1)))));
        }


        for (int i = 0; i < clasterV; i++)
        {
            float c1 = UnityEngine.Random.Range(-granisa, granisa);

            dell.Add(Instantiate(supalsa1[UnityEngine.Random.Range(0, supalsa1.Count)],
                new Vector2(c1, trans + smemeniaPleir + 30 + ((i + clasterV) * rastoCaral) + (clasterV * rastoSupols)),
                 Quaternion.Euler(new Vector2(0, vibar(0, 180)))));

            float c2;
            do
            {
                c2 = UnityEngine.Random.Range(-granisa * 2, granisa * 2);
            } while (Math.Abs(c2 - c1) <= rastoLin);

            dell.Add(Instantiate(supalsa1[UnityEngine.Random.Range(0, supalsa1.Count)],
                new Vector2(c2, trans + smemeniaPleir + ((i + clasterV) * rastoCaral) + 30 + (clasterV * rastoSupols) + UnityEngine.Random.Range(0, ySmesenia)),
                 Quaternion.Euler(new Vector2(0, vibar(0, 180)))));

            if (UnityEngine.Random.Range(0, (int)(100 / nrosentPlus)) == 0)
            {
                float c3;
                do
                {
                    c3 = UnityEngine.Random.Range(-granisa - 10, granisa - 10);
                } while (Math.Abs(c3 - c1) <= rastoLin);

                dell.Add(Instantiate(plus[UnityEngine.Random.Range(0, plus.Count)],
                    new Vector2(c3, trans + smemeniaPleir + (i * rastoCaral) + UnityEngine.Random.Range(0, ySmesenia)),
                    Quaternion.Euler(new Vector2(0, vibar(0, 180)))));
            }
        }

        xuina();
        o = dell[dell.Count - 1].transform.position.y - pleir.transform.position.y + smes;
        sistka();
    }

    
    public void spavn3(float trans)
    {
        o += 100;
        boos1 = boos[1].GetComponent<boos1>();
        boos1.startt(pleir.GetComponent<Transform>(),o);
        boos1B = true;
    }

    public void spavn4(float trans)
    {
        float Poloz = UnityEngine.Random.Range(-granisa*50, granisa*50)/100;
        for (int i = 0; i < claster; i++)
        {
            dell.Add(Instantiate(lod[UnityEngine.Random.Range(0, lod.Count)],
                    new Vector2(Poloz, trans + smemeniaPleir + (i * rastoLdom)),
                    Quaternion.Euler(new Vector2(vibar(0, 180), vibar(0, 180)))));
            Poloz += UnityEngine.Random.Range(-smemeniaLdom * 50, smemeniaLdom * 50) / 50;
        }

        claster += 5;
        o = dell[dell.Count - 1].transform.position.y - pleir.transform.position.y + smes;
    }

    public void respavn(float trans, bool w = true, int y = -100)
    {
        if (boos1B)
        {
            dell = boos1.delll();
            boos1B = false;
        }

        for (int i = 0; i < dell.Count; i++)
        {
            Destroy(dell[i]);
        }

        dell = new List<GameObject>();

        if (y == -100)
            y = UnityEngine.Random.Range(0, 20);
        for (int i = 0; i < boos.Count; i++)
            boos[i].SetActive(false);
        if (anVolna != null)
            for (int i = 1; i <= 2; i++)
                anVolna.SetBool("biom" + i, false);
        cameraControler cami = cam.GetComponent<cameraControler>();

        cami.D = true;
        psm.startLifetime = 3.51f;

        if (utT) 
            spavnStandart(rasto, ut, smemeniaPleir, ySmesenia, rastoCaral,0.5f,true);  // 0
        else if (y == 0)
        {
            boos[0].SetActive(true);
            spavn2(rasto); // kalmar
        }
        else if (y == 1)
        {
            boos[1].SetActive(true);
            spavn3(rasto); // boss 1
        }
        else if (y == 2)
            spavnStandart(rasto, lodka, smemeniaPleir, ySmesenia, rastoCaral, nrosentPlus, new Vector3(vibar(0,180),0,0)); // lodki
        else if (y == 3)
        {
            anVolna.SetBool("biom1", true);
            boos[2].SetActive(true);
            spavn4(rasto); // lod
        }
        else if (y == 4)
        {
            anVolna.SetBool("biom2", true);
            spavnStandart(rasto, coralBooloto, smemeniaPleir, ySmesenia, rastoCaral, nrosentPlus); // bolota
        }
        else if (y == 5)
        {
            if (UnityEngine.Random.Range(0, 2) == 1)
                anVolna.SetBool("biom2", true);
            boos[3].SetActive(true);
            spavnStandart(rasto, acul, smemeniaPleir, ySmesenia, rastoAcul, nrosentPlus, Vector3.zero, true, false); //acula
        }
        else if (y == 6)
        {
            psm.startLifetime = 7f;
            cami.D = false;
            spavnStandart(rasto, coral3D, smemeniaPleir, ySmesenia, rastoCaral, nrosentPlus,new Vector3(0, 0, 0)); //3d
            xuina2();
        }
        else
            spavn1(rasto);
        

        if (w)
            yvi(speedUPDEIT);
    }

    private void Start()
    {
        rasto = pleir.transform.position.y;
        spavn1(0);
        ps = psF.GetComponent<ParticleSystem>();
        fps = fpsO.GetComponent<Text>();

        andeoidPlei.SetActive(andeoid);
        pausB.SetActive(andeoid);
        psm = ps.main;
    }

    public void stopp()
    {
        if(pleir != null)
        {
        stop = !stop;
        cameraCon.enabled = !stop;
        PleirControl.enabled = !stop;
        paus.SetActive(stop);
        for (int i = 0; i< pausStop.Count && andeoid; i++)
            pausStop[i].SetActive(stop);
        }
    }

    public void FPS()
    {fpsO.SetActive(!fpsO.activeInHierarchy);}

    public void F4()
    {
        utT = !utT;
        rasto = pleir.transform.position.y;
        respavn(rasto);
        stop = true;
        stopp();
    }

    public void pp()
    {
        ppV.enabled = !ppV.enabled;
        ppL.enabled = !ppL.enabled;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            stopp();
        

        if (Input.GetKeyDown(KeyCode.F5))
            reset();
        else if (Input.GetKeyDown(KeyCode.F4))
            F4();
        else if (Input.GetKeyDown(KeyCode.F11))
            FPS();
        else if (Input.GetKeyDown(KeyCode.F2))
            pp();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(Input.GetKeyDown(KeyCode.F9))
            {
                claster -= 3;
                respavn(rasto, false);
            }
            else if (Input.GetKeyDown(KeyCode.F10))
            {
                claster -= 3;
                rasto = pleir.transform.position.y;
                respavn(rasto, false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1)){claster -= 3; respavn(rasto, false, 0);
            }else if (Input.GetKeyDown(KeyCode.Alpha2)){claster -= 3; respavn(rasto, false, 1);
            }else if (Input.GetKeyDown(KeyCode.Alpha3)){claster -= 3; respavn(rasto, false, 2);
            }else if (Input.GetKeyDown(KeyCode.Alpha4)){claster -= 3; respavn(rasto, false, 3);
            }else if (Input.GetKeyDown(KeyCode.Alpha5)){claster -= 3; respavn(rasto, false, 4);
            }else if (Input.GetKeyDown(KeyCode.Alpha6)){claster -= 3; respavn(rasto, false, 5);
            }else if (Input.GetKeyDown(KeyCode.Alpha7)){claster -= 3; respavn(rasto, false, 6);
            }else if (Input.GetKeyDown(KeyCode.Alpha8)){claster -= 3; respavn(rasto, false, 7);
            }else if (Input.GetKeyDown(KeyCode.Alpha9)){claster -= 3; respavn(rasto, false, 8);
            }else if (Input.GetKeyDown(KeyCode.Alpha0)){claster -= 3; respavn(rasto, false, 9); }
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
        if (pleir != null)
        {
            textt2.text = ((int)pleir.transform.position.y / 5).ToString();
            if (rasto + o <= pleir.transform.position.y)
            {
                rasto = pleir.transform.position.y;
                respavn(rasto);

            }
        }
    }
}
