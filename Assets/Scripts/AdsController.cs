using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsController : MonoBehaviour
{
    [SerializeField] private bool testMode = true;
    [SerializeField] private string gameId = "4790669";

    [SerializeField] private string missVideo = "Interstitial_Android";
    [SerializeField] private string fullVideo = "Rewarded_Android";
    [SerializeField] private string banner = "Banner_Android";

    private void Start()
    {
        StartCoroutine(CreateBanner());
        Advertisement.Initialize(gameId, testMode);
    }

    private IEnumerator CreateBanner(float waitTime = 1f)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(banner);
    }

    /// <param name="adID">1 - "Interstitial_Android"; 2 - "Rewarded_Android"</param>
    public void ShowAd(int adID = 1)
    {
        Advertisement.Show(adID == 1 ? missVideo : fullVideo);
    }

    private void OnDestroy()
    {
        Advertisement.Banner.Hide();
    }
}