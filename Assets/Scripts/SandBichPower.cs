using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandBichPower : MonoBehaviour
{

    private float currentSpeed = Obstacle.currentVelocityY;
    private Text powerUpText;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        powerUpText = GameObject.Find("PowerUpText").GetComponent<Text>();

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

            }
        
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUp(collision);
        }
       
    }
    void PickUp(Collider2D player)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        powerUpText.text = "+10 Health";
        int newHealth = player.GetComponent<Player>().health + 10;
        if (newHealth > 100)
        {
            newHealth = 100;
        }
        player.GetComponent<Player>().SetHealth(newHealth);
        Destroy(gameObject);
    }
}
