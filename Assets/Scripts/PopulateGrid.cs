using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateGrid : MonoBehaviour
{
    public BasicUpgradeScriptable[] upgrades;
    public GameObject bUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //https://www.studica.com/blog/unity-ui-tutorial-scroll-grid
    private void Populate()
    {
        GameObject newObject;
        foreach (BasicUpgradeScriptable item in upgrades)
        {
            newObject = Instantiate(bUpgrade, transform);
            shopUpgradeBasicHandler handler = newObject.GetComponent<shopUpgradeBasicHandler>();

            newObject.name = item.name;
            if (item.name != "Empty")
            {
                handler.FillValues(item.UpgradeTitle, item.ButtonText, item.MaxPoints, item.PreferenceKey, item.startingCost, item.scalingCost);
            }
            else
            {
                foreach (RectTransform element in newObject.GetComponentInChildren<RectTransform>())
                {
                    Destroy(element.gameObject);
                }
            }
        }
    }
}
