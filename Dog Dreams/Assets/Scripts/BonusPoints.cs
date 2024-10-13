using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows us to create multiples of this buff in the Asset value
//Each created scriptable object can have different values
//and do the same buff operations
[CreateAssetMenu(menuName = "Buffs/BonusPoints")]
public class BonusPoints : ApplyBuff
{
    //Allows use to reuse the scriptable object buff on multiple items
    //and set different amounts of healthbuff
    public int Points;

    public override void Apply(GameObject score)
    {
        //Add the health to the player
        score.GetComponent<ScoreTracker>().score += Points;
    }
}