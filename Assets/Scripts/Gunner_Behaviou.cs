using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner_Behaviou : Generic_enemy
{
    private bool hasHitInnerCircle = false;
    private Vector2 innerCirclePoint;
    public float shootChance = .001f;

    public override void onDataSet()
    {
        rb = GetComponent<Rigidbody2D>();
        innerCirclePoint = TrigCalculations.getTangentLineIntersect(angle, rb.position.magnitude, inner_radius);
        inner_radius = innerCirclePoint.magnitude + .01f;
        angle *= Mathf.Rad2Deg;
        angle -= 65;
        rb.velocity = (innerCirclePoint - rb.position).normalized * speed;
    }



    private void Update()
    {


        if (hasHitInnerCircle)
        {
            float angleToSubtract = TrigCalculations.speedToAngleRotation(inner_radius, speed);
            angle -= angleToSubtract;
            if (angle <= 0)
            {
                angle += 360;
            }
            rb.position = TrigCalculations.getPointOnRadius(angle * Mathf.Deg2Rad, inner_radius);

            if (Random.RandomRange(0, 1f) <= shootChance)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
        }

        if (rb.position.magnitude <= inner_radius && !hasHitInnerCircle)
        {

            hasHitInnerCircle = true;
        }
    }
}
