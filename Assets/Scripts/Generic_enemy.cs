using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generic_enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject deathSR;
    public float speed;
    public float angle;
    public bool isAlive = true;
    public float inner_radius;
    public GameObject bullet;
    public gameManager gm;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void onDataSet()
    {

    }

    public virtual void spawnBullet()
    {

    }

    /*
    * Create an explosion and handle other onDestroy goals
    * */
    private void OnDestroy()
    {
        if (!isAlive)
        {
            // Instantiate an explosion of particles of the desired color
            Instantiate(deathSR, transform.position, transform.rotation);
            gm.incrementPlayerKill();
        }
    }
}
