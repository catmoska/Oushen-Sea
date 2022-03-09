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
        stop = GetComponent<SpawnCoral>();
        Advertisement.Initialize(_gameId, _testMode);
        StartCoroutine(adsss());
    }

    public IEnumerator adsss() 
    {
        yield return new WaitForSeconds(1);
        stop.stopp();
        Advertisement.Show("Interstitial_Android");
    }
}

