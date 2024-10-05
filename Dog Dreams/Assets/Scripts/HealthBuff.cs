using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/HealthBuff")]
public class HealthBuff : ApplyBuff
{
    public float addHealth;

    public override void Apply(GameObject player)
    {
        player.GetComponent<PlayerController>().health += addHealth;
    }
}
