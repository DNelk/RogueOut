using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBricks : Option
{
    public override void ApplyOption()
    {
        BrickManager.Instance.enableExplosives = true;
        base.ApplyOption();
    }
}
