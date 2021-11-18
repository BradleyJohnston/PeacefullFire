using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************************
 * This script is for prototyping, and understanding the full needs
 * of an enemy. It is likely going to be edited into a more generic
 * script for enemies, however at the moment it is specific to the
 * RUSHER enemy class.
 ****************************************/
public class Rush_enemy : Generic_enemy
{

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (new Vector2(-rb.position.x, -rb.position.y)).normalized * speed;
    }




}
