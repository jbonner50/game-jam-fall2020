using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanbichSpawner : MonoBehaviour
{
    public GameObject SandbichPrefab;
    public float respawnTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SandBichSpawn());
    }
    IEnumerator SandBichSpawn()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        while (player.isAlive)
        {
            respawnTime = Random.Range(5.0f, 30.0f);
            yield return new WaitForSeconds(respawnTime);
            int xChange = Random.Range(-3, 4);
            var SandbichGameObject = Instantiate(SandbichPrefab, transform.position, SandbichPrefab.transform.rotation);
            Vector2 targetPos = new Vector2(xChange, transform.position.y);
            SandbichGameObject.transform.position = targetPos;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
