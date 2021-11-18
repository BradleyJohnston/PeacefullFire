using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_End : MonoBehaviour
{
    public ParticleSystem ps;

    // Update is called once per frame
    void Update()
    {
        // This code tests to see if the particle system
        // has stopped playing, if so then clean up the
        // gameobject.
        if (!ps.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
