using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public static bool armor;
    public static bool vodka;
    public float hardness = 0.5f;
    public static float currentVelocityY = 0;
    public static bool isColliding;
    private Text powerUpText;
    private Rigidbody2D rb;
    private GameObject player;

    float boolHoldDuration = 3; // seconds
    Stopwatch stopWatch = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        powerUpText = GameObject.Find("PowerUpText").GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        
        if (currentVelocityY > 0)
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
        if (!player.GetComponent<Player>().isAlive)
        {
            rb.velocity = new Vector2(0, 0);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        } else
        {
            if (rb.velocity.y < 3 && rb.velocity.y > -3)
            {
                if (!stopWatch.IsRunning)
                {
                    stopWatch.Start();
                }
                else
                {
                    if (stopWatch.Elapsed.Seconds >= boolHoldDuration)
                    {
                        player.GetComponent<Player>().isAlive = false;
                        currentVelocityY = 10;
                    }
                }
            }
            else
            {
                stopWatch.Reset();
            }

            if (transform.position.y > 15)
            {
                Destroy(gameObject);
            }
            else
            {

                rb.AddForce(Vector2.up * 9.8f, ForceMode2D.Force);
                if (isColliding)
                {
                    rb.velocity = new Vector2(0, currentVelocityY);
                }

                int health = player.GetComponent<Player>().health;
                if (currentVelocityY < 0)
                {
                    Sprite[] jumpingSprites = player.GetComponent<Player>().jumpingSprites;

                    if (health <= 20)
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
                }
                else
                {
                    Sprite[] fallingSprites = player.GetComponent<Player>().fallingSprites;


                    if (health <= 20)
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
      

                currentVelocityY = rb.velocity.y;
            }
        }
        


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
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = true;
            

            int damage = (int) (-1 * collision.relativeVelocity.y * this.hardness / 1.5f) - 10;
            if (damage < 0)
            {
                damage = 0;
            }

            if (armor || vodka)
            {
                armor = false;
                
            } else
            {
                collision.gameObject.GetComponent<Player>().DealDamage(damage); 

            }

            if (collision.collider.GetComponent<Player>().isAlive)
            {
                currentVelocityY = collision.relativeVelocity.y * 0.3f;
            }
    

            if (powerUpText.text.Equals("Armor") || powerUpText.text.Equals("+10 Health"))
            {
                powerUpText.text = "";
            }
        }
        
    }

}
