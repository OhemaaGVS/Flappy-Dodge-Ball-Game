
using UnityEngine.Advertisements;
using UnityEngine;
using UnityEngine.UI;

public class AddManager : MonoBehaviour, IUnityAdsListener
{
    // Start is called before the first frame update


    private bool RewardedAlready = false;
    private string playstoreID = "3784405";
    
    public delegate void AddDelegate();
    public static event AddDelegate RewardPlayer;
    private string normalAd = "video";
    private string rewardedAd = "rewardedVideo";
    public Sprite WatchedAd;
    public Sprite NotWatchedAd;
    public Sprite NoAd;
    public bool isTargetPlaystore;
    public bool isTestAd;


    private void update()
{
    if (!Advertisement.IsReady(rewardedAd))
    {
        var Button = GameObject.Find("WatchAdButton").GetComponent<Image>();
        Button.sprite = NoAd;
        //return;
    }

    if (Advertisement.IsReady(rewardedAd)==true)
    {
        var Button = GameObject.Find("WatchAdButton").GetComponent<Image>();
        Button.sprite = NotWatchedAd;
        //return;
    }

}

    private void Start()
    {
       // var Button = GameObject.Find("WatchAdButton").GetComponent<Image>();
       // Button.sprite = NotWatchedAd;
        RewardedAlready = false;
        Advertisement.AddListener(this);
        IntializeAd();
    }

    private void IntializeAd()
    {
        if (isTargetPlaystore) { Advertisement.Initialize(playstoreID, isTestAd); return; }


    }

    public void PlayNormalAd()
    {
        if (!Advertisement.IsReady(normalAd))
        {
            return;
        }
        Advertisement.Show(normalAd);

    }

    public void PlayRewardAd()
    {
        if (!Advertisement.IsReady(rewardedAd))
        {
            var Button = GameObject.Find("WatchAdButton").GetComponent<Image>();
            Button.sprite = NoAd;
            return; // nov 6th
        }
        //if (RewardedAlready == false)
        //{
        //    Advertisement.Show(rewardedAd);
        //    RewardedAlready = true;
            
        //}
        else if (Advertisement.IsReady(rewardedAd) == true & Bird.GetBirdInstance().GetBirdStars() != 5)
        {
            var Button = GameObject.Find("WatchAdButton").GetComponent<Image>();
            Button.sprite = NotWatchedAd;
            Advertisement.Show(rewardedAd);// nov 6th
            //return;
        }

        // nov 6th
       // if (Bird.GetBirdInstance().GetBirdStars() != 5 & Advertisement.IsReady(rewardedAd)==true)
       // {
            //Advertisement.Show(rewardedAd);
        //}
    }




    public void OnUnityAdsReady(string placementId)
    {//
        //  throw new System.NotImplementedException();

    }
    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();

    }
    public void OnUnityAdsDidStart(string placementId)
    {
        //  throw new System.NotImplementedException();

    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //hrow new System.NotImplementedException();

        switch (showResult)
        {
            case ShowResult.Failed:
               // Debug.Log("error");
                break;
            case ShowResult.Skipped:
               // Debug.Log("no reward");
                break;
            case ShowResult.Finished:
                if (placementId == rewardedAd && Bird.GetBirdInstance().GetBirdStars() !=5)
                {
                    //Debug.Log("you have been rewarded");
                    RewardPlayer();


                    //var Button = GameObject.Find("WatchAdButton").GetComponent<Image>();
                    //Button.sprite = WatchedAd;

                }
                if (placementId == rewardedAd && Bird.GetBirdInstance().GetBirdStars() == 5)
                {
                    //Debug.Log("ok");
                    var Button = GameObject.Find("WatchAdButton").GetComponent<Image>();
                    Button.sprite = WatchedAd;
                }
                break;



        }
        
    }

    private void OnEnable()
    {
        Bird.ShowNormalAd += ShowNormalAd;
        GameEventHandler.GameReStarted += GameReStarted;
      

    }





    private void OnDisable()
    {
        Bird.ShowNormalAd -= ShowNormalAd;
        GameEventHandler.GameReStarted -= GameReStarted;
        
    }



    private  void GameReStarted()
    {

        if (Bird.GetBirdInstance().GetBirdStars() == 5)
        {
            //Debug.Log("ok");
            var Button = GameObject.Find("WatchAdButton").GetComponent<Image>();
            Button.sprite = WatchedAd;
        }
        if (Bird.GetBirdInstance().GetBirdStars() < 5)
        {
            var Button = GameObject.Find("WatchAdButton").GetComponent<Image>();
            Button.sprite = NotWatchedAd;
            // RewardedAlready = false;
        }
        if (!Advertisement.IsReady(rewardedAd))
        {
            var Button = GameObject.Find("WatchAdButton").GetComponent<Image>();
            Button.sprite = NoAd;
            return;
        }
    }


    private void ShowNormalAd()
    {

        PlayNormalAd();
    }
}
