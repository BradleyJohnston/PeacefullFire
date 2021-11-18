using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetPointsShop : MonoBehaviour
{
    public TMP_Text pointText;
    private int lastPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("points"))
        {
            lastPoint = PlayerPrefs.GetInt("points");
            pointText.text = lastPoint.ToString();
        }
        else
        {
            lastPoint = 0;
            pointText.text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("points") != lastPoint)
        {
            lastPoint = PlayerPrefs.GetInt("points");
            pointText.text = lastPoint.ToString();
        }
    }
}
