using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ApplyBuff : ScriptableObject
{
    public abstract void Apply(GameObject player);
}
