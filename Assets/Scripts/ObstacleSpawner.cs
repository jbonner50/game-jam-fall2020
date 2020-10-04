using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Player player;

    static public int currentXChange;
    private float timeBtwSpawn;
    public float maxTime;
    public float minTime;

    public Sprite hard1, hard2, hard3, soft1, soft2;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    // Start is called before the first frame update
    void Update()
    {
        if(timeBtwSpawn<=0 && player.isAlive && Obstacle.currentVelocityY >= 0)
        {
            
                int xChange = Random.Range(-3, 4);
                currentXChange = xChange;
                int hardness = Random.Range(1, 3);

                var obstacleGameObject = Instantiate(obstaclePrefab, new Vector2(xChange, transform.position.y), Quaternion.identity);
                obstacleGameObject.GetComponent<Obstacle>().SetHardness(hardness);
                if (hardness == 2)
                {
                    float rand = Random.value;
                    if (rand < .33)
                    {
                        obstacleGameObject.GetComponent<SpriteRenderer>().sprite = hard1;
                    } else if (rand < .66)
                    {
                        obstacleGameObject.GetComponent<SpriteRenderer>().sprite = hard2;
                    }
                    else
                    {
                        obstacleGameObject.GetComponent<SpriteRenderer>().sprite = hard3;
                    }
                } else
                    {
                        float rand = Random.value;
                        if (rand < .5)
                        {
                            obstacleGameObject.GetComponent<SpriteRenderer>().sprite = soft1;
                        }
                        else
                        {
                            obstacleGameObject.GetComponent<SpriteRenderer>().sprite = soft2;
                        }
                }
                // obstacleGameObject.GetComponent<SpriteRenderer>().color = new Color(hardness == 1 ? 0 : 255, hardness == 2 ? 0 : 255, 0);

            timeBtwSpawn = (float)Random.Range(minTime * 10f, maxTime * 10f) / 10f;
            
        } else
        {
            timeBtwSpawn -= Time.deltaTime;
        }


    }


    
}
