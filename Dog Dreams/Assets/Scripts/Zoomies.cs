using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

[CreateAssetMenu (menuName = "Buffs/Zoomies")]
public class Zoomies : ApplyBuff
{
    public float speedMult;

    public override void Apply(GameObject player)
    {
        player.GetComponent<PlayerController>().movementSpeed *= speedMult;
    }
}
