using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shopUpgradeBasicHandler : MonoBehaviour
{

    public TMP_Text UpgradeTitle;
    public TMP_Text ButtonText;
    public TMP_Text PointsText;
    private int CurrentPoints;
    private int MaxPoints;
    private int startingCost;
    private float scalingCost;
    private string PreferenceKey;
    private int playerPoints;

    public int getCurrentCost()
    {
        return startingCost * (int)Mathf.Pow(scalingCost, CurrentPoints);
    }

    public void setPointText()
    {
        PointsText.text = CurrentPoints.ToString() + "/" + MaxPoints.ToString();
    }

    public void FillValues(string title, string button, int maximum, string key, int starting, float scaling)
    {
        // Set variables from parameters
        UpgradeTitle.text = title;
        MaxPoints = maximum;
        PreferenceKey = key;
        startingCost = starting;
        scalingCost = scaling;


        // Infer variables from what we now have
        if (PlayerPrefs.HasKey(PreferenceKey))
        {
            CurrentPoints = PlayerPrefs.GetInt(PreferenceKey);
        }
        else
        {
            CurrentPoints = 0;
            PlayerPrefs.SetInt(key, 0);
        }


        ButtonText.text = getCurrentCost().ToString();

        setPointText();
    }

    public void onButtonClick()
    {
        Debug.Log("Hit the buy button for " + UpgradeTitle);
        playerPoints = PlayerPrefs.GetInt("points");


        if (playerPoints <= getCurrentCost() || CurrentPoints > MaxPoints)
        {
            Debug.Log("You can't do that honey");
            return;
        }

        if (playerPoints > getCurrentCost())
        {
            PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points") - getCurrentCost());
            Debug.Log("Increase Score");
            // do something for the button.
            CurrentPoints += 1;
            PlayerPrefs.SetInt(PreferenceKey, CurrentPoints);
            setPointText();
            ButtonText.text = getCurrentCost().ToString();
        }
    }
}
