using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class SDK : MonoBehaviour
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOsGameId;
    [SerializeField] bool _testMode = true;
    [SerializeField] bool _enablePerPlacementMode = true;
    private string _gameId;

    public UnityEvent OnAdsReady;

    void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameId=(Application.platform==RuntimePlatform.IPhonePlayer)
            ? _iOsGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, _enablePerPlacementMode);
    }


}