using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DollPower : MonoBehaviour
{
    private Text powerUpText;
    private float currentSpeed = Obstacle.currentVelocityY;

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
        powerUpText.text = "Armor";
        Obstacle.armor = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;


        // Debug.Log("Armor On");
        Destroy(gameObject);
    }
}
