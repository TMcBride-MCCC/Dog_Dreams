using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject spawnRedCarLeft;
    public GameObject spawnRedCarRight;
    public GameObject player;
    private float time;
    public float delay;
    //Positions that a car can spawn from
    public GameObject[] spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        //Find the player
        player = GameObject.FindGameObjectWithTag("Player");
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

        //If the player is to the left of the spawn location.....
        //Spawn the left car
        if (player.transform.position.x < spawnLocation.transform.position.x)
        {
            //Spawn the car
            GameObject car = Instantiate(spawnRedCarLeft);
            car.transform.position = new Vector2(spawnLocation.transform.position.x, spawnLocation.transform.position.y);
            //Set the direction of the car
            car.GetComponent<CarController>().isMovingLeft = true;
            car.GetComponent<CarController>().isMovingRight = false;
        }
        else
        {
            GameObject car = Instantiate(spawnRedCarRight);
            car.transform.position = new Vector2(spawnLocation.transform.position.x, spawnLocation.transform.position.y);
            //Set the direction of the car
            car.GetComponent<CarController>().isMovingLeft = false;
            car.GetComponent<CarController>().isMovingRight = true;
        }
        
    }
}
