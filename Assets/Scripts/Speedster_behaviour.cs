using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedster_behaviour : Generic_enemy
{
    private bool hasHitInnerCircle = false;
    private Vector2 innerCirclePoint;
    private bool hasCircumnavigatedCircle = false;
    private float endAngle;

    public override void onDataSet()
    {
        rb = GetComponent<Rigidbody2D>();
        innerCirclePoint = TrigCalculations.getTangentLineIntersect(angle, rb.position.magnitude, inner_radius);
        inner_radius = innerCirclePoint.magnitude + .01f;
        angle *= Mathf.Rad2Deg;
        angle -= 68;
        endAngle = angle - 360;
        
        rb.velocity = (innerCirclePoint - rb.position).normalized * speed;
        
    }

    private void Update()
    {
        if (hasHitInnerCircle)
        {
            float angleToSubtract = TrigCalculations.speedToAngleRotation(inner_radius, speed);
            angle -= angleToSubtract;
            rb.position = TrigCalculations.getPointOnRadius(angle * Mathf.Deg2Rad, inner_radius);
        }

        if (hasCircumnavigatedCircle)
        {
            inner_radius -= (speed * Time.deltaTime) / 2;
        }

        if (rb.position.magnitude <= inner_radius && !hasHitInnerCircle)
        {
            hasHitInnerCircle = true;
        }

        if (angle <= endAngle && !hasCircumnavigatedCircle)
        {
            hasCircumnavigatedCircle = true;
        }
    }

}
