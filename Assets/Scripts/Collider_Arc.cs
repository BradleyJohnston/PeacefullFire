using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Arc : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage damage = collision.gameObject.GetComponent<Damage>();

        if (damage != null)
        {
            Generic_enemy enemy = damage.gameObject.GetComponent<Generic_enemy>();

            if (enemy != null)
            {
                enemy.isAlive = false;
            }
                
            Destroy(damage.gameObject);
        }
    }
}
