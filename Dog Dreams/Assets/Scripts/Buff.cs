using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    //Attach this to the object

    //Connecting to the ApplyBuff script
    public ApplyBuff buff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy the item
            Destroy(gameObject);
            //Apply the buff to the player
            buff.Apply(collision.gameObject);
        }
    }
}
