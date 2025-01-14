using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener,IUnityAdsLoadListener,IUnityAdsShowListener
{

    public static AdManager instance;
    public string androidID, appleID;
    public bool testMode = true;

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization completed successfully.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show("Interstitial_Android", this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"Ad {placementId} finished showing with state: {showCompletionState.ToString()}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log($"Ad {placementId} started showing.");
    }


    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!Advertisement.isInitialized)
        {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_ANDROID
            Advertisement.Initialize(androidID, testMode, this);
#elif UNITY_IOS
            Advertisement.Initialize(appleID, testMode, this);
#endif
        }
    }

    public void ShowAd()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load("Interstitial_Android", this);
        }
    }


}
