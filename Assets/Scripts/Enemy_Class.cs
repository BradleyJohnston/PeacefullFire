using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New enemy class", menuName = "Enemy Class")]
public class Enemy_Class : ScriptableObject
{
    public float innerRadius;
    public float speed;

    public GameObject mainPartSys;
    public GameObject deathPartSys;

    public GameObject bullet = null;
}
