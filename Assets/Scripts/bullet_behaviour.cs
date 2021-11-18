using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_behaviour : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private float time = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        time += (Time.deltaTime) / 4f;
        rb.MovePosition(Vector2.Lerp(rb.position, Vector2.zero, time));
    }
}
