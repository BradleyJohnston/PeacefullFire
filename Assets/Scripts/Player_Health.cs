using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float health = 1f;
    public gameManager gm;
    public ParticleSystem ps;
    public SpriteRenderer sr;
    public GameObject shield;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Health"))
        {
            health = PlayerPrefs.GetInt("Health");
        }
        else
        {
            PlayerPrefs.SetInt("Health", 0);
        }


        if (PlayerPrefs.HasKey("Shield"))
        {
            shield.SetActive(PlayerPrefs.GetInt("Shield") > 0);
        }
        else
        {
            shield.SetActive(false);
        }

        // make sure that health is greater than 0
        health = (health > 0 ? health : 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("onTriggerEnter");
        Damage damage = collision.gameObject.GetComponent<Damage>();
        health -= damage.damage;

        if (damage != null)
        {
            health -= damage.damage;
            
            Generic_enemy enemy = damage.gameObject.GetComponent<Generic_enemy>();

            if (enemy != null)
            {
                enemy.isAlive = false;
            }

            Destroy(damage.gameObject);

            if (health <= 0)
            {
                // Send signal to game manager
                gm.onPlayerDeath();

                // Destroy this game object
                ps.Stop();
                Destroy(sr.gameObject);

                // Destroy Shield
                Destroy(shield.gameObject);
            }
        }


    }
}
