using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VodkaSpawner : MonoBehaviour
{
    public GameObject VodkaPrefab;
    public float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(VodkaSpawn());
    }
    IEnumerator VodkaSpawn()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        while (player.isAlive)
        {
            float respawnTime = Random.Range(10.0f, 60.0f);
            yield return new WaitForSeconds(respawnTime);
            int xChange = Random.Range(-3, 4);
            var VodkaGameObject = Instantiate(VodkaPrefab, transform.position, VodkaPrefab.transform.rotation);
            Vector2 targetPos = new Vector2(xChange, transform.position.y);
            VodkaGameObject.transform.position = targetPos;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
