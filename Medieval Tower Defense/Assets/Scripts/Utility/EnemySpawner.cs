using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class which controls the spawning of enemies along the path in game
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    private GameObject spiderEnemy;
    private GameObject ratEnemy;

    private int spiderSpawnedAmount = 0;
    private int ratSpawnedAmount = 0;

    private float spiderSpawnTimer = 0; // used to compare when to spawn an enemy
    public float spiderSpawnTime = 0; // set from the inspector to determine time between enemy spawns
    private float ratSpawnTimer = 0; // used to compare when to spawn an enemy
    public float ratSpawnTime = 0; // set from the inspector to determine time between enemy spawns

    // Use this for initialization
    void Start ()
    {
        spiderEnemy = Resources.Load("SpiderEnemy") as GameObject;
        ratEnemy = Resources.Load("RatEnemy") as GameObject;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        spiderSpawnTimer += Time.deltaTime;
        ratSpawnTimer += Time.deltaTime;
        if(spiderSpawnTimer > spiderSpawnTime && spiderSpawnedAmount < 30)
        {
            Instantiate(spiderEnemy, transform.position, Quaternion.identity);
            spiderSpawnedAmount++;
            spiderSpawnTimer = 0;
        }
        if (ratSpawnTimer > ratSpawnTime && ratSpawnedAmount < 10)
        {
            Instantiate(ratEnemy, transform.position, Quaternion.identity);
            ratSpawnedAmount++;
            ratSpawnTimer = 0;
        }
    }
}
