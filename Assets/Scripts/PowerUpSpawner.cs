using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    public GameObject[] powerUps = new GameObject[3];
    private Player player;
    

    private float timeBtwSpawn;
    public float maxTime;
    public float minTime;
    private int xChange;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    // Start is called before the first frame update
    void Update()
    {
        if (timeBtwSpawn <= 0 && player.isAlive && Obstacle.currentVelocityY >= 0)
        {


            int rand = Random.Range(0,10);
            int item;
            if(rand <= 1)
            {
                //vodka
                item = 0;
            } else if (rand <= 4) 
            {
                //shield
                item = 1;
            } else
            {
                item = 2;
            }


            if(ObstacleSpawner.currentXChange < 0)
            {
                xChange = 3;
            } else if(ObstacleSpawner.currentXChange > 0)
            {
                xChange = -3;
            } else
            {
                int r = Random.Range(0, 2);
                xChange = r == 0 ?  -3 : 3;
            }

            var obstacleGameObject = Instantiate(powerUps[item], new Vector2(xChange, transform.position.y), Quaternion.identity);
            
            timeBtwSpawn = (float)Random.Range(minTime * 10f, maxTime * 10f) / 10f;

        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }


    }

}
