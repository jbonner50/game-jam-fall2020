using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static bool armor;
    public float hardness = 0.5f;
    public static float currentVelocityY = 0;
    public static bool isColliding;
    private Rigidbody2D rb;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        if(currentVelocityY > 0)
        {
            rb.velocity = new Vector2(0, currentVelocityY);

        } else
        {
            rb.velocity = new Vector2(0, 0);

        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isColliding)
        {
            rb.velocity = new Vector2(0, currentVelocityY);
        }

        int health = player.GetComponent<Player>().health;
        if (currentVelocityY < 0)
        {
            Sprite[] jumpingSprites = player.GetComponent<Player>().jumpingSprites;

            if (health <= 0)
            {
                //player.GetComponent<Player>().GameOver();
                Debug.Log("game over");
            }
            else if (health <= 20)
            {
                player.GetComponent<SpriteRenderer>().sprite = jumpingSprites[4];
            }
            else if (health <= 40)
            {
                player.GetComponent<SpriteRenderer>().sprite = jumpingSprites[3];
            }
            else if (health <= 60)
            {
                player.GetComponent<SpriteRenderer>().sprite = jumpingSprites[2];
            }
            else if (health <= 80)
            {
                player.GetComponent<SpriteRenderer>().sprite = jumpingSprites[1];
            }
            else if (health <= 100)
            {
                player.GetComponent<SpriteRenderer>().sprite = jumpingSprites[0];
            }
        } else
        {
            Sprite[] fallingSprites = player.GetComponent<Player>().fallingSprites;

            if (health <= 0)
            {
                //player.GetComponent<Player>().GameOver();
                Debug.Log("game over");
            }
            else if (health <= 20)
            {
                player.GetComponent<SpriteRenderer>().sprite = fallingSprites[4];
            }
            else if (health <= 40)
            {
                player.GetComponent<SpriteRenderer>().sprite = fallingSprites[3];
            }
            else if (health <= 60)
            {
                player.GetComponent<SpriteRenderer>().sprite = fallingSprites[2];
            }
            else if (health <= 80)
            {
                player.GetComponent<SpriteRenderer>().sprite = fallingSprites[1];
            }
            else if (health <= 100)
            {
                player.GetComponent<SpriteRenderer>().sprite = fallingSprites[0];
            }
        }
        //rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        rb.AddForce(Vector2.up * 9.8f, ForceMode2D.Force);
        

        currentVelocityY = rb.velocity.y;
        
        

    }

    public void SetHardness(int h)
    {
        this.hardness = h;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isColliding = false;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&!VodkaPower.vodka&&!armor)
        {
            isColliding = true;
            currentVelocityY = collision.relativeVelocity.y * 0.3f;

            int damage = (int) (-1 * collision.relativeVelocity.y * this.hardness) - 10;
            if (damage < 0)
            {
                damage = 0;
            }
            collision.gameObject.GetComponent<Player>().DealDamage(damage);

            Debug.Log("Damage: " + damage);
            Debug.Log("Health: " + collision.collider.GetComponent<Player>().health);
            
        }
        armor = false;
    }

}
