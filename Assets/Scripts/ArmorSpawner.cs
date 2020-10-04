using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSpawner : MonoBehaviour
{
    public GameObject DollPrefab;
    public float respawnTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DollSpawn());
    }
    IEnumerator DollSpawn()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        while (player.isAlive)
        {
            respawnTime = Random.Range(10.0f, 40.0f);
            yield return new WaitForSeconds(respawnTime);
            int xChange = Random.Range(-3, 4);
            var DollGameObject = Instantiate(DollPrefab, transform.position, DollPrefab.transform.rotation);
            Vector2 targetPos = new Vector2(xChange, transform.position.y);
            DollGameObject.transform.position = targetPos;
            
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
