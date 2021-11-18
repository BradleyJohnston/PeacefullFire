using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    private int adCount = 0;
    public int roundsPerAd;

    private string gameID = "4070257";
    public bool testMode = true;

    private void Start()
    {
        Advertisement.Initialize(gameID, testMode);
    }

    public void DisplayAd()
    {
        if (adCount % roundsPerAd == 0)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show("video");
            }
            else
            {
                Debug.LogError("Advertisement not shown");
            }
        }

        adCount += 1;
    }
}
