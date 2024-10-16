using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public GameObject spawnCatLeft;
    public GameObject spawnCatRight;
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
            spawnCat();
            time = 0f;
        }
    }

    private void spawnCat()
    {
        //Randomly choose a spawn location #
        int spawnNum = Random.Range(0, spawnLocations.Length);
        //Tell the game to choose that location 
        GameObject spawnLocation = spawnLocations[spawnNum];

        //If the player is to the left of the spawn location.....
        //Spawn the left car
        if (player.transform.position.x < spawnLocation.transform.position.x)
        {
            //Spawn the cat
            GameObject cat = Instantiate(spawnCatLeft);
            cat.transform.position = new Vector2(spawnLocation.transform.position.x, spawnLocation.transform.position.y);
        }
        else
        {
            GameObject cat = Instantiate(spawnCatRight);
            cat.transform.position = new Vector2(spawnLocation.transform.position.x, spawnLocation.transform.position.y);
        }

    }
}