using UnityEngine;

static public class TrigCalculations
{
    /****************************
     * X(t)
     * Param: angle
     * 
     * This function is the x value of a parametric
     * function. This, when paired with the function
     * y(t) will give us a point on a circle at the
     * angle t.
     ***************************/
    public static float x(float angle)
    {
        return Mathf.Sin(angle);
    }

    /****************************
     * Y(t)
     * Param: angle
     * 
     * This function is the x value of a parametric
     * function. This, when paired with the function
     * x(t) will give us a point on a circle at the
     * angle t.
     ***************************/
    public static float y(float angle)
    {
        return Mathf.Cos(angle);
    }

    /************************************
     * GetPointOnRadius
     * Param: Angle, and radius
     * 
     * This function will return a v2 containing the
     * point on a circle at angle t, with the radius
     * r. This uses the parametric function
     * X(t) = sin(t)
     * Y(t) = cos(t) 
     ***********************************/
    public static Vector2 getPointOnRadius(float angle, float radius)
    {
        Vector2 return_value = new Vector2(radius * x(angle), radius * y(angle));
        return return_value;
    }

    /*************************************
     * getTangentLineIntersect
     * Param: Angle, Outer Radius, Inner Radius
     * 
     * This function will start from a point on the inner radius
     * at angle T, from there it will follow the tangent line
     * out until it intersects with the outer radius
     * We will return the point on the outerRadius.
     * Math has been done to optimize this, and now
     * all we need is the angle from
     * the inner point to the outer point
     * where the third point on the triangle is the origon.
     * From there we solve for the angle, closest to us (easiest to solve for)
     * then we take 180 - (90 <square angle> + <angle we find>) which simplifies
     * down to just 90 - angle_to_remove. from there we have the angle to the
     * outer_point, and we just need to get the point using the radius.
     ************************************/
    public static Vector2 getTangentLineIntersect(float angle, float outerRadius, float innerRadius)
    {
        float angle_to_remove = ((Mathf.Acos(innerRadius / outerRadius)));
        Vector2 return_value = getPointOnRadius(angle - angle_to_remove, innerRadius);
        return return_value;
    }

    public static float speedToAngleRotation(float radius, float speed)
    {
        float rotationSpeed = 0;
        float circumference = 2 * radius * Mathf.PI;
        rotationSpeed = ((speed * Time.deltaTime) / circumference) * 360;
        return rotationSpeed;
    }
}
