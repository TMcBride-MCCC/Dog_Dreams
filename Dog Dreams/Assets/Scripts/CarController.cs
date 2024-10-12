using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private GameObject player;
    private Vector2 playerLocation;
    public bool isMovingLeft;
    public bool isMovingRight;
    public float speed;
    public float bounceForcePlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //playerLocation = player.transform.position;
        //transform.position = Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime);
        if (isMovingLeft)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
        if (isMovingRight)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x + 5, bounceForcePlayer);
        }
    }
}
