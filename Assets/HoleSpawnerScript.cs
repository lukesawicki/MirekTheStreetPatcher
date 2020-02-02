using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hole;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    public int carsCounter = 0;
    public int maxCarsOnLevel = 0;

    public GameObject spawnedObject;

    public void SpawnHoleObject()
    {
        if (!spawnedObject)
        {
            spawnedObject = Instantiate(hole, transform.position, transform.rotation);
        }
        //if (stopSpawning)
        //{
        //    CancelInvoke("SpawnHoleObject");
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 2; //Random.Range(2, 20);
        spawnDelay = 3;// Random.Range(3, 20);

        InvokeRepeating("SpawnHoleObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
