using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    public Text healthText;
    public Sprite[] fallingSprites = new Sprite[5];
    public Sprite[] jumpingSprites = new Sprite[5];

    public int moveSpeed = 5;
    public int health = 100;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb != null)
        {
            ApplyInput();
        } else
        {
            Debug.LogWarning("Rigidbody not attached to player " + gameObject.name);
        }
    }

    // check to see if keys are down => execute movement
    private void ApplyInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);

        //if (IsTouchingObject() && Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //}
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if(health < 0)
        {
            health = 0;
        }
        healthText.text = health.ToString();

        //if(health <= 0)
        //{
        //    //game over
        //    Debug.Log("game over");
        //} else if (health <= 20)
        //{
        //    this.GetComponent<SpriteRenderer>().sprite = fallingSprites[0];
        //}
        //else if (health <= 40)
        //{
        //    this.GetComponent<SpriteRenderer>().sprite = fallingSprites[1];
        //}
        //else if (health <= 60)
        //{
        //    this.GetComponent<SpriteRenderer>().sprite = fallingSprites[2];
        //}
        //else if (health <= 80)
        //{
        //    this.GetComponent<SpriteRenderer>().sprite = fallingSprites[3];
        //}
      
    }

    public void GameOver()
    {
        isAlive = false;
        new SceneLoader().LoadMenu();
        
    }


    //private bool IsTouchingObject()
    //{
    //    return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, 0), col.size.x / 2f * 1.1f, objectLayer);

    //}
}

