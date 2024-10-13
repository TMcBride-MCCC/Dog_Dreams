using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ApplyBuff : ScriptableObject
{
    //Tell the code which object is going to receive the buff/debuff
    //Calls/Connects to the Apply() of the actual buff script
    public abstract void Apply(GameObject player);
}
