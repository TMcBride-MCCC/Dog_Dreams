using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BirdController : MonoBehaviour
{
    private GameObject player;
    private Vector2 playerLocation;
    public float speed;
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //Let the bird know what the player is
        player = GameObject.FindGameObjectWithTag("Player");
        //Find the game Manager
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime);
    }
}
