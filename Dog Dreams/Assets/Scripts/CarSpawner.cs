using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject spawnedObject;
    private float time;
    public float delay;
    //Positions that a car can spawn from
    public GameObject[] spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= delay)
        {
            spawnCar();
            time = 0f;
        }
    }

    private void spawnCar()
    {
        //Randomly choose a spawn location #
        int spawnNum = Random.Range(0, spawnLocations.Length);
        //Tell the game to choose that location 
        GameObject spawnLocation = spawnLocations[spawnNum];
        //Tell the game to put the car at that location
        Instantiate(spawnedObject);
        spawnedObject.transform.position = new Vector2(spawnLocation.transform.position.x, spawnLocation.transform.position.y);
    }
}
