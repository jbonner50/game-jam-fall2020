using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingWall : MonoBehaviour
{
    private float currentSpeed = Obstacle.currentVelocityY;
    public float endY;
    public float startY;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameObject.Find("Player").GetComponent<Player>().isAlive)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

        }
        else
        {

            currentSpeed = Obstacle.currentVelocityY;
            rb.velocity = new Vector2(0, currentSpeed);


            if (transform.position.y >= endY)
            {
                Vector2 pos = new Vector2(transform.position.x, startY);
                transform.position = pos;
            }
            else if (transform.position.y <= startY)
            {
                Vector2 pos = new Vector2(transform.position.x, endY);
                transform.position = pos;
            }
        }
    }
}
