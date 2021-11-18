using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_arc : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            Vector3 location = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            float zAngle = (Mathf.Rad2Deg * Mathf.Atan2(location.y, location.x));

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, zAngle - 135), rotationSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float zAngle = (Mathf.Rad2Deg * Mathf.Atan2(location.y, location.x));

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, zAngle - 135), rotationSpeed * Time.deltaTime);
        }
    }
}
