using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CatController : MonoBehaviour
{
    private GameObject player;
    private Vector2 playerLocation;
    public float speed;
    public float bounceForcePlayer;
    private GameObject gameManager;
    public ScoreTracker scoreTracker;
    public int catVal;

    // Start is called before the first frame update
    void Start()
    {
        //Let the cat know what the player is
        player = GameObject.FindGameObjectWithTag("Player");
        //Find the game Manager
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        //Let the cat know what is keeping score
        scoreTracker = gameManager.GetComponent<ScoreTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scoreTracker.addToScore(catVal);
            Destroy(this.gameObject);
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x + 5, bounceForcePlayer);
        }
    }
}