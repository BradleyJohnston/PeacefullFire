using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    public AnimationCurve curve;

    public SpriteRenderer loadingBar;
    public GameObject trail;
    private GameObject trailHolder;

    public float maxAttackCD;
    private float counterOfCD = 0;
    public float attackLength;

    // Update is called once per frame

    private void Start()
    {
        if (PlayerPrefs.HasKey("attSpe"))
        {
            maxAttackCD = PlayerPrefs.GetFloat("attSpe");
        }

        if (PlayerPrefs.HasKey("attLen"))
        {
            attackLength = PlayerPrefs.GetFloat("attLen");
        }

        counterOfCD = maxAttackCD;
    }
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && counterOfCD >= maxAttackCD)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            trailHolder = Instantiate(trail, position, Quaternion.identity);
            counterOfCD = 0;
        }

        if (Input.GetMouseButton(0) && trailHolder != null && counterOfCD < maxAttackCD)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            trailHolder.transform.position = position;
        }

        if ((Input.GetMouseButtonUp(0) || counterOfCD >= attackLength) && trailHolder != null)
        {

            Destroy(trailHolder.GetComponent<CircleCollider2D>());
            trailHolder = null;
        }

        if (counterOfCD <= maxAttackCD)
        {
            float buffer = Time.deltaTime;
            counterOfCD += buffer;
            if (buffer >= .5f)
            {
                Debug.Log("There might be a problem");
            }    

        }

        if (loadingBar)
        {
            loadingBar.color = new Color(loadingBar.color.r, loadingBar.color.g, loadingBar.color.b, curve.Evaluate((counterOfCD / maxAttackCD)));
        }
    }


}
