using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows us to create multiples of this buff in the Asset value
//Each created scriptable object can have different values
//and do the same buff operations
[CreateAssetMenu(menuName = "Buffs/HealthBuff")]
public class HealthBuff : ApplyBuff
{
    //Allows use to reuse the scriptable object buff on multiple items
    //and set different amounts of healthbuff
    public int addHealth;

    public override void Apply(GameObject player)
    {
        //If the player's health is below the max health...
        if (player.GetComponent<PlayerController>().health < player.GetComponent<PlayerController>().maxHealth)
        {
            //Add the health to the player
            player.GetComponent<PlayerController>().health += addHealth;
        }
    }
}
