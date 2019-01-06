using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {
    public GameObject AsteroidPool;

    int AsteroidPoolSize = 0;
    float AsteroidSpawnTimerMAX = 10;
    float AsteroidSpawnTimer = 0;
    int AsteroidPoolCounter = 0;

    // Use this for initialization
    void Start () {
        AsteroidPoolSize = AsteroidPool.GetComponent<PoolGenerator>().PoolObjectList.Capacity;
    }
	
	// Update is called once per frame
	void Update () {

        AsteroidSpawnTimer += Random.Range(2f, 5f)*Time.deltaTime;

        if (AsteroidSpawnTimer >= AsteroidSpawnTimerMAX)
        {
            AsteroidPool.GetComponent<PoolGenerator>().PoolObjectList[AsteroidPoolCounter].SetActive(true);
            Debug.Log("Spawn Asteroid");
            AsteroidPoolCounter++;
            AsteroidSpawnTimer = 0;

            if (AsteroidPoolCounter >= AsteroidPoolSize)
            {
                AsteroidPoolCounter = 0;
            }
        }



    }
}
