using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit something");
        Generic_enemy enemy = collision.gameObject.GetComponent<Generic_enemy>();
        if (enemy != null)
        {
            enemy.isAlive = false;

            Destroy(enemy.gameObject);
        }
    }
}
