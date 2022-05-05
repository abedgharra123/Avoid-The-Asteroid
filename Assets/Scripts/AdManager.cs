using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool testMode = false;
    private GameOverHandler gameOverHandler;

#if UNITY_ANDROID
    private string gameId = "4278018";
#elif UNITY_IOS
    private string gameId = "4278019";
#endif
    public static AdManager instance;

    public void Awake(){
        if(instance != null && instance != this){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId,testMode);
        }
    }

    public void ShowAd(GameOverHandler g){
        gameOverHandler = g;
        Advertisement.Show("skippableVideo");

    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Error");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult){
            case ShowResult.Failed:
                Debug.LogWarning("Failed to finish the Ad");
            break;
            case ShowResult.Finished:
                gameOverHandler.ContinueGame();
            break;
            case ShowResult.Skipped:
                gameOverHandler.ContinueGame();
            break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Started");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ad is Ready");
    }
}
