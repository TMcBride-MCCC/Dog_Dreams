using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/HealthBuff")]
public class HealthBuff : ApplyBuff
{
    public int addHealth;

    public override void Apply(GameObject player)
    {
        if (player.GetComponent<PlayerController>().health < player.GetComponent<PlayerController>().maxHealth)
        {
            player.GetComponent<PlayerController>().health += addHealth;
        }
    }
}
