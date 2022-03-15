using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsCore : MonoBehaviour
{
    [SerializeField] private bool _testMode = true;
    private string _gameId = "4650473";
    private SpawnCoral stop;

    void Start()
    {
        Advertisement.Initialize(_gameId, _testMode);
        stop = GetComponent<SpawnCoral>();
        if (Random.Range(0, 5)==1) 
            StartCoroutine(adsss());
    }

    public IEnumerator adsss() 
    {
        yield return new WaitForSeconds(2f);
        stop.stopp();
        Advertisement.Show("Interstitial_Android");
    }

    public void rec()
    {
        if (Random.Range(0, 3) == 1)
        {
            stop.stopp();
            Advertisement.Show("Interstitial_Android");
        }
    }
}

