using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Basic Upgrade", menuName = "Basic Upgrade")]
public class BasicUpgradeScriptable : ScriptableObject
{
    public string UpgradeTitle;
    public string ButtonText = "Buy";
    public string PreferenceKey;
    public float scalingCost;
    public int startingCost;
    public int MaxPoints;
}
