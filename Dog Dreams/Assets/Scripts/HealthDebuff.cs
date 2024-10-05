using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/HealthDebuff")]
public class HealthDebuff : ApplyBuff
{
    public int addHealth;

    public override void Apply(GameObject player)
    {
        if (player.GetComponent<PlayerController>().health > 0)
        {
            player.GetComponent<PlayerController>().health -= addHealth;
        }
    }
}