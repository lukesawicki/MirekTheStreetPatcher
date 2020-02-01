using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerScript : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    public int carsCounter = 0;
    public int maxCarsOnLevel = 0;

    public void SpawnObject()
    {
        Instantiate(prefabToSpawn, transform.position, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
