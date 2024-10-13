using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    //Movement variables
    private float inputHorizontal;
    public float movementSpeed;
    public float tempMovementSpeed;
    //Jump variables
    public float jumpHeight;
    public float jumpForce;
    public float jumpGravity;
    public float fallGravity;
    private bool jumping;
    private float jumpTime;
    private float jumpTimeMax = 2;
    private bool surface = false;
    //Health variables
    public int health;
    public int maxHealth;
    //Car collision variables
    public float bounceForceCar;
    private float hitTimer;
    //Need to call GameManager to set death
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();

        health = 4;
        maxHealth = 4;
        hitTimer += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();
        jump();
        hitTimer += Time.deltaTime;
    }

    //Handles the L/R movement
    private void movePlayerLateral()
    {
        //Moves player left & right with Horizontal (prepackaged in Unity)
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        playerRB.velocity = new Vector2(movementSpeed * inputHorizontal, playerRB.velocity.y);
        
        //Call player direction
        if (inputHorizontal != 0)
        {
            playerDirection(inputHorizontal);
        }
    }

    //Handles the direction that the Player is facing
    private void playerDirection(float inputHorizontal)
    {
        if (inputHorizontal > 0)
        {
            //Moving to the right
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (inputHorizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }


    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && surface)
        {
            //Old Jump
            //playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpforce);

            //The following is a way of calculating the jump if you want to set a limit to the height
            //Set player's initial gravity to the jumpGravity variable
            playerRB.gravityScale = jumpGravity;
            //JumpForce is calculated by getting the square root of: jumpHeight times gravity times -2, all times the player's mass
            jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * playerRB.gravityScale) * -2) * playerRB.mass;
            //This finalizes the jump calculation
            //ForceMode2D specifies the type of force.
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
            jumpTime = 0;
        }

        if (jumping)
        {
            //Record press time
            jumpTime += Time.deltaTime;

            //If the amount of time that the jump button is pressed is less than the max time...
            //Initiate fallGravity instead of jumpGravity
            if (jumpTime < jumpTimeMax && Input.GetKeyUp(KeyCode.Space))
            {
                playerRB.gravityScale = fallGravity;
            }

            //If the player reaches the top of the height allowed for jumping...
            //Initiate fallGravity instead of jumpGravity
            //Jumping is now false since player is on the ground
            if (playerRB.velocity.y < 0)
            {
                playerRB.gravityScale = fallGravity;
                jumping = false;
            }
        }
    }

    //Handles knowing if we are on a surface or jumping
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            surface = true;
        }
        else if (collision.gameObject.CompareTag("Hood"))
        {
            //Hood collision kills player
            //SceneManager.LoadScene("Level01");
            gameManager.gameOver();
            
        }
        else if (collision.gameObject.CompareTag("Trunk"))
        {
            if (hitTimer >= 1f)
            {
                //Trunk collision hurts player
                health--;
                //Reset timer
                hitTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Bounce test for car trunk
        if (collision.gameObject.CompareTag("Trunk"))
        {
            //Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            //rb.velocity = new Vector2(rb.velocity.x + 5, bounceForceCar);
        }
    }

    //Handles knowing if we are on a surface or jumping
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            surface = false;
        }
    }
}
